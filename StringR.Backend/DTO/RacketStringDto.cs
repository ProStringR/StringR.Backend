namespace StringR.Backend.DTO
{
    public class RacketStringDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Thickness { get; set; }
        public string Purpose { get; set; }
        public string Color { get; set; }

        public RacketStringDto(int id, string brand, string model, string type, string thickness, string purpose, string color)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Type = type;
            Thickness = thickness;
            Purpose = purpose;
            Color = color;
        }
    }
}