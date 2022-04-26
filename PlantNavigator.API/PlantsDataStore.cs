using PlantNavigator.API.Models;

namespace PlantNavigator.API
{
    public class PlantsDataStore
    {

        public static PlantsDataStore instance;

        public static PlantsDataStore getDataStore()
        {
            if (instance == null)
            { 
                instance = new PlantsDataStore(); 
            }

            return instance;
        }



        public IEnumerable<PlantDto> DummyData { get; set; }

        private PlantsDataStore() 
        { 
            this.DummyData = new List<PlantDto>()
            {
                new PlantDto { Id = 1,Species = "Aloe Ferox", Description = "asdfadsfadsf"},
                new PlantDto { Id = 2,Species = "Yucca"},
                new PlantDto{ Id = 3, Species = "Bonga Bonga", Description = "Nemam takovouto rostlinku:d"}
            };
        }

    }
}
