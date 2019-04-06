﻿using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities.Base;

namespace TeamBuddy.DAL.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Time_of_post { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}