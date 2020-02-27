namespace StringR.Backend.DTO.Order
{
    /// <summary>
    /// This class is used for OrderDTO
    /// It is very specific to that and should
    /// not be used for other purposes
    /// </summary>
    public class OrderStringerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public OrderStringerDto(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}