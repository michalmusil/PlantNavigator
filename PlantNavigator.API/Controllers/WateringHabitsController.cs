using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.WateringHabit;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/wateringHabits")]
    public class WateringHabitsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IWateringHabitsRepository wateringHabitsRepository;

        public WateringHabitsController(ILogger<WateringHabitsController> logger,
            IWateringHabitsRepository wateringHabitsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.wateringHabitsRepository = wateringHabitsRepository ??
                throw new ArgumentNullException(nameof(wateringHabitsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetWateringHabits")]
        public async Task<ActionResult<IEnumerable<WateringHabitGetDto>>> GetWateringHabits([FromQuery] int? plantId, [FromQuery] bool? includeAsociatedPlants)
        {
            var habits = await wateringHabitsRepository.GetAll(plantId, includeAsociatedPlants);
            return Ok(mapper.Map<IEnumerable<WateringHabitGetDto>>(habits));
        }

        [HttpGet("{id}", Name = "GetWateringHabitById")]
        public async Task<ActionResult<WateringHabitGetDto>> GetWateringHabitById(int id)
        {
            var WateringHabit = await wateringHabitsRepository.GetById(id);

            if (WateringHabit == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WateringHabitGetDto>(WateringHabit));
        }



        [HttpPost(Name = "PostWateringHabit")]
        public async Task<ActionResult> PostWateringHabit(WateringHabitPostDto wateringHabit)
        {
            WateringHabit wateringHabitToAdd = null;
            try
            {
                wateringHabitToAdd = mapper.Map<WateringHabit>(wateringHabit);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User WateringHabit post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await wateringHabitsRepository.AddWateringHabit(wateringHabitToAdd);

            return CreatedAtRoute("GetWateringHabitById",
                new
                {
                    id = wateringHabitToAdd.Id
                }, mapper.Map<WateringHabitGetDto>(wateringHabitToAdd));
        }

        [HttpPut("{id}", Name = "UpdateWateringHabit")]
        public async Task<ActionResult> UpdateWateringHabit(int id, WateringHabitPutDto wateringHabit)
        {
            var foundWateringHabit = await wateringHabitsRepository.GetById(id);

            if (foundWateringHabit == null)
            {
                return NotFound();
            }

            mapper.Map(wateringHabit, foundWateringHabit);
            wateringHabitsRepository.UpdateWateringHabit(foundWateringHabit);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteWateringHabitById")]
        public async Task<ActionResult> DeleteWateringHabitById(int id)
        {
            var wateringHabit = await wateringHabitsRepository.GetById(id);

            if (wateringHabit == null)
            {
                return NotFound();
            }

            await wateringHabitsRepository.DeleteWateringHabit(wateringHabit);

            return NoContent();
        }







        // PLANT TO WATERING HABIT realted endpoints
        [HttpPost("plantWateringHabit", Name = "PostPlantWateringHabit")]
        public async Task<ActionResult> PostPlantWateringHabit(Plant_WateringHabitPostDto joining)
        {
            if (!await wateringHabitsRepository.PlantExists(joining.PlantId))
            {
                return NotFound();
            }

            if (!await wateringHabitsRepository.WateringHabitExists(joining.WateringHabitId))
            {
                return NotFound();
            }

            try
            {
                var joinToAdd = mapper.Map<Plant_WateringHabit>(joining);
                await wateringHabitsRepository.AddPlantWateringHabitJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("plantWateringHabit", Name = "DeletePlantWateringHabitById")]
        public async Task<ActionResult> DeletePlantWateringHabitById([FromQuery] int plantId, [FromQuery] int wateringHabitId)
        {
            var plantWateringHabit = await wateringHabitsRepository.GetPlantWateringHabitById(plantId, wateringHabitId);

            if (plantWateringHabit == null)
            {
                return NotFound();
            }

            await wateringHabitsRepository.DeletePlantWateringHabit(plantWateringHabit);

            return NoContent();
        }

    }
}

