namespace StringR.Backend.DTO.Order
{
    public class OrderHistoryDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public bool Paid { get; set; }
        public long TransactionDate { get; set; }
        public int OrderStatus { get; set; }
    }
}