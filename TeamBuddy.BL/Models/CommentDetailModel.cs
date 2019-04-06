using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL.Entities;

namespace TeamBuddy.BL.Models
{
    public class CommentDetailModel : BaseModel
    {
        public string Text { get; set; }
        public DateTime Time_of_comment { get; set; }
        public UserDetailModel User { get; set; }
    }
}
