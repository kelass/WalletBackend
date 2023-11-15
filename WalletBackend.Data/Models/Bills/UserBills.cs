namespace WalletBackend.Data.Models.Bills
{
    public class UserBills:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BillId { get; set; }
    }
}
