using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.MyText
{
    public class GetMyTexts : IQuery<IEnumerable<MyTextViewModel>>
    {
        public GetMyTexts(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}
