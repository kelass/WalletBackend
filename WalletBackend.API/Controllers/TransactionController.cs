using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletBackend.Domain.Models.Transactions;

namespace WalletBackend.API.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        [HttpGet("get-transactions")]
        public async Task<BaseTransaction> GetBaseTransaction()
            => null;

        [Authorize]
        [HttpGet("get-user-transactions/{userId:guid}")]
        public async Task<AuthorizeTransaction> GetAuthorizeTransaction(Guid userId)
            => null;
    }
}
