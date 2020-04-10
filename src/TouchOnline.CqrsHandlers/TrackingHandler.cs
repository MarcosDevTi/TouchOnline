using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Tracking;
using TouchOnline.Data;
using TouchOnline.Domain.UserTracking;

namespace TouchOnline.CqrsHandlers
{
    public class TrackingHandler :
        ICommandHandler<SaveTracking>,
        IQueryHandler<GetTrackings, IEnumerable<Visitor>>
    {
        private readonly ToContext _context;
        public TrackingHandler(ToContext context) => _context = context;
        public void Handle(SaveTracking command)
        {
            var recordedTracking = new RecordedTracking
            {
                VisitedPages = command.VisitedPages,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                UserId = command.UserId,
                Ip = command.Ip,
                City = command.City,
                Country = command.Country,
                Region = command.Region,
                CreateDate = DateTime.Now,
                KeyboradId = command.KeyboradId,
                LanguageBrowser = command.LanguageBrowser,
                LanguageKeyboard = command.LanguageKeyboard,
                LanguageSystem = command.LanguageSystem
            };
            _context.Add(recordedTracking);
            _context.SaveChanges();
        }

        public IEnumerable<Visitor> Handle(GetTrackings query)
        {
            var teste = _context.GetRecordeds
                .Include(_ => _.User).Include(_ => _.Keyborad).Where(_ => _.Keyborad != null)
                .Where(_ => _.CreateDate > DateTime.Now.Date && _.VisitedPages.Contains("result"))
                .ToList();

            var result = _context.GetRecordeds
                .Include(_ => _.User).Include(_ => _.Keyborad).Where(_ => _.Keyborad != null)
                .Where(_ => _.CreateDate > DateTime.Now.Date && _.VisitedPages.Contains("result"))
                .ToList()
            .GroupBy(_ => _.Ip)
            .Select(_ => new Visitor
            {
                Email = _.FirstOrDefault(e => e.User != null)?.User.Email,
                City = _.FirstOrDefault()?.City,
                Country = _.FirstOrDefault()?.Country,
                Region = _.FirstOrDefault().Region,
                KeyboardName = _.FirstOrDefault(_ => _.Keyborad != null)?.Keyborad?.Name,
                LanguageBrowser = _.FirstOrDefault()?.LanguageBrowser,
                LanguageSystem = _.FirstOrDefault()?.LanguageSystem,
                PagesCount = _.Count(),
                ResultCount = _.Count(_ => _.VisitedPages.Contains("result")),
                DateCreateUser = _.FirstOrDefault(e => e.User != null)?.User?.InscriptionDate,
                FirstLessonDate = _.Select(_ => _.CreateDate).Min(),
                LastLessonDate = _.Select(_ => _.CreateDate).Max(),
            });

            return result;
        }

        public string GetVisitedPagesCondensed(string[] list)
        {
            var result = string.Empty;
            foreach (var item in list)
            {
                result += "/" + item;
            }
            return result;
        }
    }
}