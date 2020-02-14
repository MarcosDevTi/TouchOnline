using System;

namespace TouchOnline.Domain
{
    public class MyText : Entity
    {
        public int CodeLesson { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}