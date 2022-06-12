using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;
using PlantNavigator.API.Models.DTOs.Post;
using PlantNavigator.API.Models.DTOs.Put;
using PlantNavigator.API.Repositories;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/classifications")]
    public class ClassificationsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IClassificationsRepository classificationsRepository;

        public ClassificationsController(ILogger<ClassificationsController> logger,
            IClassificationsRepository classificationsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.classificationsRepository = classificationsRepository ??
                throw new ArgumentNullException(nameof(classificationsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetClassifications")]
        public async Task<ActionResult<IEnumerable<ClassificationGetDto>>> GetClassifications([FromQuery] string? name)
        {
            var classifications = await classificationsRepository.GetAll(name);
            return Ok(mapper.Map<IEnumerable<ClassificationGetDto>>(classifications));
        }


        [HttpGet("{id}", Name = "GetClassificationById")]
        public async Task<ActionResult<ClassificationGetDto>> GetClassificationById(int id)
        {
            var classification = await classificationsRepository.GetById(id);

            if (classification == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ClassificationGetDto>(classification));
        }



        [HttpPost(Name = "PostClassification")]
        public async Task<ActionResult> PostClassification(ClassificationPostDto classification)
        {
            Classification finalClassification = null;
            try
            {
                finalClassification = mapper.Map<Classification>(classification);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User classification post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await classificationsRepository.AddClassification(finalClassification);

            return CreatedAtRoute("GetClassificationById",
                new
                {
                    id = finalClassification.Id
                }, mapper.Map<ClassificationGetDto>(finalClassification));
        }

        [HttpPut("{id}", Name = "UpdateClassification")]
        public async Task<ActionResult> UpdateClassification(int id, ClassificationPutDto classification)
        {
            var foundClassification = await classificationsRepository.GetById(id);

            if (foundClassification == null)
            {
                return NotFound();
            }

            mapper.Map(classification, foundClassification);
            classificationsRepository.UpdateClassification(foundClassification);

            return NoContent();
        }
    }
}
