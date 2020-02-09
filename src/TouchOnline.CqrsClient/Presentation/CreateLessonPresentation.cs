
using TouchOnline.CqrsClient.Contracts;

namespace DigiteMais.Cqrs.Client.Presentation
{
    public class CreateLessonPresentation: ICommand
    {
        public int IdLesson { get; set; }
        public string Name { get; set; }
        public string LessonText { get; set; }
    }
}