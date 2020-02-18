using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Tracking
{
    public class GetTrackings : IQuery<IEnumerable<SaveTracking>>
    {
        public DateTime InitialDate { get; set; }
        public DateTime LimitDate { get; set; }
    }
}
