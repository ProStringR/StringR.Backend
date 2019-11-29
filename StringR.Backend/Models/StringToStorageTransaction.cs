using System.ComponentModel.DataAnnotations;

namespace StringR.Backend.Models
{
    public class StringToStorageTransaction
    {
        [Required] public int StringId { get; }
        public double Price { get; }
        public long TransactionDate { get; }
        public int LengthAdded { get; }

        public StringToStorageTransaction(int stringId, double price, long transactionDate, int lengthAdded)
        {
            StringId = stringId;
            Price = price;
            TransactionDate = transactionDate;
            this.LengthAdded = lengthAdded;
        }
    }
}