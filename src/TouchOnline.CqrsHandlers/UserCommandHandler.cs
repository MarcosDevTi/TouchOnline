using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.User;
using TouchOnline.Data;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class UserCommandHandler :
        ICommandHandler<Register>
    {
        private readonly ToContext _context;
        public UserCommandHandler(ToContext context) =>
            _context = context;
        public void Handle(Register command)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(command.Password, out passwordHash, out passwordSalt);

            var user = new User(command.Name, command.Email.ToLower());
            user.RegisterPasseword(passwordSalt, passwordHash);

            _context.Add(user);
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}