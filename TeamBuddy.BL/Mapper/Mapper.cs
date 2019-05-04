using TeamBuddy.BL.Models;
using TeamBuddy.DAL.Entities;
using TeamBuddy.DAL.Services;

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
                CommentAdditionTime = comment.CommentAdditionTime,
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
                PostAdditionTime = post.PostAdditionTime,
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
                Username = user.Username,
                Name = user.Name,
                //Password = Hasher.GetHash(user.Password),
                Password = user.Password,
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
                CommentAdditionTime = comment.CommentAdditionTime,
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
                PostAdditionTime = post.PostAdditionTime,
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
                Username = user.Username,
                Name = user.Name,
                Password = user.Password,
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
                Username = user.Username,
                Status = user.Status
            };
        }
    }
}
