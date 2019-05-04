using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.BL.Models;

namespace TeamBuddy.BL.Messages
{
    public class LogInMessage
    {
        public UserDetailModel SignedUser { get; set; }
    }
}
