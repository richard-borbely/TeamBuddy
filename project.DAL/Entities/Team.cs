using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Team: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Students { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
