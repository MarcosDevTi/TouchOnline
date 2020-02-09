using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.User;

namespace TouchOnline.Cqrs.Client.User
{
    public class Login : IQuery<LoginConfirm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}