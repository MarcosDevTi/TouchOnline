using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Management;
using TouchOnline.Data;

namespace TouchOnline.CqrsHandlers
{
    public class ManagementHandler :
        IQueryHandler<GetUsers, IEnumerable<UserViewModelManagement>>,
        IQueryHandler<GetCounts, Counts>,
        IQueryHandler<GetCountsDay, GeneralDay>
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
                SendsCount = _context.GetRecordeds.Count(),
                ResultsCountTotalSendeds = _context.GetRecordeds.Count(_ => _.VisitedPages.Contains("result"))
            };
        }

        public GeneralDay Handle(GetCountsDay query)
        {

            return new GeneralDay
            {
                UsersCount = _context.Users.Count(),
                MyTextsCount = _context.MyTexts.Count(),
                ResultsCount = _context.Results.Count(),
                SendsCount = _context.GetRecordeds.Count(),
                ResultsCountTotalSendeds = _context.GetRecordeds.Count(_ => _.VisitedPages.Contains("result")),
                NewUsersDayCount = _context.Users.Where(_ =>
                   _.InscriptionDate >= query.DateStart.Date && _.InscriptionDate < query.DateStart.Date.AddDays(1))
                    .Select(_ => _.Id).Distinct().Count(),
                OldUsersDayCount = _context.GetRecordeds.Include(_ => _.User).Where(_ => _.User != null)
                .Where(_ =>
                    _.CreateDate >= query.DateStart.Date && _.CreateDate < query.DateStart.Date.AddDays(1)
                    && _.User.InscriptionDate < query.DateStart.Date)
                .Select(_ => _.UserId).Distinct().Count(),
                TotalWithAppSended = _context.GetRecordeds.Count(_ => _.VisitedPages.Contains("app")),
                TotalWithListSended = _context.GetRecordeds.Count(_ => _.VisitedPages.Contains("list")),
                UsersDayCount = _context.GetRecordeds.Where(_ =>
                    _.CreateDate >= query.DateStart.Date && _.CreateDate < query.DateStart.Date.Date.AddDays(1))
                    .Select(_ => _.Ip).Distinct().Count()
            };
        }
    }
}
