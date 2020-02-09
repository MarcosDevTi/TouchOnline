using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.User
{
    public class GetUser : IQuery<UserLogged>
    {
        public GetUser(string email)
        {
            Email = email;

        }
        public string Email { get; set; }
    }
}