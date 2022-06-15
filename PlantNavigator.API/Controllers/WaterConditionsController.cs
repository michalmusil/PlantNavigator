using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Models.DTOs.WateringCondition;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/waterConditions")]
    public class WaterConditionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IWaterConditionsRepository waterConditionsRepository;

        public WaterConditionsController(ILogger<WaterConditionsController> logger,
            IWaterConditionsRepository waterConditionsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.waterConditionsRepository = waterConditionsRepository ??
                throw new ArgumentNullException(nameof(waterConditionsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetWaterConditions")]
        public async Task<ActionResult<IEnumerable<WaterConditionGetDto>>> GetWaterConditions([FromQuery] string? waterConditionName,
            [FromQuery] int? wateringIntensity)
        {
            WateringIntensity? intensity = null;
            if (wateringIntensity != null)
            {
                if (wateringIntensity > (Enum.GetValues(typeof(WateringIntensity))).Length - 1 || wateringIntensity < 0)
                {
                    return BadRequest("Watering intensity out of scope");
                }
                intensity = (WateringIntensity)wateringIntensity;
            }
                        
            var waterConditions = await waterConditionsRepository.GetAll(waterConditionName, intensity);
            return Ok(mapper.Map<IEnumerable<WaterConditionGetDto>>(waterConditions));
        }

        [HttpGet("wateringIntensities", Name = "GetWateringIntensities")]
        public async Task<ActionResult<IEnumerable<WateringIntensityGetDto>>> GetWateringIntensities()
        {
            List<WateringIntensityGetDto> wateringIntensities = new List<WateringIntensityGetDto>();
            foreach (int t in Enum.GetValues(typeof(WateringIntensity)))
            {
                var type = new WateringIntensityGetDto(t, Enum.GetName(typeof(WateringIntensity), t));
                wateringIntensities.Add(type);
            }
            return Ok(wateringIntensities);
        }


        [HttpGet("{id}", Name = "GetWaterConditionById")]
        public async Task<ActionResult<WaterConditionGetDto>> GetWaterConditionById(int id)
        {
            var WaterCondition = await waterConditionsRepository.GetById(id);

            if (WaterCondition == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WaterConditionGetDto>(WaterCondition));
        }



        [HttpPost(Name = "PostWaterCondition")]
        public async Task<ActionResult> PostWaterCondition(WaterConditionPostDto waterCondition)
        {
            WaterCondition finalWaterCondition = null;
            try
            {
                finalWaterCondition = mapper.Map<WaterCondition>(waterCondition);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User WaterCondition post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await waterConditionsRepository.AddWaterCondition(finalWaterCondition);

            return CreatedAtRoute("GetWaterConditionById",
                new
                {
                    id = finalWaterCondition.Id
                }, mapper.Map<WaterConditionGetDto>(finalWaterCondition));
        }

        [HttpPut("{id}", Name = "UpdateWaterCondition")]
        public async Task<ActionResult> UpdateWaterCondition(int id, WaterConditionPutDto waterCondition)
        {
            var foundWaterCondition = await waterConditionsRepository.GetById(id);

            if (foundWaterCondition == null)
            {
                return NotFound();
            }

            mapper.Map(waterCondition, foundWaterCondition);
            waterConditionsRepository.UpdateWaterCondition(foundWaterCondition);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteWaterConditionById")]
        public async Task<ActionResult> DeleteWaterConditionById(int id)
        {
            var WaterCondition = await waterConditionsRepository.GetById(id);

            if (WaterCondition == null)
            {
                return NotFound();
            }

            await waterConditionsRepository.DeleteWaterCondition(WaterCondition);

            return NoContent();
        }
    }
}
