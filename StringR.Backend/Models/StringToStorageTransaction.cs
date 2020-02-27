using System.ComponentModel.DataAnnotations;

namespace StringR.Backend.Models
{
    public class StringToStorageTransaction
    {
        [Required] public int StringId { get; }
        public double Price { get; set; }
        public long TransactionDate { get; set; }
        public int LengthAdded { get; set; }

        public StringToStorageTransaction(int stringId, double price, long transactionDate, int lengthAdded)
        {
            StringId = stringId;
            Price = price;
            TransactionDate = transactionDate;
            LengthAdded = lengthAdded;
        }
    }
}