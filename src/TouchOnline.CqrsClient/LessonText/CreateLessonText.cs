using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain.Enums;

namespace TouchOnline.CqrsClient.LessonText
{
    public class CreateLessonText : ICommand
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Level Level { get; set; }
        public Language Language { get; set; }
        public int Order { get; set; }
    }
}
