using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class KeyboardForUpdate : ICommand
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public bool Status { get; set; }
    }
}
