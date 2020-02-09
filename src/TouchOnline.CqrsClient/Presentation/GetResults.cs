using System;
using System.Collections.Generic;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.CqrsClient.Presentation
{
    public class GetResults : IQuery<IReadOnlyList<Results>>
    {
        public GetResults(Guid? idUser)
        {
            IdUser = idUser == null ? Guid.NewGuid(): idUser.Value;
        }
        public Guid IdUser { get; set; }
    }
}