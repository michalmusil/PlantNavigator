namespace PlantNavigator.API.Models.DTOs.PlantImage
{
    public class PlantImageGetDto
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public string ImageName { get; set; }
    }
}
