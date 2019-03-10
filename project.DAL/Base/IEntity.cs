using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
