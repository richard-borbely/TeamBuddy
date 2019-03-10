using System;

namespace project.DAL.Entities
{
    public class EntityBase: IEntity
    {
        public Guid Id { get; set; }
    }
}
