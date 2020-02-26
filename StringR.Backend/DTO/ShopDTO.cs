using System.Data;

namespace StringR.Backend.DTO
{
    public class ShopDto
    {
        public int Id { get; }
        public int TeamId { get; }
        public string PhoneNumber { get; }
        public AddressDto Address { get; }

        public ShopDto(DataRow row)
        {
            Id = (int) row["shopId"];
            TeamId = (int) row["teamId"];
            PhoneNumber = row["phoneNumber"].ToString();

            var addressDto = new AddressDto(
                row["zipCode"].ToString(),
                row["city"].ToString(),
                row["country"].ToString(),
                (double) row["longitude"],
                (double) row["latitude"],
                row["street"].ToString(),
                row["addressNumber"].ToString());
            
            Address = addressDto;
        }
    }
}
