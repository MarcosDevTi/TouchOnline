using System.Linq;
using TouchOnline.Cqrs.Client.User;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.User;
using TouchOnline.Data;

namespace TouchOnline.CqrsHandlers
{
    public class UserQueryHandler :
        IQueryHandler<Login, LoginConfirm>,
        IQueryHandler<UserExists, bool>,
        IQueryHandler<GetUser, UserLogged>,
        IQueryHandler<IsAdmin, bool>
    {
        private readonly ToContext _context;

        public UserQueryHandler(ToContext context) =>
            _context = context;
        public LoginConfirm Handle(Login query)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == query.Email.ToLower());
            if (user == null) return null;
            var loginConfirm = new LoginConfirm
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            if (!VerifyPasswordHash(query.Password, user.PasswordHash, user.PasswordSalt))
                return null;
            return loginConfirm;
        }

        public bool Handle(UserExists query) =>
            _context.Users.Any(u => u.Email == query.Email);

        public UserLogged Handle(GetUser query)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == query.Email);
            return new UserLogged
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public bool Handle(IsAdmin query)
        {
            return _context.Users.FirstOrDefault(_ => _.Id == query.UserId)?.Email == "marcos.dev.ti@gmail.com";
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computerHash.Length; i++)
                {
                    if (computerHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}