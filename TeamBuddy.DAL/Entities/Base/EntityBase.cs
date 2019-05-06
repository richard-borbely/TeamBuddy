using System;

namespace TeamBuddy.DAL.Entities.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
