namespace PlantNavigator.API.Models.DTOs.LightCondition
{
    public class SunlightIntensityGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SunlightIntensityGetDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
