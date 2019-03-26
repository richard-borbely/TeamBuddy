using System;

namespace project.DAL.Entities
{
    public abstract class EntityBase: IEntity
    {
        public Guid Id { get; set; }
    }
}
