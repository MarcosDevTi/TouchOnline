using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Tracking
{
    public class SaveTracking : ICommand
    {
        public string VisitedPages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string LanguageKeyboard { get; set; }
        public string LanguageSystem { get; set; }
        public string LanguageBrowser { get; set; }
        public Guid? UserId { get; set; }
        public string Ip { get; set; }
        public Guid? KeyboradId { get; set; }
    }
}