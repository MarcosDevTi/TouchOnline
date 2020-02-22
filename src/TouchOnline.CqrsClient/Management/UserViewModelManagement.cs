using System;

namespace TouchOnline.CqrsClient.Management
{
    public class UserViewModelManagement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime InscriptionDate { get; set; }
    }
}
