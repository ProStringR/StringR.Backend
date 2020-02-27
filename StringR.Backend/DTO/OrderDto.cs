using System.Data;
using Newtonsoft.Json.Linq;
using StringR.Backend.DTO.Order;

namespace StringR.Backend.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public long DeliveryDate { get; set; }
        public double TensionVertical { get; set; }
        public double TensionHorizontal { get; set; }
        public OrderCustomerDto Customer { get; set; }
        public OrderStringerDto Stringer { get; set; }
        public RacketDto Racket { get; set; }
        public OrderRacketStringDto OrderRacketString { get; set; }

        public OrderDto(DataRow row)
        {
            Id = (int) row["orderId"];
            OrderStatus = (int) row["orderStatus"];
            Comment = row["comment"].ToString();
            Price = (double) row["price"];
            DeliveryDate = (long) row["deliveryDate"];
            TensionVertical = (double) row["tensionVertical"];
            TensionHorizontal = (double) row["tensionHorizontal"];
            
            Customer = new OrderCustomerDto(row["customerFirstName"].ToString(), row["customerLastName"].ToString(), row["customerEmail"].ToString(), row["customerPhone"].ToString());
            Stringer = new OrderStringerDto(row["stringerFirstName"].ToString(), row["stringerLastName"].ToString(), row["stringerPhone"].ToString(), row["stringerEmail"].ToString());
            Racket = new RacketDto((int)row["racketId"], row["racketBrand"].ToString(), row["racketModel"].ToString(), (int) row["racketWeight"], (int) row["Racketmain"], (int) row["Racketcross"], (int) row["racketGripSize"]);
            OrderRacketString = new OrderRacketStringDto((int) row["stringId"], row["stringBrand"].ToString(), row["stringModel"].ToString(), row["stringType"].ToString(), row["stringThickness"].ToString(), row["stringPurpose"].ToString(), row["stringColor"].ToString());
        }
    }
}