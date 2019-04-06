using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeamBuddy.BL.Mapper;
using TeamBuddy.BL.Models;
using TeamBuddy.DAL;

namespace TeamBuddy.BL.Repositories
{
    public class TeamBuddyRepository : ITeamBuddyRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;
        public TeamBuddyRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public TeamDetailModel GetByName(string name)
        {
            var foundEntity = dbContextFactory
                .CreateDbContext()
                .Teams
                .Include(t => t.Posts)
                .FirstOrDefault(t => t.Name == name);
            return foundEntity == null ? null : mapper.MapTeamDetailModelFromEntity(foundEntity);
        }

        public UserDetailModel GetByEmail(string email)
        {
            var foundEntity = dbContextFactory
                .CreateDbContext()
                .Users
                .FirstOrDefault(t => t.Email == email);
            return foundEntity == null ? null : mapper.MapUserDetailModelFromEntity(foundEntity);
        }

        public TeamDetailModel Create(TeamDetailModel team)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapTeamToEntity(team);
                dbContext.Teams.Add(entity);
                dbContext.SaveChanges();
                return mapper.MapTeamDetailModelFromEntity(entity);
            }
        }

        public UserDetailModel Create(UserDetailModel user)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapUserToEntity(user);
                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return mapper.MapUserDetailModelFromEntity(entity);
            }
        }

        public PostDetailModel Create(PostDetailModel post)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapPostToEntity(post);
                dbContext.Posts.Add(entity);
                dbContext.SaveChanges();
                return mapper.MaPostDetailModelFromEntity(entity);
            }
        }

        public CommentDetailModel Create(CommentDetailModel comment)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapCommentToEntity(comment);
                dbContext.Comments.Add(entity);
                dbContext.SaveChanges();
                return mapper.MapCommentDetailModelFromEntity(entity);
            }
        }

        public void UpdateUser(UserDetailModel user)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapUserToEntity(user);
                dbContext.Users.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteTeam(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Teams.First(t => t.Id == id);
                dbContext.Teams.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Users.First(t => t.Id == id);
                dbContext.Users.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeletePost(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Posts.First(t => t.Id == id);
                dbContext.Posts.Remove(entity);
                dbContext.SaveChanges();
            }
        }

        public void DeleteComment(Guid id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Comments.First(t => t.Id == id);
                dbContext.Comments.Remove(entity);
                dbContext.SaveChanges();
            }
        }

    }
}
