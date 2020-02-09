using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Presentation;
using TouchOnline.Data;
using TouchOnline.Domain;

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
            return new LessonsPresentation().GetPresentation(query.Level).Select(x =>
            new LessonPresentationItem
            {
                IdLesson = x.IdentificadorExercicio,
                Name = x.Nome,
                LessonTextShort = x.ResumoTxtFase
            }).ToList();
        }

        public LessonPresentationApp Handle(GetLessonPresentation query)
        {
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
              .Select(c => c.OrderByDescending(d => d.Stars))
              .Select(x => x.First()).ToList();

            return results.Select(x => new Results
            {
                IdLesson = x.IdLesson,
                Precision = CalcPercent(x.Errors, GetLessonPresentation(x.IdLesson).TextoFase.Length),
                Ppm = x.Ppm,
                Stars = x.Stars,
                Time = x.Time
            }).ToList();

        }

        private LessonPresentation GetLessonPresentation(int idLesson) =>
            new LessonsPresentation().BuscarExercicio(idLesson);

        private decimal CalcPercent(int errors, int lengthFrase) =>
            100 - (decimal)(errors * 100) / (decimal)lengthFrase;
    }
}