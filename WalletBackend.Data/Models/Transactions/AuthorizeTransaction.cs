
namespace WalletBackend.Domain.Models.Transactions
{
    public class AuthorizeTransaction:BaseTransaction
    {
        public Guid UserId { get; set; }
    }
}
