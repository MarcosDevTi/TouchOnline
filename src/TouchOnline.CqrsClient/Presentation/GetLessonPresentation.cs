using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Presentation
{
    public class GetLessonPresentation: IQuery<LessonPresentationApp>
    {
        public int IdLesson { get; set; }
    }
}