using System.Collections.Generic;
using System.Linq;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Support;
using TouchOnline.Data;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class SupportHandler :
        ICommandHandler<SendMessage>,
        IQueryHandler<GetMessages, IEnumerable<SendMessage>>
    {
        private readonly ToContext _context;
        public SupportHandler(ToContext context) => _context = context;

        public void Handle(SendMessage command)
        {
            _context.Add(new MessageSupport 
            {
                UserId = command.UserId,
                Email = command.Email,
                Name = command.Name,
                Text = command.Text
            });
            _context.SaveChanges();
        }

        public IEnumerable<SendMessage> Handle(GetMessages query)
        {
            return _context.MessageSupports.Select(_ => new SendMessage
            {
                UserId = _.UserId,
                Email = _.Email,
                Name = _.Name,
                Text = _.Text
            });
        }
    }
}