namespace TouchOnline.Domain
{
    public class Resultado
    {
        public int IdentificadorExercicio { get; set; }
        public string Nome { get; set; }
        public string Texto { get; set; }
        public string TeclasEstudadas { get; set; }
        public int PPM { get; set; }
        public int Tempo { get; set; }
        public int TotalErros { get; set; }
        public int Categoria { get; set; }
        public int PpmIdeal { get; set; }
        public int TempoIdeal { get; set; }
        public int TotalErrosIdeal { get; set; }
        public string LetraErro { get; set; }
        public int Tentativas { get; set; }
    }
}