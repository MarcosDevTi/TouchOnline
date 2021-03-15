using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain.UserTracking;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetRecordeds : IQuery<IEnumerable<RecordedTracking>>
    {
    }
}
