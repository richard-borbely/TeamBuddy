using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Commentary: EntityBase
    {
        public string text { get; set; }
        public Student name { get; set; }
        public DateTime commentary_time { get; set; }
    }
}
