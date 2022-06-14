namespace PlantNavigator.API.Models.DTOs.Pest
{
    public class PestGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Plant_PestGetDto> Plant_Pests { get; set; }
    }
}
