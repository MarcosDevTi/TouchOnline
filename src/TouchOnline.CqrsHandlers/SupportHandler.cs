using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Support;
using TouchOnline.Data;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class SupportHandler :
        ICommandHandler<SendMessage>
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
    }
}