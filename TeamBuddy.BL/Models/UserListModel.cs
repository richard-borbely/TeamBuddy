using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.BL.Models
{
    public class UserListModel : BaseModel
    {
        public string Username { get; set; }
        public Status Status { get; set; }
    }
}
