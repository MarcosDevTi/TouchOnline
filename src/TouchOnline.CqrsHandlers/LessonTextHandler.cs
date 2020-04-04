﻿using System;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.LessonText;
using TouchOnline.Data;
using TouchOnline.Domain;

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
                Order = command.Order
            });
            _context.SaveChanges();
        }

        public LessonText Handle(GetLessonTextById query)
        {
            return _context.LessonTexts.Find(query.Id);
        }

        public IEnumerable<LessonText> Handle(GetLessonTexts query)
        {
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