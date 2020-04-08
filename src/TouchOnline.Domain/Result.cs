using System;

namespace TouchOnline.Domain
{
    public class Result : Entity
    {
        protected Result() { }
        public Result(int idLesson, int errors, int ppm, int stars, int time, User user, Guid? id = null)
        {
            SetId(id);
            IdLesson = idLesson;
            Errors = errors;
            Ppm = ppm;
            Stars = stars;
            Time = time;
            User = user;
            Date = DateTime.Now;
        }
        public int IdLesson { get; private set; }
        public int Errors { get; private set; }
        public int Ppm { get; private set; }
        public int Stars { get; private set; }
        public int Time { get; private set; }
        public DateTime Date { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; set; }
    }
}