using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Models;
using PlantNavigator.API.Models.Post;
using PlantNavigator.API.Models.Put;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/plants")]
    public class PlantsController : ControllerBase
    {

        private PlantsDataStore dataStore = PlantsDataStore.getDataStore();



        [HttpGet(Name = "GetPlants")]
        public ActionResult<IEnumerable<PlantDto>> GetPlants()
        {
            return Ok(this.dataStore.DummyData);
        }

        [HttpGet("{id}", Name = "GetPlantById")]
        public ActionResult<PlantDto> GetPlant(int id)
        {
            var plant = this.dataStore.DummyData.FirstOrDefault((plant) => plant.Id == id);

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        [HttpPost(Name = "PostPlant")]
        public ActionResult<PlantDto> AddPlant(PlantPostDto plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int newPlantID = this.dataStore.DummyData.Max(p => p.Id);

            var newPlant = new PlantDto()
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

            //ADJUSTTHIS AFTER IMPLEMENTING DB
            var tempList = this.dataStore.DummyData.ToList();
            tempList.Remove(foundPlant);
            this.dataStore.DummyData = tempList;

            return NoContent();
        }
    }
}
