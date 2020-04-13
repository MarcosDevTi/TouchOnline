using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Tracking
{
    public class GetTrackingsLastMinute : IQuery<IEnumerable<Visitor>>
    {
    }
}
