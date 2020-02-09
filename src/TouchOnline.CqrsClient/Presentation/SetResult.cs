using System;
using TouchOnline.CqrsClient.Contracts;

namespace DigiteMais.Cqrs.Client.Presentation
{
    public class SetResult: ICommand
    {
        public int IdLesson {get; set;}
        public int Errors { get; set; }
        public int Ppm { get; set; }
        public int Stars { get; set; }
        public int Time { get; set; }
        public Guid? UserId {get;set;}
    }
}