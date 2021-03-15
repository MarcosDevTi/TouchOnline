using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Migration;
using TouchOnline.Data;
using TouchOnline.Domain;
using TouchOnline.Domain.UserTracking;

namespace TouchOnline.CqrsHandlers
{
    public class MigrationQueryHandler :
        IQueryHandler<GetKeyboards, IEnumerable<Keyboard>>,
        IQueryHandler<GetLessonTexts, IEnumerable<LessonText>>,
        IQueryHandler<GetMessageSupports, IEnumerable<MessageSupport>>,
        IQueryHandler<GetMyTexts, IEnumerable<MyText>>,
        IQueryHandler<GetRecordeds, IEnumerable<RecordedTracking>>,
        IQueryHandler<GetResults, IEnumerable<Result>>,
        IQueryHandler<GetUsers, IEnumerable<User>>
    {

        private readonly ToContext _context;
        public MigrationQueryHandler(ToContext context) => _context = context;

        public IEnumerable<Keyboard> Handle(GetKeyboards query)
        {
            return _context.Keyboards.ToList();
        }

        public IEnumerable<LessonText> Handle(GetLessonTexts query)
        {
            return _context.LessonTexts.ToList();
        }

        public IEnumerable<MyText> Handle(GetMyTexts query)
        {
            return _context.MyTexts.ToList();
        }

        public IEnumerable<RecordedTracking> Handle(GetRecordeds query)
        {
            return _context.GetRecordeds.ToList();
        }

        public IEnumerable<Result> Handle(GetResults query)
        {
            return _context.Results.ToList();
        }

        public IEnumerable<User> Handle(GetUsers query)
        {
            return _context.Users.ToList();
        }

        public IEnumerable<MessageSupport> Handle(GetMessageSupports query)
        {
            return _context.MessageSupports.ToList();
        }
    }
}
