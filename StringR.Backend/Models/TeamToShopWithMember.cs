namespace StringR.Backend.Models
{
    public class TeamToShopWithMember
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public int PreferredRacketType { get; }
        public int ShopId { get; }

        public TeamToShopWithMember(string firstName, string lastName, string phoneNumber, string email, int preferredRacketType, int shopId)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            PreferredRacketType = preferredRacketType;
            ShopId = shopId;
        }
    }
}