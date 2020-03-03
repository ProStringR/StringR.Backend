using System.ComponentModel.DataAnnotations;

namespace StringR.Backend.Models
{
    public class OrderTransaction
    {
        [Required] public int OrderId { get; set; }
        [Required] public long TransactionDate { get; set; }
        [Required] public bool Paid { get; set; }
        [Required] public int OrderStatus { get; set; }

        public OrderTransaction(int orderId, long transactionDate, bool paid, int orderStatus)
        {
            OrderId = orderId;
            TransactionDate = transactionDate;
            Paid = paid;
            OrderStatus = orderStatus;
        }
        
    }
}