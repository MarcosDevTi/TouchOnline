

using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetKeyboards : IQuery<IEnumerable<Domain.Keyboard>>
    {
    }
}
