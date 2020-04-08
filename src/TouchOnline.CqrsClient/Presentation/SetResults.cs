using DigiteMais.Cqrs.Client.Presentation;
using System;
using System.Collections.Generic;
using System.Text;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Presentation
{
    public class SetResults: ICommand
    {
        public IEnumerable<SetResult> Results { get; set; }
        public string Email { get; set; }
    }
}
