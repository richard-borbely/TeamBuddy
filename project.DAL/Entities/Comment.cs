using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Comment: EntityBase
    {
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTime Time_of_comment { get; set; }
    }
}
