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
        IQueryHandler<GetKeyboard, KeyboardViewModel>
    {
        private readonly ToContext _context;
        public KeyboardHandler(ToContext context)
        {
            _context = context;
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
            var keyboard = _context.Keyboards.FirstOrDefault(_ => _.Code == "-brazilian_abnt-3");
            var result = new KeyboardViewModel
            {
                Id = keyboard.Id,
                Code = keyboard.Code,
                Name = keyboard.Name,
                CodeKeys = keyboard.CodeKeys,
                Data = JsonSerializer.Deserialize<IEnumerable<KeyModel>>(keyboard.Data)
            };
            return result;
        }

        private IEnumerable<Keyboard> GetKeyboards(int types)
        {
            var textFile = @"C:\Users\Marcos\Pictures\keyboards\keyboards-type-3.txt";
            string textJson = File.ReadAllText(textFile);
            var list = JsonSerializer.Deserialize<IEnumerable<Keyboard>>(textJson);
            return list;
        }


    }
}
