namespace PlantNavigator.API.Models.DTOs.Get
{
    public class ClassificationTypeGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClassificationTypeGetDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
