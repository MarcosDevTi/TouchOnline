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
                LanguageSystem = command.LanguageSystem
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
            .Select(_ =>
            {
                var first = _.FirstOrDefault();
                var firstUserNotNull = _.FirstOrDefault(e => e.User != null)?.User;
                return new Visitor
                {
                    Email = firstUserNotNull.Email,
                    City = first?.City,
                    Country = first?.Country,
                    Region = first.Region,
                    KeyboardName = _.FirstOrDefault(_ => _.Keyborad != null)?.Keyborad?.Name,
                    LanguageBrowser = first?.LanguageBrowser,
                    LanguageSystem = first?.LanguageSystem,
                    PagesCount = _.Count(),
                    ResultCount = _.Count(_ => _.VisitedPages.Contains("result")),
                    DateCreateUser = firstUserNotNull?.InscriptionDate,
                    FirstLessonDate = _.Select(_ => _.CreateDate).Min(),
                    LastLessonDate = _.Select(_ => _.CreateDate).Max(),
                    CountResultsForUser = firstUserNotNull.RecordedTrackings.Count
                };
            });

            return result;
        }

        public IEnumerable<Visitor> Handle(GetTrackingsLastMinute query)
        {
            var result = _context.GetRecordeds
               .Include(_ => _.User).Include(_ => _.Keyborad)
               .Where(_ => _.CreateDate > DateTime.Now.AddMinutes(-1))
               .ToList()
           .GroupBy(_ => _.Ip)
           .Select(_ =>
           {
               var first = _.FirstOrDefault();
               var firstUserNotNull = _.FirstOrDefault(e => e.User != null)?.User;
               return new Visitor
               {
                   Email = firstUserNotNull.Email,
                   City = first?.City,
                   Country = first?.Country,
                   Region = first.Region,
                   KeyboardName = _.FirstOrDefault(_ => _.Keyborad != null)?.Keyborad?.Name,
                   LanguageBrowser = first?.LanguageBrowser,
                   LanguageSystem = first?.LanguageSystem,
                   PagesCount = _.Count(),
                   ResultCount = _.Count(_ => _.VisitedPages.Contains("result")),
                   DateCreateUser = firstUserNotNull?.InscriptionDate,
                   FirstLessonDate = _.Select(_ => _.CreateDate).Min(),
                   LastLessonDate = _.Select(_ => _.CreateDate).Max(),
                   CountResultsForUser = firstUserNotNull.RecordedTrackings.Count
               };
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