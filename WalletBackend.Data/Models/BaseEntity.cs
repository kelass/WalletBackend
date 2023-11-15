using WalletBackend.Data.Interfaces;

namespace WalletBackend.Data.Models
{
    public abstract class BaseEntity:IEntity
    {
        public Guid Id { get; set; }
    }
}
