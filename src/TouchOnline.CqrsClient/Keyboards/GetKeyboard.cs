using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class GetKeyboardById : IQuery<KeyboardViewModel>
    {
        public Guid? Id { get; set; }
    }

    public class GetKeyboardByLangCode : IQuery<KeyboardViewModel>
    {
        public string LanguageCode { get; set; }
    }
}
