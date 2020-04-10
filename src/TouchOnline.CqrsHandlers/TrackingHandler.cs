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
        IQueryHandler<GetTrackings, IEnumerable<SaveTracking>>
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

        public IEnumerable<SaveTracking> Handle(GetTrackings query)
        {
            query.InitialDate = new System.DateTime(2020, 2, 17);
            query.LimitDate = new System.DateTime(2020, 10, 18);

            var byIp = (from tr in _context.GetRecordeds.Where(_ => _.Ip != null && _.StartDate >= query.InitialDate && _.StartDate <= query.LimitDate).ToList()
                        group tr by tr.Ip);

            return byIp.Select(_ => new SaveTracking
            {
                Ip = _.Key,
                EndDate = _.Select(d => d.EndDate).Max(),
                StartDate = _.Select(d => d.StartDate).Min(),
                UserId = _.FirstOrDefault(_ => _.UserId != null)?.UserId,
                VisitedPages = GetVisitedPagesCondensed(_.Select(_ => _.VisitedPages).ToArray())
            }).OrderBy(_ => _.StartDate);
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