using System;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DAO;

namespace StringR.Backend.DataController
{
    public class OrderDataController : OrderDataInterface
    {
        private OrderDAO _orderDAO;
        
        public OrderDataController(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public string GetAllOrdersForShop(int shopId)
        {
            DataSet dataSet;
            var generalObject = new JArray();
            
            try
            {
                dataSet = _orderDAO.GetAllOrdersForShop(shopId);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var order = new JObject();
                    
                    order.Add("id", (int) row["orderId"]);
                    order.Add("orderStatus", (int) row["orderStatus"]);
                    order.Add("comment", row["comment"].ToString());
                    order.Add("price", (double) row["price"]);
                    order.Add("deliveryDate", (long) row["deliveryDate"]);
                    order.Add("tensionVertical", (double) row["tensionVertical"]);
                    order.Add("tensionHorizontal", (double) row["tensionHorizontal"]);
                    
                    // customer construction
                    var customer = new JObject();
                    customer.Add("firstName", row["customerFirstName"].ToString());
                    customer.Add("lastName", row["customerLastName"].ToString());
                    customer.Add("email", row["customerEmail"].ToString());
                    customer.Add("phone", row["customerPhone"].ToString());
                    
                    var customerProperty = new JProperty("customer", customer);
                    
                    // stringer construction
                    var stringer = new JObject();
                    stringer.Add("firstName", row["stringerFirstName"].ToString());
                    stringer.Add("lastName", row["stringerLastName"].ToString());
                    stringer.Add("phone", row["stringerPhone"].ToString());
                    stringer.Add("email", row["stringerEmail"].ToString());
                    
                    var stringerProperty = new JProperty("stringer", customer);
                    
                    // racket construction
                    var racket = new JObject();
                    racket.Add("id", (int)row["racketId"]);
                    racket.Add("brand", row["racketBrand"].ToString());
                    racket.Add("model", row["racketModel"].ToString());
                    racket.Add("weight", (int) row["racketWeight"]);
                    racket.Add("main", (int) row["Racketmain"]);
                    racket.Add("cross", (int) row["Racketcross"]);
                    racket.Add("gripSize", (int) row["racketGripSize"]);
                    
                    var racketProperty = new JProperty("racket", racket);
                    
                   
                    // string construction
                    var racketString = new JObject();
                    racketString.Add("id", (int) row["stringId"]);
                    racketString.Add("brand", row["stringBrand"].ToString());
                    racketString.Add("model", row["stringModel"].ToString());
                    racketString.Add("type", row["stringType"].ToString());
                    racketString.Add("thickness", row["stringThickness"].ToString());
                    racketString.Add("purpose", row["stringPurpose"].ToString());
                    racketString.Add("color", row["stringColor"].ToString());
                    
                    var racketStringProperty = new JProperty("racketString", racket);
                   
                    // adding properties to the generel order object
                    order.Add(customerProperty);
                    order.Add(stringerProperty);
                    order.Add(racketProperty);
                    order.Add(racketStringProperty);
                    
                    // adding order to array of orders
                    generalObject.Add(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return generalObject.ToString(Formatting.None);
        }
    }
}