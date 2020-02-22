using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Management
{
    public class GetUsers : IQuery<IEnumerable<UserViewModelManagement>>
    {
    }
}
