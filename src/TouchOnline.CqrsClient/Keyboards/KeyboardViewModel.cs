using System;
using System.Collections.Generic;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class KeyboardViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public IEnumerable<KeyModel> Data { get; set; }
        public IEnumerable<KeyCode> CodeKeys { get; set; }
    }
}
