using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeamBuddy.BL.Mapper;
using TeamBuddy.BL.Models;
using TeamBuddy.DAL;
using TeamBuddy.DAL.Entities;

namespace TeamBuddy.BL.Repositories
{
    public class TeamBuddyRepository : ITeamBuddyRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;

        public TeamBuddyRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this._dbContextFactory = dbContextFactory;
            this._mapper = mapper;
        }

        public IEnumerable<TeamListModel> GetAllTeams()
        {
            return _dbContextFactory.CreateDbContext()
                .Teams
                .Select(_mapper.MapTeamListModelFromEntity);
        }

        public IEnumerable<TeamListModel> GetAllMyTeams(Guid userId)
        {
            return _dbContextFactory.CreateDbContext()
                .UserTeams
                .Where(u => u.UserId == userId)
                .Select(t => _mapper.MapTeamListModelFromEntity(t.Team));
        }

        public IEnumerable<UserListModel> GetAllUsers()
        {
            return _dbContextFactory.CreateDbContext()
                .Users
                .Select(_mapper.MapUserListModelFromEntity);
        }

        public IEnumerable<UserListModel> GetAllUsersInTeam(Guid teamId)
        {
            return _dbContextFactory.CreateDbContext()
                .UserTeams
                .Where(u => u.TeamId == teamId)
                .Select(t => _mapper.MapUserListModelFromEntity(t.User));
        }

        public IEnumerable<PostDetailModel> GetAllPosts()
        {
            return _dbContextFactory.CreateDbContext()
                .Posts
                .Include(u => u.User)
                .Select(_mapper.MapPostDetailModelFromEntity);
        }

        public IEnumerable<PostDetailModel> GetAllPostsInTeam(Guid teamId)
        {
            TeamDetailModel TeamModel = GetTyamById(teamId);
            var entityTeam = _mapper.MapTeamToEntity(TeamModel);
            var foundEntity = _dbContextFactory.CreateDbContext()
                .Posts
                .Include(u => u.User)
                .Include(t => t.Team)
                .Where(t => t.Team == entityTeam)
                .Select(p => _mapper.MapPostDetailModelFromEntity(p));

            return foundEntity;
        }

        public IEnumerable<CommentDetailModel> GetAllComments()
        {
            return _dbContextFactory.CreateDbContext()
                .Comments
                .Include(u => u.User)
                .Include(p=>p.Post)
                .Select(_mapper.MapCommentDetailModelFromEntity);
        }

        public IEnumerable<CommentDetailModel> GetAllCommentsInPost(Guid postId)
        {
            PostDetailModel PostModel = GetPostById(postId);
            var entityPost = _mapper.MapPostToEntity(PostModel);
            var foundEntity = _dbContextFactory.CreateDbContext()
                .Comments
                .Include(u => u.User)
                .Include(p => p.Post)
                .Include(u=>u.Post.Team)
                .Include(u => u.Post.User)
                .Where(p => p.Post == entityPost)
                .Select(c => _mapper.MapCommentDetailModelFromEntity(c));
            return foundEntity;
        }

        public TeamDetailModel GetByName(string name)
        {
            var foundEntity = _dbContextFactory
                .CreateDbContext()
                .Teams
                .Include(t => t.Posts)
                .FirstOrDefault(t => t.Name == name);
            return foundEntity == null ? null : _mapper.MapTeamDetailModelFromEntity(foundEntity);
        }

        public TeamDetailModel GetTyamById(Guid Id)
        {
            var foundEntity = _dbContextFactory
                .CreateDbContext()
                .Teams
                .FirstOrDefault(t => t.Id == Id);
            return foundEntity == null ? null : _mapper.MapTeamDetailModelFromEntity(foundEntity);
        }

        public PostDetailModel GetPostById(Guid Id)
        {
            var foundEntity = _dbContextFactory
                .CreateDbContext()
                .Posts
                .Include(u => u.User)
                .Include(u => u.Team)
                .FirstOrDefault(t => t.Id == Id);
            return foundEntity == null ? null : _mapper.MapPostDetailModelFromEntity(foundEntity);
        }

        public UserDetailModel GetByEmail(string email)
        {
            var foundEntity = _dbContextFactory
                .CreateDbContext()
                .Users
                .FirstOrDefault(t => t.Email == email);
            return foundEntity == null ? null : _mapper.MapUserDetailModelFromEntity(foundEntity);
        }

        public UserDetailModel GetByUsername(string username)
        {
            var foundEntity = _dbContextFactory
                .CreateDbContext()
                .Users
                .FirstOrDefault(t => t.Username == username);
            return foundEntity == null ? null : _mapper.MapUserDetailModelFromEntity(foundEntity);
        }

        public TeamDetailModel Create(TeamDetailModel team)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapTeamToEntity(team);
                dbContext.Teams.Add(entity);
                dbContext.SaveChanges();
                
                return _mapper.MapTeamDetailModelFromEntity(entity);
            }
        }

        public UserDetailModel Create(UserDetailModel user)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapUserToEntity(user);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                
                return _mapper.MapUserDetailModelFromEntity(entity);
            }
        }

        public PostDetailModel Create(PostDetailModel post, Guid teamId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapPostToEntity(post);
                dbContext.Entry(entity).State = EntityState.Unchanged;
                dbContext.Posts.Add(entity);
                dbContext.SaveChanges();

                return _mapper.MapPostDetailModelFromEntity(entity);
            }
        }

        public CommentDetailModel Create(CommentDetailModel comment)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapCommentToEntity(comment);
                dbContext.Entry(entity).State = EntityState.Unchanged;
                dbContext.Comments.Add(entity);
                dbContext.SaveChanges();

                return _mapper.MapCommentDetailModelFromEntity(entity);
            }
        }

        public void AddUserToTeam(UserDetailModel user, Guid teamId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                TeamDetailModel TeamModel = GetTyamById(teamId);
                var entityUser = _mapper.MapUserToEntity(user);
                var entityTeam = _mapper.MapTeamToEntity(TeamModel);
                dbContext.Entry(entityTeam).State = EntityState.Unchanged;
                entityTeam.UserInTeam.Add(new UserTeam()
                {
                    Id = Guid.NewGuid(),
                    TeamId = entityTeam.Id,
                    UserId = entityUser.Id
                });
                dbContext.SaveChanges();
            }
        }

        public void RemoveUserFromTeam(UserDetailModel user, Guid teamId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = dbContext
                    .UserTeams
                    .Where(u => u.UserId == user.Id)
                    .First(t => t.TeamId == teamId);
                    
                dbContext.UserTeams.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void UpdateUser(UserDetailModel user)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapUserToEntity(user);
                dbContext.Users.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteTeam(Guid id)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Teams.First(t => t.Id == id);
                dbContext.Teams.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(Guid id)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == id);
                dbContext.Users.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeletePost(Guid id)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Posts.First(t => t.Id == id);
                dbContext.Posts.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteComment(Guid id)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Comments.First(t => t.Id == id);
                dbContext.Comments.Remove(entity);
                dbContext.SaveChanges();
            }
        }
    }
}
