using System;

namespace TouchOnline.CqrsClient.User
{
     public class UserLogged
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}