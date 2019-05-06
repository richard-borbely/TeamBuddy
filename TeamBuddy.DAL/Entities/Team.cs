using System.Collections.Generic;
using TeamBuddy.DAL.Entities.Base;

namespace TeamBuddy.DAL.Entities
{
    public class Team : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<UserTeam> UserInTeam { get; set; } = new List<UserTeam>();
    }
}
