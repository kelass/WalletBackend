using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletBackend.Domain.Static;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.API.Controllers
{
    [Authorize]
    [Route("api/daily-points")]
    [ApiController]
    public class DailyPointController : ControllerBase
    {
        private readonly IDailyPointManager _dailyPointManager;
        public DailyPointController(IDailyPointManager dailyPointManager)
        {
            _dailyPointManager = dailyPointManager;
        }

        [HttpGet]
        public async Task<string> GetPoints(Guid userId)
        {
            decimal points = await _dailyPointManager.GetPointsByUserId(userId);
            return NumberExtension.CountCalculate(points);
        }


    }
}
