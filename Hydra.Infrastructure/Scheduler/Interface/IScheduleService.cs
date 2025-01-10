using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Infrastructure.Scheduler.Service
{
    public interface IScheduleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="action"></param>
        void StartSchedule(string scheduleName, Action action);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scheduleName"></param>
        void StopSchedule(string scheduleName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="dateTime"></param>
        void StartSchedule(Action action, DateTime dateTime);
    }
}
