using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.ManyToMany;
using PlantNavigator.API.Models.DTOs.Pest;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/pests")]
    public class PestsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IPestsRepository pestsRepository;

        public PestsController(ILogger<PestsController> logger,
            IPestsRepository pestsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.pestsRepository = pestsRepository ??
                throw new ArgumentNullException(nameof(pestsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetPests")]
        public async Task<ActionResult<IEnumerable<PestGetDto>>> GetPests([FromQuery] string? nameQuery)
        {
            var pests = await pestsRepository.GetAll(nameQuery);
            return Ok(mapper.Map<IEnumerable<PestGetDto>>(pests));
        }

        [HttpGet("{id}", Name = "GetPestById")]
        public async Task<ActionResult<PestGetDto>> GetPestById(int id)
        {
            var pest = await pestsRepository.GetById(id);

            if (pest == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PestGetDto>(pest));
        }



        [HttpPost(Name = "PostPest")]
        public async Task<ActionResult> PostPest(PestPostDto pest)
        {
            Pest pestToAdd = null;
            try
            {
                pestToAdd = mapper.Map<Pest>(pest);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User pest post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await pestsRepository.AddPest(pestToAdd);

            return CreatedAtRoute("GetPestById",
                new
                {
                    id = pestToAdd.Id
                }, mapper.Map<PestGetDto>(pestToAdd));
        }

        [HttpPut("{id}", Name = "UpdatePest")]
        public async Task<ActionResult> UpdatePest(int id, PestPutDto pest)
        {
            var foundPest = await pestsRepository.GetById(id);

            if (foundPest == null)
            {
                return NotFound();
            }

            mapper.Map(pest, foundPest);
            pestsRepository.UpdatePest(foundPest);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePestById")]
        public async Task<ActionResult> DeletePestById(int id)
        {
            var pest = await pestsRepository.GetById(id);

            if (pest == null)
            {
                return NotFound();
            }

            await pestsRepository.DeletePest(pest);

            return NoContent();
        }







        // PLANT TO PEST realted endpoints
        [HttpPost("plantPest", Name = "PostPlantPest")]
        public async Task<ActionResult> PostPlantPest(Plant_PestPostDto joining)
        {
            if (!await pestsRepository.PlantExists(joining.PlantId))
            {
                return NotFound();
            }

            if (!await pestsRepository.PestExists(joining.PestId))
            {
                return NotFound();
            }

            try
            {
                var joinToAdd = mapper.Map<Plant_Pest>(joining);
                await pestsRepository.AddPlantPestJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("plantPest", Name = "DeletePlantPestById")]
        public async Task<ActionResult> DeletePlantPestById([FromQuery] int plantId, [FromQuery] int pestId)
        {
            var plantPest = await pestsRepository.GetPlantPestById(plantId, pestId);

            if (plantPest == null)
            {
                return NotFound();
            }

            await pestsRepository.DeletePlantPest(plantPest);

            return NoContent();
        }

    }
}
