namespace StringR.Backend.DTO.Order
{
    /// <summary>
    /// This class is used for OrderDTO
    /// It is very specific to that and should
    /// not be used for other purposes
    /// </summary>
    public class OrderRacketStringDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Thickness { get; set; }
        public string Purpose { get; set; }
        public string Color { get; set; }

        public OrderRacketStringDto(int id, string brand, string model, string type, string thickness, string purpose, string color)
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