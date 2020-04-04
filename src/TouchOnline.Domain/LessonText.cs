using TouchOnline.Domain.Enums;

namespace TouchOnline.Domain
{
    public class LessonText : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Level Level { get; set; }
        public Language Language { get; set; }
        public int Order { get; set; }
    }
}
