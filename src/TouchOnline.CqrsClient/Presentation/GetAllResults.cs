using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain;

namespace TouchOnline.CqrsClient.Presentation
{
    public class GetAllResults : IQuery<IReadOnlyList<Result>>
    {
    }
}
