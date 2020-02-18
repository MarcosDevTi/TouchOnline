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
                Ip = command.Ip
            };
            _context.Add(recordedTracking);
            _context.SaveChanges();
        }

        public IEnumerable<SaveTracking> Handle(GetTrackings query)
        {
            query.InitialDate = new System.DateTime(2020, 2, 17);
            query.LimitDate = new System.DateTime(2020, 2, 18);

            var byIp = (from tr in _context.GetRecordeds.Where(_ => _.Ip != null && _.StartDate >= query.InitialDate && _.StartDate <= query.LimitDate).ToList()
                        group tr by tr.Ip);



            return _context.GetRecordeds.Select(_ => new SaveTracking
            {
                Ip = _.Ip,
                EndDate = _.EndDate,
                StartDate = _.StartDate,
                UserId = _.UserId,
                VisitedPages = _.VisitedPages
            });
        }
    }
}