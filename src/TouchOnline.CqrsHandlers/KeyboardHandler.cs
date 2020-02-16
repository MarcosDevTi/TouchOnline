using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsClient.Keyboard;
using TouchOnline.CqrsClient.Keyboards;
using TouchOnline.Data;
using TouchOnline.Domain;

namespace TouchOnline.CqrsHandlers
{
    public class KeyboardHandler :
        ICommandHandler<InsertKeyboards>,
        IQueryHandler<GetKeyboard, KeyboardViewModel>,
        IQueryHandler<GetKeyboardsDw, IEnumerable<KeyboardDw>>
    {
        private readonly ToContext _context;
        private readonly IConfiguration _config;
        public KeyboardHandler(ToContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public void Handle(InsertKeyboards command)
        {
            var listInsert = GetKeyboards(3);
            foreach (var keyboard in listInsert)
            {
                _context.Add(keyboard);
            }
            _context.SaveChanges();
        }

        public KeyboardViewModel Handle(GetKeyboard query)
        {
            Keyboard keyboard;
            if (query.KeyboardId == null)
            {
                keyboard = _context.Keyboards.FirstOrDefault(_ => _.Code == "");
            }
            else
            {
                keyboard = _context.Keyboards.FirstOrDefault(_ => _.Id == query.KeyboardId);
            }
            var result = new KeyboardViewModel
            {
                Id = keyboard.Id,
                Code = keyboard.Code,
                Name = keyboard.Name,
                CodeKeys = JsonSerializer.Deserialize<IEnumerable<KeyCode>>(keyboard.CodeKeys),
                Data = JsonSerializer.Deserialize<IEnumerable<KeyModel>>(keyboard.Data)
            };
            return result;
        }

        public IEnumerable<KeyboardDw> Handle(GetKeyboardsDw query)
        {
            return _context.Keyboards.Select(_ => new KeyboardDw
            {
                Id = _.Id,
                Name = _.Name
            });
        }

        private IEnumerable<Keyboard> GetKeyboards(int types)
        {
            string textJson = File.ReadAllText("keyboards-type-3.txt");
            var list = JsonSerializer.Deserialize<IEnumerable<Keyboard>>(textJson);
            return list;
        }


    }
}
