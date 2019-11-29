namespace StringR.Backend.Models
{
    public class Customer
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string UserId { get; }
        public string Password { get; }
        public int PreferredStringTypeId { get; }
        public double PreferredTensionVertical { get; }
        public double PreferredTensionHorizontal { get; }

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