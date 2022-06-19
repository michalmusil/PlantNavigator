using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Models.DTOs.Disease;
using PlantNavigator.API.Models.DTOs.FertilizingHabit;
using PlantNavigator.API.Models.DTOs.LightCondition;
using PlantNavigator.API.Models.DTOs.Pest;
using PlantNavigator.API.Models.DTOs.PlantImage;
using PlantNavigator.API.Models.DTOs.Soil;
using PlantNavigator.API.Models.DTOs.WateringCondition;
using PlantNavigator.API.Models.DTOs.WateringHabit;

namespace PlantNavigator.API.Models.DTOs.Plant
{
    public class PlantGetExtendedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Month? FloweringFrom { get; set; }
        public Month? FloweringTo { get; set; }
        public int? TemperatureFrom { get; set; }
        public int? TemperatureTo { get; set; }
        public bool? MistingAppropriate { get; set; }

        public WaterConditionGetDto? WaterCondition { get; set; }
        public LightConditionGetDto? LightCondition { get; set; }

        public List<DiseaseGetDto> Diseases { get; set; }
        public List<SoilGetDto> Soils { get; set; }
        public List<PestGetDto> Pests { get; set; }
        public List<WateringHabitGetDto> WateringHabits { get; set; }
        public List<FertilizingHabitGetDto> FertilizingHabits { get; set; }
        public List<PlantImageGetDto> PlantImages { get; set; }
    }
}
