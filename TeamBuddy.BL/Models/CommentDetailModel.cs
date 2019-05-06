using System;

namespace TeamBuddy.BL.Models
{
    public class CommentDetailModel : BaseModel
    {
        public string Text { get; set; }
        public DateTime CommentAdditionTime { get; set; }
        public UserDetailModel User { get; set; }
        public PostDetailModel Post { get; set; }
    }
}
