using System;
using System.Collections.Generic;
using System.Text;

namespace project.DAL.Entities
{
    public class Team: EntityBase
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
