using System;
using TouchOnline.Domain.Tracking;

namespace TouchOnline.Domain.UserTracking
{
    public class RecordedTracking: Entity
    {
        public string VisitedPages { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public UserLocal UserLocal {get;set;}
    }
}