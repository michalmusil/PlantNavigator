namespace PlantNavigator.API.Models.DTOs.Disease
{
    public class DiseaseGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Plant_DiseaseGetDto> Plant_Diseases { get; set; }
    }
}
