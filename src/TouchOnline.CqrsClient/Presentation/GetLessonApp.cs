using System;
using System.Threading.Tasks;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Presentation
{
    public class GetLessonApp: IQuery<Task<LessonPresentationApp>>
    {
        public Guid Id { get; set; }
    }
}