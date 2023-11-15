using WalletBackend.Data.Models;
using WalletBackend.Domain.Enums;

namespace WalletBackend.Domain.Models.Transactions
{
    public class AuthorizeTransaction:BaseEntity
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TransactionStatus Status { get; set; }
        public Guid UserId { get; set; }
    }
}
