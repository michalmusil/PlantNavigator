using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.Post
{
    public class ClassificationPostDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ClassificationType ClassificationType { get; set; }
    }
}
