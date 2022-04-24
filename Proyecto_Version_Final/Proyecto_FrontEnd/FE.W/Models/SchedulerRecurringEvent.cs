using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class SchedulerRecurringEvent
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EventPid { get; set; }
        public string RecType { get; set; }
        public double? EventLength { get; set; }
    }
}
