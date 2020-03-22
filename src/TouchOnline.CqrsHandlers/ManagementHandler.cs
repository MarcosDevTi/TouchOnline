using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Management;
using TouchOnline.Data;

namespace TouchOnline.CqrsHandlers
{
    public class ManagementHandler :
        IQueryHandler<GetUsers, IEnumerable<UserViewModelManagement>>,
        IQueryHandler<GetCounts, Counts>
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
                InscriptionDate = _.InscriptionDate,
                MyTextsCount = _context.MyTexts.Count(t => t.UserId == _.Id),
                ResultsCount = _context.Results.Count(r => r.User.Id == _.Id)
            });
        }

        public Counts Handle(GetCounts query)
        {
            return new Counts
            {
                UsersCount = _context.Users.Count(),
                MyTextsCount = _context.MyTexts.Count(),
                ResultsCount = _context.Results.Count(),
                SendsCount = _context.GetRecordeds.Count()
            };
        }
    }
}
