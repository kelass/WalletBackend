using Quartz;
using WalletBackend.Data.Models.DailyPoints;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.Services.Schedules.Jobs
{
    public class DailyPointSchedule : IJob
    {
        private readonly IDailyPointManager _dailyPointManager;
        public DailyPointSchedule(IDailyPointManager dailyPointManager)
        {
            _dailyPointManager = dailyPointManager;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            IEnumerable<DailyPoint> dailyPoints = await _dailyPointManager.GetAll();

            foreach (var dailyPoint in dailyPoints)
            {
                await _dailyPointManager.SetDailyPoint(dailyPoint.UserId);
            }
        }
    }
}
