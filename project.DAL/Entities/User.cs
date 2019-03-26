using System;
using System.Collections.Generic;
using System.Text;
using project.DAL.Enumerations;

namespace project.DAL.Entities
{
    public class User: EntityBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Passwd { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
