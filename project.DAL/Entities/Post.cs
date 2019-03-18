﻿using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Post: EntityBase
    {
        public string title { get; set; }
        public string text { get; set; }
        public User author { get; set; }
        public DateTime post_time { get; set; }
        public ICollection<Commentary> commentaries { get; set; }
    }
}
