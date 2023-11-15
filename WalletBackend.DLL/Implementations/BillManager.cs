using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Domain.Dtos.Bills;
using WalletBackend.Repositories.Interfaces;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.Services.Implementations
{
    public class BillManager : IBillManager
    {
        private readonly IBillRepository _repository;
        public BillManager(IBillRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateAsync(BillDto entity)
        {
            var managedBill = await _repository.GetAll().FirstOrDefaultAsync(b=>b.Id ==entity.Id);

            if (managedBill == null)
                return await _repository.AddAsync(new Bill { Id = entity.Id });

            return 0;
        }

        public async Task<Bill> GetById(Guid id)
        => await _repository.GetAll().FirstOrDefaultAsync(b=>b.Id == id);
    }
}
