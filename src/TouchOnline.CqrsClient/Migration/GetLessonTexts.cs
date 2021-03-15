using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Migration
{
    public class GetLessonTexts : IQuery<IEnumerable<Domain.LessonText>>
    {
    }
}
