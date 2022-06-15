namespace PlantNavigator.API.Models.DTOs.WateringCondition
{
    public class WateringIntensityGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WateringIntensityGetDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
