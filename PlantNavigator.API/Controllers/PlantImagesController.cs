using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.PlantImage;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/plantImages")]
    public class PlantImagesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<PlantsController> logger;
        private readonly IPlantImagesRepository plantImagesRepository;
        private readonly IWebHostEnvironment environment;

        private readonly string[] allowedExtensions;
        private readonly string relativePath;

        public PlantImagesController(ILogger<PlantsController> logger, IPlantImagesRepository plantImagesRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            this.logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            this.plantImagesRepository = plantImagesRepository ??
                throw new ArgumentNullException(nameof(plantImagesRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            this.environment = environment ??
                throw new ArgumentNullException(nameof(environment));

            this.allowedExtensions = new string[] { ".jpeg", ".jpg", ".png" };

            this.relativePath = "\\Images\\";
        }


        [HttpGet(Name = "GetPlantImages")]
        public async Task<ActionResult<IEnumerable<PlantImageGetDto>>> GetPlantImages([FromQuery] int? plantId)
        {
            var plantImages = await plantImagesRepository.GetAll(plantId);
            return Ok(mapper.Map<IEnumerable<PlantImageGetDto>>(plantImages));
        }

        [HttpGet("{imageName}", Name = "GetPlantImageByImageName")]
        public async Task<ActionResult> GetPlantImageByImageName(string imageName)
        {
            var plantImage = await plantImagesRepository.GetByImageName(imageName);

            if (plantImage == null)
            {
                return NotFound();
            }

            string fullImagePath = environment.ContentRootPath + relativePath + plantImage.ImageName;
            
            if (!System.IO.File.Exists(fullImagePath))
            {
                return NotFound();
            }

            byte[] rawImage = System.IO.File.ReadAllBytes(fullImagePath);
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType(fullImagePath, out contentType);

            return File(rawImage, contentType);
        }

        [HttpPost(Name = "PostPlantImage")]
        public async Task<ActionResult> PostPlantImage(int plantId, IFormFile image)
        {
            if (!await plantImagesRepository.PlantExists(plantId))
            {
                return NotFound("Plant with this id does not exist");
            }

            try
            {
                if (image.Length > 0 && allowedExtensions.Contains(Path.GetExtension(image.FileName)) )
                {
                    string directoryPath = environment.ContentRootPath + relativePath;
                    string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fffffff") + Path.GetExtension(image.FileName);
                    
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    using(FileStream fs = System.IO.File.Create(directoryPath + fileName))
                    {
                        image.CopyTo(fs);
                        fs.Flush();
                        PlantImage newPlantImage = new PlantImage();
                        newPlantImage.PlantId = plantId;
                        newPlantImage.ImageName = fileName;
                        await plantImagesRepository.AddPlantImage(newPlantImage);

                        fs.Close();
                        return CreatedAtRoute("GetPlantImageByImageName",
                        new
                        {
                            imageName = fileName
                        }, mapper.Map<PlantImageGetDto>(newPlantImage));
                    }
                }
                else
                {
                    throw new Exception("File format not supported");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{imageName}", Name = "DeletePlantImageByImageName")]
        public async Task<ActionResult> DeletePlantImageByImageName(string imageName)
        {
            var dbImage = await plantImagesRepository.GetByImageName(imageName);

            if (dbImage == null)
            {
                return NotFound();
            }

            await plantImagesRepository.DeletePlantImage(dbImage);

            string fullImagePath = environment.ContentRootPath + relativePath + dbImage.ImageName;

            if (System.IO.File.Exists(fullImagePath))
            {
                System.IO.File.Delete(fullImagePath);
            }

            return NoContent();
        }

    }
}
