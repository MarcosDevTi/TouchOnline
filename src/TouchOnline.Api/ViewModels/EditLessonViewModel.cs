using TouchOnline.Domain;

namespace TouchOnline.Api.ViewModels
{
    public class EditLessonViewModel
    {
        public EditLessonViewModel(LessonText lessonText)
        {
            var lignes = lessonText.Text.Split('¶');
            Text = TextOrDefalt(lignes, 0);
            TextLine2 = TextOrDefalt(lignes, 1);
            TextLine3 = TextOrDefalt(lignes, 2);
            TextLine4 = TextOrDefalt(lignes, 3);
            TextLine5 = TextOrDefalt(lignes, 4);
            TextLine6 = TextOrDefalt(lignes, 5);
            TextLine7 = TextOrDefalt(lignes, 6);

            Name = lessonText.Name;
            Level = ((int)lessonText.Level).ToString();
            Language = ((int)lessonText.Language).ToString();
            Order = lessonText.Order;
        }

        private string TextOrDefalt(string[] text, int index)
        {
            if (text.Length > index)
                return text[index];
            return null;
        }
        public string Name { get; set; }
        public string Text { get; set; }
        public string TextLine2 { get; set; }
        public string TextLine3 { get; set; }
        public string TextLine4 { get; set; }
        public string TextLine5 { get; set; }
        public string TextLine6 { get; set; }
        public string TextLine7 { get; set; }
        public string Level { get; set; }
        public string Language { get; set; }
        public int Order { get; set; }
    }
}
