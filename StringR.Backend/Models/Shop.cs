namespace StringR.Backend.Models
{
    public class Shop
    {
        public string ShopName { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Street { get; set; }
        public string AddressNumber { get; set;  }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Shop(string shopName, string zipCode, string city, string country, double longitude, double latitude, string street, string addressNumber, string phoneNumber, string email, string password)
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
            Email = email;
            Password = password;
        }
    }
}