using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class GetKeyboardsManagement : IQuery<IEnumerable<KeyboardForUpdate>>
    {
    }
}
