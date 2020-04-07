using System;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.LessonText;
using TouchOnline.Data;
using TouchOnline.Domain;
using TouchOnline.Domain.Enums;

namespace TouchOnline.CqrsHandlers
{
    public class LessonTextHandler :
        ICommandHandler<CreateLessonText>,
        ICommandHandler<DeleteLessonText>,
        IQueryHandler<GetLessonTextById, LessonText>,
        IQueryHandler<GetLessonTexts, IEnumerable<LessonText>>
    {
        private readonly ToContext _context;
        public LessonTextHandler(ToContext context) => _context = context;

        public void Handle(CreateLessonText command)
        {
            _context.Add(new LessonText
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Text = command.Text,
                Language = command.Language,
                Level = command.Level,
                Order = command.Order,
                IdLesson = GetLastIdLesson(command.Level)
            });
            _context.SaveChanges();
        }

        private int GetLastIdLesson(Level level)
        {
            if (_context.LessonTexts.Any(_ => _.Level == level))
            {
                return _context.LessonTexts.Where(_ => _.Level == level).Max(_ => _.IdLesson) + 1;
            }
            else
            {
                switch (level)
                {
                    case Level.Basic:
                        return 201;
                    case Level.Intermediate:
                        return 301;
                    case Level.Advanced:
                        return 401;
                    default:
                        return 601;
                }
            }

        }

        public LessonText Handle(GetLessonTextById query)
        {
            return _context.LessonTexts.Find(query.Id);
        }

        public IEnumerable<LessonText> Handle(GetLessonTexts query)
        {
            if (query.Level == Level.MyText)
            {
                return _context.MyTexts.Where(_ => _.UserId == query.UserId).Select(_ => new LessonText
                {
                    IdLesson = _.CodeLesson,
                    Name = _.Name,
                    Text = _.Text,
                });
            }
            return _context.LessonTexts.Where(_ =>
            _.Level == query.Level && _.Language == query.Language).OrderBy(_ => _.Order);
        }

        public void Handle(DeleteLessonText command)
        {
            var lesson = _context.LessonTexts.Find(command.Id);
            _context.Remove(lesson);
            _context.SaveChanges();
        }
    }
}
