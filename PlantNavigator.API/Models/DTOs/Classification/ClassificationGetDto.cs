using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.Classification
{
    public class ClassificationGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ClassificationType ClassificationType { get; set; }

    }
}
