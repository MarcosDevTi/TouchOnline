using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetUsers : IQuery<IEnumerable<Domain.User>>
    {
    }
}
