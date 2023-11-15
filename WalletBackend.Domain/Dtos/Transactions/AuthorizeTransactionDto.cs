using System.ComponentModel.DataAnnotations;
using WalletBackend.Domain.Enums;

namespace WalletBackend.Domain.Dtos.Transactions
{
    public class AuthorizeTransactionDto
    {
        public TransactionType Type { get; set; }
        [Range(1,1500)]
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TransactionStatus Status { get; set; }
        public Guid BillId { get; set; }
        public Guid UserId { get; set; }
    }
}
