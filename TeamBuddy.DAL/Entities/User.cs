using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities.Base;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.DAL.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserTeam> TeamOfUsers { get; set; } = new List<UserTeam>();
    }
}
