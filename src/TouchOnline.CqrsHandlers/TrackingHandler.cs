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
        IQueryHandler<GetTrackings, IEnumerable<Visitor>>,
        IQueryHandler<GetTrackingsLastMinute, IEnumerable<Visitor>>
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
                LanguageSystem = command.LanguageSystem,
                UrlSite = command.UrlSite
            };
            _context.Add(recordedTracking);
            _context.SaveChanges();
        }

        public IEnumerable<Visitor> Handle(GetTrackings query)
        {
            var result = _context.GetRecordeds
                .Include(_ => _.User).Include(_ => _.Keyborad)
                .Where(_ => _.CreateDate > query.InitialDate.Date && _.CreateDate < query.InitialDate.Date.AddDays(1))
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
                UrlSite = _.LastOrDefault()?.UrlSite,
                PagesCount = _.Count(),
                ResultCount = _.Count(_ => _.VisitedPages.Contains("result")),
                DateCreateUser = _.FirstOrDefault(e => e.User != null)?.User?.InscriptionDate,
                FirstLessonDate = _.Select(_ => _.CreateDate).Min(),
                LastLessonDate = _.Select(_ => _.CreateDate).Max(),
                CountResultsForUser = GetTrackingsByUser(_.FirstOrDefault(e => e.User != null)?.User?.Id)
            });

            return result;
        }

        private int? GetTrackingsByUser(Guid? id)
        {
            if (id == null)
                return null;
            return _context.GetRecordeds.Count(_ => _.UserId == id);
        }

        public IEnumerable<Visitor> Handle(GetTrackingsLastMinute query)
        {
            var result = _context.GetRecordeds
                .Include(_ => _.User).Include(_ => _.Keyborad)
                .Where(_ => _.CreateDate > DateTime.Now.AddMinutes(-1))
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
                LanguageSystem = _.OrderBy(_ => _.CreateDate)?.LastOrDefault()?.LanguageSystem,
                PagesCount = _.Count(),
                ResultCount = _.Count(_ => _.VisitedPages.Contains("result")),
                DateCreateUser = _?.LastOrDefault(e => e.User != null)?.User?.InscriptionDate,
                FirstLessonDate = _.Select(_ => _.CreateDate).Min(),
                LastLessonDate = _.Select(_ => _.CreateDate).Max(),
                CountResultsForUser = GetTrackingsByUser(_.FirstOrDefault(e => e.User != null)?.User?.Id),
                UrlSite = _.FirstOrDefault().UrlSite
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