using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.Get
{
    public class ClassificationGetDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ClassificationType ClassificationType { get; set; }

    }
}
