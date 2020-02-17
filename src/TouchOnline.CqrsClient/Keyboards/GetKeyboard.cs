using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class GetKeyboard : IQuery<KeyboardViewModel>
    {
        public GetKeyboard()
        {
            Default = true;
        }
        public GetKeyboard(Guid? keyboardId = null)
        {
            KeyboardId = keyboardId;
        }

        public GetKeyboard(string languageCode = null)
        {
            LanguageCode = languageCode;
        }

        public Guid? KeyboardId { get; set; }
        public string LanguageCode { get; set; }
        public Boolean Default { get; set; }
    }
}
