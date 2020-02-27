namespace StringR.Backend.DTO
{
    public class AddressDto
    {
        public string ZipCode { get; }
        public string City { get; }
        public string Country { get; }
        public double Longitude { get; }
        public double Latitude { get; }
        public string Street { get; }
        public string AddressNumber { get; }
        
        public AddressDto(string zipCode, string city, string country, double longitude, double latitude, string street, string addressNumber)
        {
            ZipCode = zipCode;
            City = city;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
            Street = street;
            AddressNumber = addressNumber;
        }
    }
}