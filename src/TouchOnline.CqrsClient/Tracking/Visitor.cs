using System;

namespace TouchOnline.CqrsClient.Tracking
{
    public class Visitor
    {
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string LanguageSystem { get; set; }
        public string LanguageBrowser { get; set; }
        public string KeyboardName { get; set; }
        public int PagesCount { get; set; }
        public int ResultCount { get; set; }
        public DateTime? DateCreateUser { get; set; }
        public DateTime? FirstLessonDate { get; set; }
        public DateTime? LastLessonDate { get; set; }
        public int? CountResultsForUser { get; set; }
        public string UrlSite { get; set; }
    }
}
