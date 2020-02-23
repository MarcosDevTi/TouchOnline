using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Presentation;

namespace TouchOnline.CqrsClient.MyText
{
    public class CreateMyText : IQuery<IEnumerable<LessonPresentationItem>>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
