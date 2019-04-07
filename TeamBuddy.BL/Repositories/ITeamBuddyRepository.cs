using System;
using TeamBuddy.BL.Models;

namespace TeamBuddy.BL.Repositories
{
    public interface ITeamBuddyRepository
    {
        TeamDetailModel GetByName(string name);
        UserDetailModel GetByEmail(string email);
        UserDetailModel GetByUsername(string username);
        TeamDetailModel Create(TeamDetailModel team);
        UserDetailModel Create(UserDetailModel user);
        PostDetailModel Create(PostDetailModel post);
        CommentDetailModel Create(CommentDetailModel comment);
        void AddUserToTeam(UserDetailModel user, Guid teamId);
        void UpdateUser(UserDetailModel user);
        void DeleteTeam(Guid id);
        void DeleteUser(Guid id);
        void DeletePost(Guid id);
        void DeleteComment(Guid id);
    }
}
