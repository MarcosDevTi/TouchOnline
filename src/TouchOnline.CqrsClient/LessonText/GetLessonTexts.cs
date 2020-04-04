﻿using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Domain.Enums;

namespace TouchOnline.CqrsClient.LessonText
{
    public class GetLessonTexts : IQuery<IEnumerable<Domain.LessonText>>
    {
        public Level Level { get; set; }
        public Language Language { get; set; }
    }
}
