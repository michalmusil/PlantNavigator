using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.FertilizerType;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/fertilizerTypes")]
    public class FertilizerTypesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IFertilizerTypesRepository fertilizerTypesRepository;

        public FertilizerTypesController(ILogger<FertilizerTypesController> logger,
            IFertilizerTypesRepository fertilizerTypesRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.fertilizerTypesRepository = fertilizerTypesRepository ??
                throw new ArgumentNullException(nameof(fertilizerTypesRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetFertilizerTypes")]
        public async Task<ActionResult<IEnumerable<FertilizerTypeGetDto>>> GetFertilizerTypes([FromQuery] string? typeName, [FromQuery] int? plantId)
        {
            var types = await fertilizerTypesRepository.GetAll(typeName, plantId);
            return Ok(mapper.Map<IEnumerable<FertilizerTypeGetDto>>(types));
        }

        [HttpGet("{id}", Name = "GetFertilizerTypeById")]
        public async Task<ActionResult<FertilizerTypeGetDto>> GetFertilizerTypeById(int id)
        {
            var fertilizerType = await fertilizerTypesRepository.GetById(id);

            if (fertilizerType == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FertilizerTypeGetDto>(fertilizerType));
        }



        [HttpPost(Name = "PostFertilizerType")]
        public async Task<ActionResult> PostFertilizerType(FertilizerTypePostDto fertilizerType)
        {
            FertilizerType fertilizerTypeToAdd = null;
            try
            {
                fertilizerTypeToAdd = mapper.Map<FertilizerType>(fertilizerType);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User FertilizerType post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await fertilizerTypesRepository.AddFertilizerType(fertilizerTypeToAdd);

            return CreatedAtRoute("GetFertilizerTypeById",
                new
                {
                    id = fertilizerTypeToAdd.Id
                }, mapper.Map<FertilizerTypeGetDto>(fertilizerTypeToAdd));
        }

        [HttpPut("{id}", Name = "UpdateFertilizerType")]
        public async Task<ActionResult> UpdateFertilizerType(int id, FertilizerTypePutDto fertilizerType)
        {
            var foundFertilizerType = await fertilizerTypesRepository.GetById(id);

            if (foundFertilizerType == null)
            {
                return NotFound();
            }

            mapper.Map(fertilizerType, foundFertilizerType);
            fertilizerTypesRepository.UpdateFertilizerType(foundFertilizerType);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteFertilizerTypeById")]
        public async Task<ActionResult> DeleteFertilizerTypeById(int id)
        {
            var fertilizerType = await fertilizerTypesRepository.GetById(id);

            if (fertilizerType == null)
            {
                return NotFound();
            }

            await fertilizerTypesRepository.DeleteFertilizerType(fertilizerType);

            return NoContent();
        }







        // FERTILIZING HABIT TO FERTILIZER TYPE realted endpoints
        [HttpPost("fertilizingHabitFertilizerType", Name = "PostFertilizerTypeFertilizerType")]
        public async Task<ActionResult> PostFertilizingHabitFertilizerType(FertilizingHabit_FertilizerTypePostDto joining)
        {
            if (!await fertilizerTypesRepository.FertilizingHabitExists(joining.FertilizingHabitId))
            {
                return NotFound();
            }

            if (!await fertilizerTypesRepository.FertilizerTypeExists(joining.FertilizerTypeId))
            {
                return NotFound();
            }

            try
            {
                var joinToAdd = mapper.Map<FertilizingHabit_FertilizerType>(joining);
                await fertilizerTypesRepository.AddFertilizingHabitFertilizerTypeJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("fertilizingHabitFertilizerType", Name = "DeleteFertilizingHabitFertilizerTypeById")]
        public async Task<ActionResult> DeleteFertilizingHabitFertilizerTypeById([FromQuery] int FertilizingHabitId, [FromQuery] int FertilizerTypeId)
        {
            var fertilizingHabitFertilizerType = await fertilizerTypesRepository.GetFertilizingHabitFertilizerTypeById(FertilizingHabitId, FertilizerTypeId);

            if (fertilizingHabitFertilizerType == null)
            {
                return NotFound();
            }

            await fertilizerTypesRepository.DeleteFertilizingHabitFertilizerType(fertilizingHabitFertilizerType);

            return NoContent();
        }
    }
}
