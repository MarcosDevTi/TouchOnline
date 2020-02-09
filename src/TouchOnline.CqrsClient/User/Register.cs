using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.User
{
    public class Register : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}