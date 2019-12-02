namespace StringR.Backend.Models
{
    public class Shop
    {
        public string ShopName { get; }
        public string ZipCode { get; }
        public string City { get; }
        public string Country { get; }
        public double Longitude { get; }
        public double Latitude { get; }
        public string Street { get; }
        public string AddressNumber { get; }
        public string PhoneNumber { get; }
        public string UserId { get; }
        public string Password { get; }

        public Shop(string shopName, string zipCode, string city, string country, double longitude, double latitude, string street, string addressNumber, string phoneNumber, string userId, string password)
        {
            ShopName = shopName;
            ZipCode = zipCode;
            City = city;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
            Street = street;
            AddressNumber = addressNumber;
            PhoneNumber = phoneNumber;
            UserId = userId;
            Password = password;
        }
    }
}