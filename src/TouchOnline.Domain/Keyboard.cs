namespace TouchOnline.Domain
{
    public class Keyboard : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int Type { get; set; }
        public string CodeKeys { get; set; }
        public bool Status { get; set; }
        public string LanguageCode { get; set; }
        public string KeycodesBeginners { get; set; }
    }
}
