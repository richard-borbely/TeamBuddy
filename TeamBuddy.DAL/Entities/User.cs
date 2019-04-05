using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities.Base;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.DAL.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Passwd { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        //public ICollection<Team> Teams { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserTeam> TeamOfUsers { get; set; }
    }
}
