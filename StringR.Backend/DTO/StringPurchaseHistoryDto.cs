namespace StringR.Backend.DTO
{
    public class StringPurchaseHistoryDto
    {
        public int Id { get; set; }
        public int RacketStringId { get; set; }
        public double Price { get; set; }
        public long TransactionDate { get; set; }
        public int LengthAdded { get; set; }
    }
}