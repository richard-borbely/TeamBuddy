﻿using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities;

namespace TeamBuddy.BL.Models
{
    public class PostDetailModel : BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Time_of_post { get; set; }
        public User User { get; set; }
    }
}