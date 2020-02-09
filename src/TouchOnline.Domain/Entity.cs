using System;

namespace TouchOnline.Domain
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        protected void SetId(Guid? id) 
        {
            Id = id == null ? Id = Guid.NewGuid() : Id = id.Value;
        }
    }
}