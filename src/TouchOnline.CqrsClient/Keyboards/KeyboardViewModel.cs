﻿using System;
using System.Collections.Generic;

namespace TouchOnline.CqrsClient.Keyboards
{
    public class KeyboardViewModel
    {
        public IEnumerable<KeyModel> Data { get; set; }
        public IEnumerable<KeyCode> CodeKeys { get; set; }
        public string KeycodesBeginners { get; set; }
    }
}
