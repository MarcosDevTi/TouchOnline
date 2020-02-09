namespace TouchOnline.CqrsClient.Presentation
{
     public class LessonPresentationItem
    {
        public int IdLesson { get; set; }
        public string Name { get; set; }
        public string LessonTextShort {get;set;}

        public decimal Precision { get; set; }
        public int Ppm { get; set; }
        public int Stars { get; set; }
        public int Time { get; set; }
        public bool Initialized {get;set;} = false;

        public void AddResults(decimal precision, int ppm, int stars, int time)
        {
            Precision = precision;
            Ppm = ppm;
            Stars = stars;
            Time = time;
            Initialized = true;
        }
    }
}