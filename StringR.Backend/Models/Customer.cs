namespace StringR.Backend.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int PreferredStringTypeId { get; set; }
        public double PreferredTensionVertical { get; set; }
        public double PreferredTensionHorizontal { get; set; }

        public Customer(string firstName, string lastName, string email, string phoneNumber, string userId, string password, int preferredStringTypeId, double preferredTensionVertical, double preferredTensionHorizontal)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            UserId = userId;
            Password = password;
            PreferredStringTypeId = preferredStringTypeId;
            PreferredTensionVertical = preferredTensionVertical;
            PreferredTensionHorizontal = preferredTensionHorizontal;
        }
    }
}