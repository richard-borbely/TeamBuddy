using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.BL.Models
{
    public class UserDetailModel : BaseModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Passwd { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
