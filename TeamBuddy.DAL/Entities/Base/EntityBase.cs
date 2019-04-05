using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.DAL.Entities.Base
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
