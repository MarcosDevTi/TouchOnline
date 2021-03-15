using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetMessageSupports : IQuery<IEnumerable<MessageSupport>>
    {
    }
}
