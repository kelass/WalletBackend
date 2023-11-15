using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models.Identity;
using WalletBackend.Domain.Models.Transactions;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionManager _transactionManager;
        private readonly UserManager<WalletUser> _userManager;
        public TransactionController(ITransactionManager transactionManager, UserManager<WalletUser> userManager)
        {
            _transactionManager = transactionManager;
            _userManager = userManager;

        }

        [Authorize]
        [HttpGet("get-transactions")]
        public async Task<IEnumerable<AuthorizeTransaction>> GetAuthorizeTransaction([FromQuery] Guid userId)
        {
            WalletUser user = await _userManager.Users.FirstOrDefaultAsync(user=>user.Id == userId);
            if (user != null)
               return await _transactionManager.GetUserTransactions(userId); 

            return Enumerable.Empty<AuthorizeTransaction>();
        }

        [Authorize]
        [HttpPost("create-transaction")]
        public async Task<bool> CreateTransaction()
            => true;
        
    }
}
