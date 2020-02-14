using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Presentation
{
    public class GetLessonsPresentationList : IQuery<IReadOnlyList<LessonPresentationItem>>
    {
        public Guid UserId { get; set; }
        public string Level { get; set; }
    }
}