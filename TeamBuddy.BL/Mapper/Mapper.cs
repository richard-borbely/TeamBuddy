﻿using TeamBuddy.BL.Models;
using TeamBuddy.DAL.Entities;

namespace TeamBuddy.BL.Mapper
{
    public class Mapper : IMapper
    {
        public Comment MapCommentToEntity(CommentDetailModel comment)
        {
            return new Comment
            {
                Id = comment.Id,
                Text = comment.Text,
                Time_of_comment = comment.Time_of_comment,
                User = MapUserToEntity(comment.User)
            };
        }

        public Post MapPostToEntity(PostDetailModel post)
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                Text = post.Text,
                Time_of_post = post.Time_of_post,
                User = MapUserToEntity(post.User)
            };
        }

        public Team MapTeamToEntity(TeamDetailModel team)
        {
            return new Team
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description
            };
        }

        public User MapUserToEntity(UserDetailModel user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Passwd = user.Passwd, //todo Hashing
                Gender = user.Gender,
                Email = user.Email,
                Status = user.Status
            };
        }

        public CommentDetailModel MapCommentDetailModelFromEntity(Comment comment)
        {
            return new CommentDetailModel
            {
                Id = comment.Id,
                Text = comment.Text,
                Time_of_comment = comment.Time_of_comment,
                User = MapUserDetailModelFromEntity(comment.User)
            };
        }

        public PostDetailModel MaPostDetailModelFromEntity(Post post)
        {
            return new PostDetailModel
            {
                Id = post.Id,
                Title = post.Title,
                Text = post.Text,
                Time_of_post = post.Time_of_post,
                User = MapUserDetailModelFromEntity(post.User)
            };
        }

        public TeamDetailModel MapTeamDetailModelFromEntity(Team team)
        {
            return new TeamDetailModel
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description
            };
        }

        public TeamListModel MapTeamListModelFromEntity(Team team)
        {
            return new TeamListModel
            {
                Id = team.Id,
                Name = team.Name
            };
        }

        public UserDetailModel MapUserDetailModelFromEntity(User user)
        {
            return new UserDetailModel
            {
                Id = user.Id,
                Name = user.Name,
                Passwd = user.Passwd, //todo Hashing
                Gender = user.Gender,
                Email = user.Email,
                Status = user.Status
            };
        }

        public UserListModel MapUserListModelFromEntity(User user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Status = user.Status
            };
        }
    }
}