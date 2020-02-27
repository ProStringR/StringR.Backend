namespace StringR.Backend.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public int StringerId { get; set; }
        public int ShopId { get; set; }
        public string RacketModel { get; set; }
        public int RacketBrand { get; set; }
        public double TensionVertical { get; set; }
        public double TensionHorizontal { get; set; }
        public int StringId { get; set; }
        public long DeliveryDate { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public long DatePlaced { get; set; }

        public Order(
            int customerId, 
            int stringerId, 
            int shopId, 
            string racketModel, 
            int racketBrand, 
            double tensionVertical, 
            double tensionHorizontal, 
            int stringId, 
            long deliveryDate, 
            double price, 
            string comment, 
            long datePlaced)
        {
            this.CustomerId = customerId;
            this.StringerId = stringerId;
            this.ShopId = shopId;
            this.RacketModel = racketModel;
            this.RacketBrand = racketBrand;
            this.TensionVertical = tensionVertical;
            this.TensionHorizontal = tensionHorizontal;
            this.StringId = stringId;
            this.DeliveryDate = deliveryDate;
            this.Price = price;
            this.Comment = comment;
            this.DatePlaced = datePlaced;
        }
    }
}