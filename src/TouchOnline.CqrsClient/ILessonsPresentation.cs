using System.Collections.Generic;
using TouchOnline.Domain;

namespace TouchOnline.CqrsClient
{
    public interface ILessonsPresentation
    {
         HashSet<LessonPresentation> InicianteApresentacaoPt(int lCid);
        HashSet<LessonPresentation> BasicoApresentacaoPt(bool premium);
        HashSet<LessonPresentation> IntermediarioApresentacaoPt(bool premium);
        HashSet<LessonPresentation> AvancadoApresentacaoPt(bool premium);
        HashSet<LessonPresentation> MeusTextosApresentacao(bool premium);
    }
}