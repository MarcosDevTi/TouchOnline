using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.LessonText
{
    public class DeleteLessonText : ICommand
    {
        public DeleteLessonText(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
