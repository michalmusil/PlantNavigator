using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Models.DTOs.LightCondition;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/lightConditions")]
    public class LightConditionsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly ILightConditionsRepository lightConditionsRepository;

        public LightConditionsController(ILogger<LightConditionsController> logger,
            ILightConditionsRepository lightConditionsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.lightConditionsRepository = lightConditionsRepository ??
                throw new ArgumentNullException(nameof(lightConditionsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetLightConditions")]
        public async Task<ActionResult<IEnumerable<LightConditionGetDto>>> GetLightConditions([FromQuery] string? lightConditionName,
            [FromQuery] int? lightIntensity)
        {
            SunlightIntensity? intensity = null;
            if (lightIntensity != null)
            {
                try
                {
                    intensity = (SunlightIntensity)lightIntensity;
                }
                catch (Exception ex)
                {
                    return BadRequest("Light intensity out of scope");
                }
            }
            var lightConditions = await lightConditionsRepository.GetAll(lightConditionName, intensity);
            return Ok(mapper.Map<IEnumerable<LightConditionGetDto>>(lightConditions));
        }

        [HttpGet("sunlightIntensities", Name = "GetSunlightIntensities")]
        public async Task<ActionResult<IEnumerable<SunlightIntensityGetDto>>> GetSunlightIntensities()
        {
            List<SunlightIntensityGetDto> sunlightIntensities = new List<SunlightIntensityGetDto>();
            foreach (int t in Enum.GetValues(typeof(SunlightIntensity)))
            {
                var type = new SunlightIntensityGetDto(t, Enum.GetName(typeof(SunlightIntensity), t));
                sunlightIntensities.Add(type);
            }
            return Ok(sunlightIntensities);
        }


        [HttpGet("{id}", Name = "GetLightConditionById")]
        public async Task<ActionResult<LightConditionGetDto>> GetLightConditionById(int id)
        {
            var lightCondition = await lightConditionsRepository.GetById(id);

            if (lightCondition == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LightConditionGetDto>(lightCondition));
        }



        [HttpPost(Name = "PostLightCondition")]
        public async Task<ActionResult> PostLightCondition(LightConditionPostDto lightCondition)
        {
            LightCondition finalLightCondition = null;
            try
            {
                finalLightCondition = mapper.Map<LightCondition>(lightCondition);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User LightCondition post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await lightConditionsRepository.AddLightCondition(finalLightCondition);

            return CreatedAtRoute("GetLightConditionById",
                new
                {
                    id = finalLightCondition.Id
                }, mapper.Map<LightConditionGetDto>(finalLightCondition));
        }

        [HttpPut("{id}", Name = "UpdateLightCondition")]
        public async Task<ActionResult> UpdateLightCondition(int id, LightConditionPutDto lightCondition)
        {
            var foundLightCondition = await lightConditionsRepository.GetById(id);

            if (foundLightCondition == null)
            {
                return NotFound();
            }

            mapper.Map(lightCondition, foundLightCondition);
            lightConditionsRepository.UpdateLightCondition(foundLightCondition);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteLightConditionById")]
        public async Task<ActionResult> DeleteLightConditionById(int id)
        {
            var LightCondition = await lightConditionsRepository.GetById(id);

            if (LightCondition == null)
            {
                return NotFound();
            }

            await lightConditionsRepository.DeleteLightCondition(LightCondition);

            return NoContent();
        }

    }
}
