using System;
using System.Collections.Generic;
using System.Text;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Support
{
    public class GetMessages: IQuery<IEnumerable<SendMessage>>
    {
    }
}
