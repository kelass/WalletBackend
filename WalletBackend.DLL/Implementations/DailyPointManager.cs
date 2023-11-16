using Microsoft.EntityFrameworkCore;
using WalletBackend.Data.Models.DailyPoints;
using WalletBackend.Repositories.Interfaces;
using WalletBackend.Services.Interfaces;

namespace WalletBackend.Services.Implementations
{
    public class DailyPointManager : IDailyPointManager
    {
        private readonly IDailyPointRepository _dailyPointRepository;
        private decimal procent = 0.60m;
        private Dictionary<int, Season> _seasons = new Dictionary<int, Season>
        {
            {12,Season.Winter},
            {1,Season.Winter},
            {2,Season.Winter},
            {3,Season.Spring},
            {4,Season.Spring},
            {5,Season.Spring},
            {6,Season.Summer},
            {7,Season.Summer},
            {8,Season.Summer},
            {9,Season.Autumn},
            {10,Season.Autumn},
            {11,Season.Autumn},
        };

        public DailyPointManager(IDailyPointRepository dailyPointRepository)
        {
            _dailyPointRepository = dailyPointRepository;
        }

        public async Task<IEnumerable<DailyPoint>> GetAll()
            => await _dailyPointRepository.GetAll().ToListAsync();

        public async Task SetDailyPoint(Guid userId)
        {
            DateTime currentDate = DateTime.UtcNow;
            int month = currentDate.Month;
            Season season = _seasons[month];
            int seasonStartMonth = GetMonthStartSeason(season);

            DateTime startSeasonDate = GetStartDate(currentDate.Year, seasonStartMonth);

            int days = GetDays(currentDate, startSeasonDate);
            decimal points = GetPoint(days);

            await AddAsync(userId, points);
        }

        private DateTime GetStartDate(int Year, int month)
        {
            if (month == 1 || month == 2)
                Year--;

            return new DateTime(Year, month, 1);
        }


        private int GetMonthStartSeason(Season season)
        => _seasons.FirstOrDefault(s => s.Value == season).Key;


        private int GetDays(DateTime currentDate, DateTime startSeasonDate)
        => (currentDate - startSeasonDate).Days;

        private decimal GetPoint(int days)
        {
            switch (days)
            {
                case 1: return 2;
                case 2: return 3;
                default:
                    {
                        decimal previous = 2;
                        decimal previous2 = 3;
                        decimal today = 0;
                        for (int day = 3; day < days; day++)
                        {
                            today = Math.Round(previous + previous2 * procent,1);
                            previous = previous2;
                            previous2 = today;
                        }
                        return today;
                    }
            }
        }

        public async Task<int> AddAsync(Guid userId, decimal points)
        {
            if (points == 0)
                return await _dailyPointRepository.AddAsync(new DailyPoint { Amount =0, UserId = userId, Date = DateTime.UtcNow});

            return await _dailyPointRepository.AddAsync(new DailyPoint { Amount = points, UserId = userId, Date = DateTime.UtcNow });
        }

        public async Task<decimal> GetPointsByUserId(Guid userId)
            => await _dailyPointRepository.GetAll().Where(dp => dp.UserId == userId).SumAsync(dp=>dp.Amount);

        private enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
    }
}
