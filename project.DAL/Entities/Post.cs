using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Post: EntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTime Time_of_post { get; set; }
        public ICollection<Commentary> Comments { get; set; }
    }
}
