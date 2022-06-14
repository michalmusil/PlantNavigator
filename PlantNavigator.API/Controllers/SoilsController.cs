using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.ManyToMany;
using PlantNavigator.API.Models.DTOs.Soil;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/soils")]
    public class SoilsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly ISoilsRepository soilsRepository;

        public SoilsController(ILogger<SoilsController> logger,
            ISoilsRepository soilsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.soilsRepository = soilsRepository ??
                throw new ArgumentNullException(nameof(soilsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetSoils")]
        public async Task<ActionResult<IEnumerable<SoilGetDto>>> GetSoils([FromQuery] string? nameQuery)
        {
            var soils = await soilsRepository.GetAll(nameQuery);
            return Ok(mapper.Map<IEnumerable<SoilGetDto>>(soils));
        }

        [HttpGet("{id}", Name = "GetSoilById")]
        public async Task<ActionResult<SoilGetDto>> GetSoilById(int id)
        {
            var soil = await soilsRepository.GetById(id);

            if (soil == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<SoilGetDto>(soil));
        }



        [HttpPost(Name = "PostSoil")]
        public async Task<ActionResult> PostSoil(SoilPostDto soil)
        {
            Soil soilToAdd = null;
            try
            {
                soilToAdd = mapper.Map<Soil>(soil);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User soil post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await soilsRepository.AddSoil(soilToAdd);

            return CreatedAtRoute("GetSoilById",
                new
                {
                    id = soilToAdd.Id
                }, mapper.Map<SoilGetDto>(soilToAdd));
        }

        [HttpPut("{id}", Name = "UpdateSoil")]
        public async Task<ActionResult> UpdateSoil(int id, SoilPutDto soil)
        {
            var foundSoil = await soilsRepository.GetById(id);

            if (foundSoil == null)
            {
                return NotFound();
            }

            mapper.Map(soil, foundSoil);
            soilsRepository.UpdateSoil(foundSoil);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteSoilById")]
        public async Task<ActionResult> DeleteSoilById(int id)
        {
            var soil = await soilsRepository.GetById(id);

            if (soil == null)
            {
                return NotFound();
            }

            await soilsRepository.DeleteSoil(soil);

            return NoContent();
        }







        // PLANT TO SOIL realted endpoints
        [HttpPost("plantSoil", Name = "PostPlantSoil")]
        public async Task<ActionResult> PostPlantSoil(Plant_SoilPostDto joining)
        {
            if (!await soilsRepository.PlantExists(joining.PlantId))
            {
                return NotFound();
            }

            if (!await soilsRepository.SoilExists(joining.SoilId))
            {
                return NotFound();
            }

            try
            {
                var joinToAdd = mapper.Map<Plant_Soil>(joining);
                await soilsRepository.AddPlantSoilJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("plantSoil", Name = "DeletePlantSoilById")]
        public async Task<ActionResult> DeletePlantSoilById([FromQuery] int plantId, [FromQuery] int soilId)
        {
            var plantSoil = await soilsRepository.GetPlantSoilById(plantId, soilId);

            if (plantSoil == null)
            {
                return NotFound();
            }

            await soilsRepository.DeletePlantSoil(plantSoil);

            return NoContent();
        }

    }
}
