namespace TouchOnline.Domain
{
    public class LessonPresentation
    {
        public int IdentificadorExercicio { get; set; }
        public string Nome { get; set; }
        public string TextoFase { get; set; }
        public string TeclasEstudadas { get; set; }
        public int NivelRigirosidade { get; set; }
        public int Categoria { get; set; }
        public int PpmIdeal { get; set; }
        public int TempoIdeal { get; set; }
        public int TotalErrosIdeal { get; set; }
        public bool Ativo { get; set; }
        public bool Premium { get; set; }
        public string LinkItem { get; set; }
    }
}