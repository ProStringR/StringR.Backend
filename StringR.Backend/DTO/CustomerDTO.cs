namespace StringR.Backend.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredStringType { get; set; }
        public double PreferredTensionVertical { get; set; }
        public double PreferredTensionHorizontal { get; set; }
    }
}