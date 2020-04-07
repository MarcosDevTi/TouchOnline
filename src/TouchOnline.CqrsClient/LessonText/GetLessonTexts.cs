using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain.Enums;

namespace TouchOnline.CqrsClient.LessonText
{
    public class GetLessonTexts : IQuery<IEnumerable<Domain.LessonText>>
    {
        public Guid UserId { get; set; }
        public Level Level { get; set; }
        public Language Language { get; set; }
    }
}
