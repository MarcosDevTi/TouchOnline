using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Tracking
{
    public class SaveTracking: ICommand
    {
        public string VisitedPages { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public string Ip {get;set;}
    }
}