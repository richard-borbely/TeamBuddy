using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities.Base;

namespace TeamBuddy.DAL.Entities
{
    public class Comment : EntityBase
    {
        public string Text { get; set; }
        public DateTime CommentAdditionTime { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
