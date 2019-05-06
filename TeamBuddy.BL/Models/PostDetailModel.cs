using System;

namespace TeamBuddy.BL.Models
{
    public class PostDetailModel : BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PostAdditionTime { get; set; }
        public UserDetailModel User { get; set; }
        public TeamDetailModel Team { get; set; }
    }
}
