using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.MyText
{
    public class GetMyText : IQuery<MyTextViewModel>
    {
        public GetMyText(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
