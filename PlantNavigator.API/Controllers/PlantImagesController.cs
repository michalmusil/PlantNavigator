using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
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

            this.allowedExtensions = new string[] { ".jped", ".jpg", ".png" };
        }
        



        [HttpPost(Name = "PostPlantImage")]
        public async Task<ActionResult> PostPlantImage(int plantId, IFormFile image)
        {
            try
            {
                if (image.Length > 0 && allowedExtensions.Contains(Path.GetExtension(image.FileName)) )
                {
                    string relativePath = "\\Images\\";
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
                        newPlantImage.path = relativePath + fileName;
                        await plantImagesRepository.AddPlantImage(newPlantImage);
                        return Ok();
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

    }
}
