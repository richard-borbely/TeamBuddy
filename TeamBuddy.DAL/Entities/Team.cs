using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities.Base;

namespace TeamBuddy.DAL.Entities
{
    public class Team : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserTeam> UserInTeam { get; set; }
    }
}
