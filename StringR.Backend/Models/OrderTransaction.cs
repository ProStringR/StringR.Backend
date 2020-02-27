using System.ComponentModel.DataAnnotations;

namespace StringR.Backend.Models
{
    public class OrderTransaction
    {
        [Required] public int OrderId { get; set; }
        [Required] public long TransactionDate { get; set; }
        [Required] public bool PaidStatus { get; set; }
        [Required] public int OrderStatus { get; set; }

        public OrderTransaction(int orderId, long transactionDate, bool paidStatus, int orderStatus)
        {
            OrderId = orderId;
            TransactionDate = transactionDate;
            PaidStatus = paidStatus;
            OrderStatus = orderStatus;
        }
        
    }
}