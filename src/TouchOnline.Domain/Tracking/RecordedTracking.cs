using System;

namespace TouchOnline.Domain.UserTracking
{
    public class RecordedTracking : Entity
    {
        public RecordedTracking()
        {
            SetId(Id);
        }
        public string VisitedPages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
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