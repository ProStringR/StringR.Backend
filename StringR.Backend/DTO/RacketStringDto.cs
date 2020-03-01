using System.Collections.Generic;

namespace StringR.Backend.DTO
{
    public class RacketStringDto
    {
        public int StringId { get; set; }
        public double Price { get; set; }
        public double LengthInStock { get; set; }
        public string StringModel { get; set; }
        public string StringType { get; set; }
        public string StringBrand { get; set; }
        public double StringThickness { get; set; }
        public string StringPurpose { get; set; }
        public string StringColor { get; set; }
        public List<StringPurchaseHistoryDto> PurchaseHistory { get; set; }
    }
}