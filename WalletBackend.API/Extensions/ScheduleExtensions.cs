using Quartz;
using WalletBackend.Services.Schedules.Jobs;

namespace WalletBackend.API.Extensions
{
    public static class ScheduleExtensions
    {
        public static IServiceCollection AddSchedule(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = new JobKey("DailyPoint");
                q.AddJob<DailyPointSchedule>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("DailyPoint-Schedule")
                .WithCronSchedule("0 0 9 ? * *"));
            });
            services.AddQuartzHostedService(opts => opts.WaitForJobsToComplete = true);
            return services;
        }

        public static async void ActiveScheduler(this IServiceProvider builder)
        {
            var scheduler = await builder.CreateScope().ServiceProvider.GetRequiredService<ISchedulerFactory>().GetScheduler();
            await scheduler.Start();
        }
    }
}
