namespace StringR.Backend.Models
{
    public class Order
    {
        public int customerId { get; }
        public int stringerId { get; }
        public int shopId { get; }
        public string racketModel { get; }
        public int racketBrand { get; }
        public double tensionVertical { get; }
        public double tensionHorizontal { get; }
        public int stringId { get; }
        public long deliveryDate { get; }
        public double price { get; }
        public string comment { get; }
        public long datePlaced { get; }

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
            this.customerId = customerId;
            this.stringerId = stringerId;
            this.shopId = shopId;
            this.racketModel = racketModel;
            this.racketBrand = racketBrand;
            this.tensionVertical = tensionVertical;
            this.tensionHorizontal = tensionHorizontal;
            this.stringId = stringId;
            this.deliveryDate = deliveryDate;
            this.price = price;
            this.comment = comment;
            this.datePlaced = datePlaced;
        }
    }
}