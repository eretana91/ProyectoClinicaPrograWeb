using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class SchedulerRecurringEvent
    {
        public SchedulerRecurringEvent()
        {
            
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EventPid { get; set; }
        public string RecType { get; set; }
        public double? EventLength { get; set; }


    }
}
