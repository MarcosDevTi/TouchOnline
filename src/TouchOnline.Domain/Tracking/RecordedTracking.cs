using System;

namespace TouchOnline.Domain.UserTracking
{
    public class RecordedTracking: Entity
    {
        public RecordedTracking()
        {
             SetId(Id);
        }
        public string VisitedPages { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public string Ip {get;set;}
    }
}