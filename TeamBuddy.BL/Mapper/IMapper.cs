using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.BL.Models;
using TeamBuddy.DAL.Entities;

namespace TeamBuddy.BL.Mapper
{
    public interface IMapper
    {
        Comment MapCommentToEntity(CommentDetailModel comment);
        Post MapPostToEntity(PostDetailModel post);
        Team MapTeamToEntity(TeamDetailModel team);
        User MapUserToEntity(UserDetailModel user);
        CommentDetailModel MapCommentDetailModelFromEntity(Comment comment);
        PostDetailModel MapPostDetailModelFromEntity(Post post);
        TeamDetailModel MapTeamDetailModelFromEntity(Team team);
        TeamListModel MapTeamListModelFromEntity(Team team);
        UserDetailModel MapUserDetailModelFromEntity(User user);
        UserListModel MapUserListModelFromEntity(User user);
    }
}
