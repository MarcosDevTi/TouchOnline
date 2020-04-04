using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.LessonText
{
    public class GetLessonTextById : IQuery<Domain.LessonText>
    {
        public Guid Id { get; set; }
        public GetLessonTextById(Guid id) => Id = id;
    }
}
