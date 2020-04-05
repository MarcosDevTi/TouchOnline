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
        ICommandHandler<KeyboardForUpdate>,
        IQueryHandler<GetKeyboardById, KeyboardViewModel>,
        IQueryHandler<GetKeyboardByLangCode, KeyboardViewModel>,
        IQueryHandler<GetKeyboardsDw, IEnumerable<KeyboardDw>>,
        IQueryHandler<GetKeyboardsManagement, IEnumerable<KeyboardForUpdate>>,
        IQueryHandler<GetKeyboardForUpdate, KeyboardForUpdate>
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

        public IEnumerable<KeyboardDw> Handle(GetKeyboardsDw query)
        {
            return _context.Keyboards.Where(_ => _.Status).OrderBy(_ => _.Name).Select(_ => new KeyboardDw
            {
                Id = _.Id,
                Name = _.Name
            });
        }

        public IEnumerable<KeyboardForUpdate> Handle(GetKeyboardsManagement query)
        {
            return _context.Keyboards.OrderBy(_ => _.Name).Select(keyboard => new KeyboardForUpdate
            {
                Id = keyboard.Id,
                Code = keyboard.Code,
                Name = keyboard.Name,
                LanguageCode = keyboard.LanguageCode,
                Status = keyboard.Status
            });
        }

        public KeyboardForUpdate Handle(GetKeyboardForUpdate query)
        {
            var keyboard = _context.Keyboards.Find(query.Id);
            return new KeyboardForUpdate
            {
                Id = keyboard.Id,
                Code = keyboard.Code,
                Name = keyboard.Name,
                LanguageCode = keyboard.LanguageCode,
                Status = keyboard.Status,
                KeycodesBeginners = keyboard.KeycodesBeginners
            };
        }

        public void Handle(KeyboardForUpdate command)
        {
            var keyboard = _context.Keyboards.Find(command.Id);
            keyboard.Name = command.Name;
            keyboard.LanguageCode = command.LanguageCode;
            keyboard.Status = command.Status;
            keyboard.KeycodesBeginners = command.KeycodesBeginners;

            _context.SaveChanges();
        }

        public KeyboardViewModel Handle(GetKeyboardByLangCode query)
        {
            var keyboard = _context.Keyboards.FirstOrDefault(_ => _.LanguageCode == query.LanguageCode);
            return keyboard == null ? null : KeyboardToViewModel(keyboard);
        }

        public KeyboardViewModel Handle(GetKeyboardById query)
        {
            var keyboard = _context.Keyboards.FirstOrDefault(_ => _.Id == query.Id);
            return keyboard == null ? null : KeyboardToViewModel(keyboard);
        }

        private IEnumerable<Keyboard> GetKeyboards(int types)
        {
            string textJson = File.ReadAllText("keyboards-type-3.txt");
            var list = JsonSerializer.Deserialize<IEnumerable<Keyboard>>(textJson);
            return list;
        }

        public KeyboardViewModel KeyboardToViewModel(Keyboard keyboard)
        {
            return new KeyboardViewModel
            {
                CodeKeys = JsonSerializer.Deserialize<IEnumerable<KeyCode>>(keyboard.CodeKeys),
                Data = JsonSerializer.Deserialize<IEnumerable<KeyModel>>(keyboard.Data),
                KeycodesBeginners = keyboard.KeycodesBeginners
            };
        }
    }
}
