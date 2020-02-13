using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class GetKeyboard : IQuery<KeyboardViewModel>
    {
        public GetKeyboard(Guid? keyboardId)
        {
            KeyboardId = keyboardId;
        }
        public Guid? KeyboardId { get; set; }
    }
}
