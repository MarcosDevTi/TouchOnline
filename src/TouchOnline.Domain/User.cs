using System;

namespace TouchOnline.Domain
{
    public class User : Entity
    {
        protected User() { }
        public User(string name, string email, Guid? id = null)
        {
            SetId(id);
            this.Name = name;
            this.Email = email;
            InscriptionDate = DateTime.Now;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public DateTime InscriptionDate { get; private set; }

        public string LanguageKeyboard { get; set; }
        public string LanguageSystem { get; set; }
        public string LanguageLessons { get; set; }
        public void RegisterPasseword(byte[] passwordSalt, byte[] passwordHash)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}