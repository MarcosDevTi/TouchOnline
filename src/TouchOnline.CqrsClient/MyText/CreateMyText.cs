using System;
using System.Collections.Generic;
using System.Text;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.MyText
{
    public class CreateMyText: ICommand
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
