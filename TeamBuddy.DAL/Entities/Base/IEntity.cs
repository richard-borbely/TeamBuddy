using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.DAL.Entities.Base
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
