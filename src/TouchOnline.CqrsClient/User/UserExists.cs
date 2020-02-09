using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.User
{
    public class UserExists : IQuery<bool>
    {
        public UserExists(string email)
        {
            Email = email;
        }
        public string Email { get; set; }
    }
}