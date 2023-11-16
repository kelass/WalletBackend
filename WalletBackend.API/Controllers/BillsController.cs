using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletBackend.API.Extensions;
using WalletBackend.Data.Models.Bills;
using WalletBackend.Domain.Dtos.Bills;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillManager _billManager;
        private readonly IUserBillManager _userBillManager;
        public BillsController(IBillManager billManager, IUserBillManager userBillManager)
        {
            _billManager = billManager;
            _userBillManager = userBillManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<bool> CreateBill()
        {
            BillDto bill = new BillDto { };
            var result = await _billManager.CreateAsync(bill);

            if (result == 1)
            {
                await _userBillManager.AddAsync(new UserBillDto { UserId = User.GetUserId(), BillId = bill.Id });
                return true;
            }
            return false;
        }

        [Authorize]
        [HttpPost("bind-user-bill")]
        public async Task<bool> BindUserToBill([FromBody] Guid billId)
        {
            Bill bill = await _billManager.GetById(billId);

            if(bill !=null)
            {
                await _userBillManager.AddAsync(new UserBillDto { UserId = User.GetUserId(), BillId = billId });
                return true;
            }
            return false;
        }

    }
}
