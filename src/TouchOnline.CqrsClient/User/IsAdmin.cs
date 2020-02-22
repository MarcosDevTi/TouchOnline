using System;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.User
{
    public class IsAdmin : IQuery<bool>
    {
        public IsAdmin(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}
