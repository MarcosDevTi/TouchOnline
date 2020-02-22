using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Management;
using TouchOnline.Data;

namespace TouchOnline.CqrsHandlers
{
    public class ManagementHandler :
        IQueryHandler<GetUsers, IEnumerable<UserViewModelManagement>>
    {
        private readonly ToContext _context;
        public ManagementHandler(ToContext context) => _context = context;
        public IEnumerable<UserViewModelManagement> Handle(GetUsers query)
        {
            return _context.Users.Select(_ => new UserViewModelManagement
            {
                Id = _.Id,
                Name = _.Name,
                Email = _.Email,
                InscriptionDate = _.InscriptionDate
            });
        }
    }
}
