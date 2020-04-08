using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Presentation;
using TouchOnline.Data;
using TouchOnline.Domain;
using TouchOnline.Domain.Enums;

namespace TouchOnline.CqrsHandlers
{
    public class LessonPresentationQueryHandler :
        IQueryHandler<GetLessonsPresentationList, IReadOnlyList<LessonPresentationItem>>,
        IQueryHandler<GetLessonPresentation, LessonPresentationApp>,
        IQueryHandler<GetResults, IReadOnlyList<Results>>
    {
        private readonly ToContext _context;
        public LessonPresentationQueryHandler(ToContext context)
        {
            _context = context;
        }
        public IReadOnlyList<LessonPresentationItem> Handle(GetLessonsPresentationList query)
        {
            if (query.Level == "myText")
            {
                return _context.MyTexts.Where(_ => _.UserId == query.UserId).Select(_ => new LessonPresentationItem
                {
                    IdLesson = _.CodeLesson,
                    Name = _.Name,
                    Text = _.Text,
                    Level = query.Level
                }).ToList();
            }

            return _context.LessonTexts.Where(_ => _.Level == GetLevel(query.Level) && _.Language == Language.Pt).Select(_ => new LessonPresentationItem
            {
                IdLesson = int.Parse(_.Name) + 100,
                Name = _.Name,
                Text = _.Text
            }).ToList();
        }

        private Level GetLevel(string level)
        {
            switch (level)
            {
                case "basics":
                    return Level.Basic;
                case "intermediates":
                    return Level.Intermediate;
                case "advanceds":
                    return Level.Advanced;
                default:
                    return Level.Basic;
            }
        }

        public LessonPresentationApp Handle(GetLessonPresentation query)
        {
            if (query.IdLesson >= 500)
            {
                var lessonDb = _context.MyTexts.FirstOrDefault(_ => _.CodeLesson == query.IdLesson && _.UserId == query.UserId);
                return new LessonPresentationApp
                {
                    IdLesson = query.IdLesson,
                    Name = lessonDb?.Name,
                    LessonText = lessonDb?.Text
                };
            }

            var lesson = new LessonsPresentation().BuscarExercicio(query.IdLesson);
            return new LessonPresentationApp
            {
                IdLesson = query.IdLesson,
                Name = lesson.Nome,
                LessonText = lesson.TextoFase
            };
        }

        public IReadOnlyList<Results> Handle(GetResults query)
        {
            if (!_context.Results.Any())
                return new List<Results>();

            var results = (from res in _context.Results
               .Include(c => c.User).ToList().Where(x => x.User.Id == query.IdUser)
                           group res by res.IdLesson into Grupo
                           select Grupo)
              .Select(c => c.OrderByDescending(d => d.Date))
              .Select(x => x.First()).ToList();

            return results.Select(x => new Results
            {
                IdLesson = x.IdLesson,
                Precision = CalcPercent(x.Errors, GetLessonPresentation(x.IdLesson, query.IdUser).TextoFase.Length),
                Ppm = x.Ppm,
                Stars = x.Stars,
                Time = x.Time
            }).ToList();

        }

        private LessonPresentation GetLessonPresentation(int idLesson, Guid userId)
        {
            if (idLesson >= 500)
            {
                var resultMyText = _context.MyTexts.FirstOrDefault(_ => _.UserId == userId);
                return new LessonPresentation
                {
                    TextoFase = resultMyText.Text
                };
            }
            return new LessonsPresentation().BuscarExercicio(idLesson);
        }


        private decimal CalcPercent(int errors, int lengthFrase) =>
            100 - (decimal)(errors * 100) / (decimal)lengthFrase;
    }
}