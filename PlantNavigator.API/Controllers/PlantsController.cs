using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.Get;
using PlantNavigator.API.Models.DTOs.Post;
using PlantNavigator.API.Repositories;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/plants")]
    public class PlantsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<PlantsController> logger;
        private readonly IPlantsRepository plantsRepository;

        public PlantsController(ILogger<PlantsController> logger, IPlantsRepository plantsRepository, IMapper mapper)
        {
            this.logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            this.plantsRepository = plantsRepository ??
                throw new ArgumentNullException(nameof(plantsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }



        [HttpGet(Name = "GetPlants")]
        public async Task<ActionResult<IEnumerable<PlantGetDto>>> GetPlants()
        {
            var plants = await plantsRepository.GetAll();
            return Ok(mapper.Map<IEnumerable<PlantGetDto>>(plants));
        }

        [HttpDelete("{id}", Name = "DeletePlantById")]
        public async Task<ActionResult> DeletePlantById(int id)
        {
            var plant = await plantsRepository.GetById(id);

            if (plant == null)
            {
                return NotFound();
            }

            await plantsRepository.DeletePlant(plant);

            return NoContent();
        }


        /*
        [HttpGet("{id}", Name = "GetPlantById")]
        public ActionResult<PlantGetDto> GetPlant(int id)
        {
            var plant = this.dataStore.DummyData.FirstOrDefault((plant) => plant.Id == id);

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        [HttpPost(Name = "PostPlant")]
        public ActionResult<PlantGetDto> AddPlant(PlantPostDto plant)
        {
            if (!ModelState.IsValid)
            {
                logger.LogInformation("Posted plant does not comply with the data restrictions");
                return BadRequest();
            }

            int newPlantID = this.dataStore.DummyData.Max(p => p.Id);

            var newPlant = new PlantGetDto()
            {
                Id = ++newPlantID,
                Species = plant.Species,
                Description = plant.Description
            };

            //ADJUST THIS AFTER IMPLEMENTING DB
            var tempList = this.dataStore.DummyData.ToList();
            tempList.Add(newPlant);
            this.dataStore.DummyData = tempList;

            return CreatedAtRoute("GetPlantById", new
            {
                id = newPlant.Id
            }, newPlant);
        }

        [HttpPut("{id}", Name ="UpdatePlant")]
        public ActionResult UpdatePlant(int id, PlantPutDto plantUpdate) 
        {
            var plant = this.dataStore.DummyData.FirstOrDefault(x => x.Id == id);

            if (plant == null)
            { 
                return NotFound();
            }

            //ADJUST THIS AFTER IMPLEMENTING DB
            plant.Species = plantUpdate.Species ?? plant.Species;
            plant.Description = plantUpdate.Description ?? plant.Description;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePlant")]
        public ActionResult DeletePlant(int id) 
        {
            var foundPlant = this.dataStore.DummyData.FirstOrDefault(x => x.Id == id);

            if(foundPlant is null)
            {
                return NotFound();
            }

            logger.LogInformation($"Plant with id: {foundPlant.Id} has been deleted");
            //ADJUSTTHIS AFTER IMPLEMENTING DB
            var tempList = this.dataStore.DummyData.ToList();
            tempList.Remove(foundPlant);
            this.dataStore.DummyData = tempList;

            return NoContent();
        }
        */
    }
}
