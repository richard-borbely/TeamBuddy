using System;
using System.Collections.Generic;
using TeamBuddy.DAL.Entities.Base;

namespace TeamBuddy.DAL.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PostAdditionTime { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
