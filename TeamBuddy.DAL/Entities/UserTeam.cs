using System;
using TeamBuddy.DAL.Entities.Base;

namespace TeamBuddy.DAL.Entities
{
    public class UserTeam : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
