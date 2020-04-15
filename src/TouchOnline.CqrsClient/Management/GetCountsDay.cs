using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Management
{
    public class GetCountsDay : IQuery<GeneralDay>
    {
        public DateTime DateStart { get; set; }
    }
}
