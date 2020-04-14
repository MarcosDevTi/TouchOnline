using System;

namespace TouchOnline.Domain
{
    public class MessageSupport : Entity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}