using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.MyText;
using TouchOnline.CqrsClient.Presentation;
using TouchOnline.Data;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class MyTextHandler :
        //ICommandHandler<CreateMyText>,
        IQueryHandler<CreateMyText, IEnumerable<LessonPresentationItem>>,
        IQueryHandler<GetMyText, MyTextViewModel>,
        IQueryHandler<GetMyTexts, IEnumerable<MyTextViewModel>>
    {
        private readonly ToContext _context;
        public MyTextHandler(ToContext context) => _context = context;


        public IEnumerable<LessonPresentationItem> Handle(CreateMyText command)
        {
            var last = _context.MyTexts.Where(_ => _.UserId == command.UserId).MaxBy(_ => _.CodeLesson)?.FirstOrDefault();

            int codeLesson = last?.CodeLesson == null || last?.CodeLesson == 0 ? 500 : last.CodeLesson + 1;

            _context.Add(new MyText
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Text = command.Text,
                UserId = command.UserId,
                CodeLesson = codeLesson
            });
            _context.SaveChanges();

            return _context.MyTexts.Where(_ => _.UserId == command.UserId).Select(_ => new LessonPresentationItem
            {
                IdLesson = _.CodeLesson,
                Name = _.Name,
                LessonText = _.Text,
                Level = "myText"
            }).ToList();
        }

        public MyTextViewModel Handle(GetMyText query)
        {
            return _context.MyTexts.Where(_ => _.Id == query.Id).Select(_ =>
                    new MyTextViewModel
                    {
                        Id = _.Id,
                        Name = _.Name,
                        LessonText = _.Text
                    }).FirstOrDefault();
        }

        public IEnumerable<MyTextViewModel> Handle(GetMyTexts query)
        {
            return _context.MyTexts.Where(_ => _.UserId == query.UserId).Select(_ =>
                   new MyTextViewModel
                   {
                       Id = _.Id,
                       Name = _.Name,
                       LessonText = _.Text
                   });
        }

        //public LessonPresentationApp Handle(CreateMyText query)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
