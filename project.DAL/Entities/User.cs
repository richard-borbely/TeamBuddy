using System;
using System.Collections.Generic;
using System.Text;
using project.DAL.Enumerations;

namespace project.DAL.Entities
{
    public class User: EntityBase
    {
        public string email { get; set; }
        public string name { get; set; }
        public string passwd { get; set; }
        public Gender gender { get; set; }
        public Status status { get; set; }
        public ICollection<Team> teams { get; set; }
        public ICollection<Post> posts { get; set; }
    }
}
