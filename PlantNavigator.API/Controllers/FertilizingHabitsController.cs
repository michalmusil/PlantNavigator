using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.FertilizingHabit;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/fertilizingHabits")]
    public class FertilizingHabitsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IFertilizingHabitsRepository fertilizingHabitsRepository;

        public FertilizingHabitsController(ILogger<FertilizingHabitsController> logger,
            IFertilizingHabitsRepository fertilizingHabitsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.fertilizingHabitsRepository = fertilizingHabitsRepository ??
                throw new ArgumentNullException(nameof(fertilizingHabitsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetFertilizingHabits")]
        public async Task<ActionResult<IEnumerable<FertilizingHabitGetDto>>> GetFertilizingHabits([FromQuery] int? plantId, [FromQuery] bool? includeAsociatedPlants)
        {
            var habits = await fertilizingHabitsRepository.GetAll(plantId, includeAsociatedPlants);
            return Ok(mapper.Map<IEnumerable<FertilizingHabitGetDto>>(habits));
        }

        [HttpGet("{id}", Name = "GetFertilizingHabitById")]
        public async Task<ActionResult<FertilizingHabitGetDto>> GetFertilizingHabitById(int id)
        {
            var fertilizingHabit = await fertilizingHabitsRepository.GetById(id);

            if (fertilizingHabit == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FertilizingHabitGetDto>(fertilizingHabit));
        }



        [HttpPost(Name = "PostFertilizingHabit")]
        public async Task<ActionResult> PostFertilizingHabit(FertilizingHabitPostDto fertilizingHabit)
        {
            FertilizingHabit fertilizingHabitToAdd = null;
            try
            {
                fertilizingHabitToAdd = mapper.Map<FertilizingHabit>(fertilizingHabit);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User FertilizingHabit post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await fertilizingHabitsRepository.AddFertilizingHabit(fertilizingHabitToAdd);

            return CreatedAtRoute("GetFertilizingHabitById",
                new
                {
                    id = fertilizingHabitToAdd.Id
                }, mapper.Map<FertilizingHabitGetDto>(fertilizingHabitToAdd));
        }

        [HttpPut("{id}", Name = "UpdateFertilizingHabit")]
        public async Task<ActionResult> UpdateFertilizingHabit(int id, FertilizingHabitPutDto fertilizingHabit)
        {
            var foundFertilizingHabit = await fertilizingHabitsRepository.GetById(id);

            if (foundFertilizingHabit == null)
            {
                return NotFound();
            }

            mapper.Map(fertilizingHabit, foundFertilizingHabit);
            fertilizingHabitsRepository.UpdateFertilizingHabit(foundFertilizingHabit);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteFertilizingHabitById")]
        public async Task<ActionResult> DeleteFertilizingHabitById(int id)
        {
            var fertilizingHabit = await fertilizingHabitsRepository.GetById(id);

            if (fertilizingHabit == null)
            {
                return NotFound();
            }

            await fertilizingHabitsRepository.DeleteFertilizingHabit(fertilizingHabit);

            return NoContent();
        }







        // PLANT TO FERTILIZNG HABIT realted endpoints
        [HttpPost("plantFertilizingHabit", Name = "PostPlantFertilizingHabit")]
        public async Task<ActionResult> PostPlantFertilizingHabit(Plant_FertilizingHabitPostDto joining)
        {
            if (!await fertilizingHabitsRepository.PlantExists(joining.PlantId))
            {
                return NotFound();
            }

            if (!await fertilizingHabitsRepository.FertilizingHabitExists(joining.FertilizingHabitId))
            {
                return NotFound();
            }

            try
            {
                var joinToAdd = mapper.Map<Plant_FertilizingHabit>(joining);
                await fertilizingHabitsRepository.AddPlantFertilizingHabitJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("plantFertilizingHabit", Name = "DeletePlantFertilizingHabitById")]
        public async Task<ActionResult> DeletePlantFertilizingHabitById([FromQuery] int plantId, [FromQuery] int fertilizingHabitId)
        {
            var plantFertilizingHabit = await fertilizingHabitsRepository.GetPlantFertilizingHabitById(plantId, fertilizingHabitId);

            if (plantFertilizingHabit == null)
            {
                return NotFound();
            }

            await fertilizingHabitsRepository.DeletePlantFertilizingHabit(plantFertilizingHabit);

            return NoContent();
        }

    }
}
