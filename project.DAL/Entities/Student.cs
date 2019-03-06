using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Student: EntityBase
    {
        public string email { get; set; }
        public string name { get; set; }
        public string passwd { get; set; }
    }
}
