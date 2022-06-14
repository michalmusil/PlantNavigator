namespace PlantNavigator.API.Models.DTOs.Soil
{
    public class SoilGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Plant_SoilGetDto> Plant_Soils { get; set; }
    }
}
