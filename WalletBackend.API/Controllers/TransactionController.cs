using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletBackend.API.Extensions;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Dtos.Transactions;
using WalletBackend.Domain.Models.Transactions;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;
        private readonly IBillManager _billManager;
        private readonly IUserBillManager _userBillManager;
        public TransactionController(ITransactionManager transactionManager, IBillManager billManager, IUserBillManager userBillManager)
        {
            _transactionManager = transactionManager;
            _billManager = billManager;
            _userBillManager = userBillManager;
        }

        /// <summary>
        /// Get last 10 transaction using bill id
        /// </summary>
        /// <param name="billId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-transactions")]
        public async Task<IEnumerable<AuthorizeTransaction>> GetAuthorizeTransaction([FromQuery] Guid billId)
        {
            Bill bill = await _billManager.GetById(billId);
            if (bill != null)
                return await _transactionManager.GetTransactions(billId, 10);

            return Enumerable.Empty<AuthorizeTransaction>();
        }

        /// <summary>
        /// Create transaction using AuthorizeTransactionDto 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("create-transaction")]
        public async Task<int> CreateTransaction(AuthorizeTransactionDto dto)
        {
            dto.UserId = User.GetUserId();

            if (await _userBillManager.GetUserBillByIds(dto.BillId, dto.UserId) != null)
                return await _transactionManager.AddTransaction(dto);

            return 0;
        }

    }
}
