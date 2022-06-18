using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.Disease;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/diseases")]
    public class DiseasesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IDiseasesRepository diseasesRepository;

        public DiseasesController(ILogger<DiseasesController> logger,
            IDiseasesRepository DiseasesRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.diseasesRepository = DiseasesRepository ??
                throw new ArgumentNullException(nameof(DiseasesRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetDiseases")]
        public async Task<ActionResult<IEnumerable<DiseaseGetDto>>> GetDiseases([FromQuery] string? diseaseName,
            [FromQuery] int? plantId, [FromQuery] bool? includeAsociatedPlants)
        {
            var diseases = await diseasesRepository.GetAll(diseaseName, plantId, includeAsociatedPlants);
            return Ok(mapper.Map<IEnumerable<DiseaseGetDto>>(diseases));
        }

        [HttpGet("{id}", Name = "GetDiseaseById")]
        public async Task<ActionResult<DiseaseGetDto>> GetDiseaseById(int id)
        {
            var disease = await diseasesRepository.GetById(id);

            if (disease == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<DiseaseGetDto>(disease));
        }



        [HttpPost(Name = "PostDisease")]
        public async Task<ActionResult> PostDisease(DiseasePostDto disease)
        {
            Disease diseaseToAdd = null;
            try
            {
                diseaseToAdd = mapper.Map<Disease>(disease);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User Disease post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await diseasesRepository.AddDisease(diseaseToAdd);

            return CreatedAtRoute("GetDiseaseById",
                new
                {
                    id = diseaseToAdd.Id
                }, mapper.Map<DiseaseGetDto>(diseaseToAdd));
        }

        [HttpPut("{id}", Name = "UpdateDisease")]
        public async Task<ActionResult> UpdateDisease(int id, DiseasePutDto disease)
        {
            var foundDisease = await diseasesRepository.GetById(id);

            if (foundDisease == null)
            {
                return NotFound();
            }

            mapper.Map(disease, foundDisease);
            diseasesRepository.UpdateDisease(foundDisease);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteDiseaseById")]
        public async Task<ActionResult> DeleteDiseaseById(int id)
        {
            var disease = await diseasesRepository.GetById(id);

            if (disease == null)
            {
                return NotFound();
            }

            await diseasesRepository.DeleteDisease(disease);

            return NoContent();
        }







        // PLANT TO DISEASE realted endpoints
        [HttpPost("plantDisease", Name = "PostPlantDisease")]
        public async Task<ActionResult> PostPlantDisease(Plant_DiseasePostDto joining)
        {
            if (!await diseasesRepository.PlantExists(joining.PlantId))
            {
                return NotFound();
            }

            if (!await diseasesRepository.DiseaseExists(joining.DiseaseId))
            {
                return NotFound();
            }

            if (await diseasesRepository.GetPlantDiseaseById(joining.PlantId, joining.DiseaseId) != null)
            {
                return BadRequest("This connection already exists");
            }

            try
            {
                var joinToAdd = mapper.Map<Plant_Disease>(joining);
                await diseasesRepository.AddPlantDiseaseJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("plantDisease", Name = "DeletePlantDiseaseById")]
        public async Task<ActionResult> DeletePlantDiseaseById([FromQuery] int plantId, [FromQuery] int diseaseId)
        {
            var plantDisease = await diseasesRepository.GetPlantDiseaseById(plantId, diseaseId);

            if (plantDisease == null)
            {
                return NotFound();
            }

            await diseasesRepository.DeletePlantDisease(plantDisease);

            return NoContent();
        }
    }
}
