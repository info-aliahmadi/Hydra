using Hangfire;

namespace Hydra.Infrastructure.Scheduler.Service
{
    public class ScheduleService : IScheduleService
    {
        /// <summary>
        /// every specific time
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="action"></param>
        /// <param name="dateTime"></param>
        public void StartSchedule(string scheduleName, Action action)
        {
            RecurringJob.AddOrUpdate(
                        scheduleName,
                        () => action.Invoke(),
                        Cron.Daily);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleName"></param>
        public void StopSchedule(string scheduleName)
        {
            RecurringJob.RemoveIfExists(scheduleName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dateTime"></param>
        public void StartSchedule(Action action, DateTime dateTime)
        {
            BackgroundJob.Schedule(() => action.Invoke(), dateTime);
        }
    }
}
