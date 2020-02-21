using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Support
{
    public class SendMessage: ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
    }
}