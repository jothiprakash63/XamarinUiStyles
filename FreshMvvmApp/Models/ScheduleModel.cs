using System;
using System.Collections.Generic;
using System.Text;

namespace KantimeEvv.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientInitial { get; set; }
        public string ServiceName { get; set; }
        public string PlannedStartTime { get; set; }
        public string PlannedEndTime { get; set; }
        public string Address { get; set; }
        public string ChkinTime { get; set; }   
        public string ChkOutTime { get; set; }
        public bool IsEvv { get; set; }
        public string Gender { get; set; }
        public string PatientId { get; set; }
        public string TotalHours { get; set; }
        public string SchedleStatus { get; set; }
        public bool IsAdhoc { get; set; }
        public bool IsMisc { get; set; }
        public bool IsConfirmed { get; set; }

        public string DutiesPerformed { get; set; }

        public string Location { get; set; }
    }
}
