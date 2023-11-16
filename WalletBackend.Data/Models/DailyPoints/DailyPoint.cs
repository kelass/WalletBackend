namespace WalletBackend.Data.Models.DailyPoints
{
    public class DailyPoint : BaseEntity
    {
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
