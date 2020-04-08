using DigiteMais.Cqrs.Client.Presentation;
using System;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Presentation;
using TouchOnline.Data;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class LessonPresentationCommandHandler :
         ICommandHandler<SetResult>,
        ICommandHandler<SetResults>
    {
        private readonly ToContext _context;
        public LessonPresentationCommandHandler(ToContext context)
        {
            _context = context;
        }
        public void Handle(SetResult command)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == command.UserId);
            if (user == null)
            {
                user = CreateGuest(command.UserId.Value);
            }
            _context.Results.Add(new Result(command.IdLesson, command.Errors, command.Ppm, command.Stars, command.Time, user));
            _context.SaveChanges();
        }

        public void Handle(SetResults command)
        {
            if (command.Results == null)
            {
                return;
            }
            var user = _context.Users.FirstOrDefault(x => x.Email == command.Email);

            command.Results.ToList().ForEach(_ =>
            _context.Results.Add(new Result(_.IdLesson, _.Errors, _.Ppm, _.Stars, _.Time, user)));
            _context.SaveChanges();
        }

        private User CreateGuest(Guid id)
        {
            return new User("", "", id);
        }
    }
}