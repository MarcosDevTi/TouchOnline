using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetMyTexts : IQuery<IEnumerable<Domain.MyText>>
    {
    }
}
