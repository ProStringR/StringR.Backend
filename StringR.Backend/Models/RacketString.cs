namespace StringR.Backend.Models
{
    public class RacketString
    {
        public int ShopId { get; set; }
        public double Length { get; set; }
        public double PricePerRacket { get; set; }
        public string Model { get; set; }
        public int StringType { get; set; }
        public int Brand { get; set; }
        public double Thickness { get; set; }
        public int Purpose { get; set; }
        public int Color { get; set; }
        public double Price { get; set; }
        public long DatePlaced { get; set; }
    }
}