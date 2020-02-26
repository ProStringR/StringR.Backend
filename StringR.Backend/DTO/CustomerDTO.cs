namespace StringR.Backend.DTO
{
    public class CustomerDTO
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string preferredStringType { get; set; }
        public double preferredTensionVertical { get; set; }
        public double preferredTensionHorizontal { get; set; }
    }
}