using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class GetKeyboardForUpdate : IQuery<KeyboardForUpdate>
    {
        public Guid Id { get; set; }
    }
}
