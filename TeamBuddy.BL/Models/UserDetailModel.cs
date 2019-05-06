using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.BL.Models
{
    public class UserDetailModel : BaseModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
    }
}
