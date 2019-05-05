using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeamBuddy.BL.Mapper;
using TeamBuddy.BL.Models;
using TeamBuddy.DAL;
using TeamBuddy.DAL.Entities;
using TeamBuddy.DAL.Enumerations;

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
                .Select(_mapper.MaPostDetailModelFromEntity);
        }

        public IEnumerable<CommentDetailModel> GetAllComments()
        {
            return _dbContextFactory.CreateDbContext()
                .Comments
                .Include(u => u.User)
                .Select(_mapper.MapCommentDetailModelFromEntity);
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
                //dbContext.Entry(entity).State = EntityState.Unchanged;
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
                //dbContext.Entry(entity).State = EntityState.Unchanged;
                return _mapper.MapUserDetailModelFromEntity(entity);
            }
        }

        public PostDetailModel Create(PostDetailModel post)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapPostToEntity(post);
                dbContext.Posts.Add(entity);
                dbContext.SaveChanges();
                return _mapper.MaPostDetailModelFromEntity(entity);
            }
        }

        public CommentDetailModel Create(CommentDetailModel comment)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = _mapper.MapCommentToEntity(comment);
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
                //dbContext.Teams
                //    .First(t => t.Id == teamId)
                //    .UserInTeam
                //    .Add(new UserTeam()
                //    {
                //        User = entityUser,
                //        Team = entityTeam
                //    });
                //var team = new UserTeam()
                //{
                //    Id = Guid.NewGuid(),
                //    User = entityUser,
                //    Team = entityTeam
                //};

                //////var userPavelKocourek = new User
                //////{
                //////    Id = Guid.NewGuid(),
                //////    Username = "xkocur00",
                //////    Name = "Pavel Kocourek",
                //////    Password = "VudnnGPQ",
                //////    Gender = Gender.Male,
                //////    Email = "xkocur00@vutbr.cz",
                //////    Status = Status.Invisible
                //////};
                //////dbContext.Users.Add(userPavelKocourek);
                //////dbContext.SaveChanges();
                //////dbContext.Entry(userPavelKocourek).State = EntityState.Unchanged;

                //////var teamTeamBuddyAdmins = new Team
                //////{
                //////    Id = Guid.NewGuid(),
                //////    Name = "TeamBuddy",
                //////    Description = "Members of this team are administrators."
                //////};
                //////dbContext.Teams.Add(teamTeamBuddyAdmins);
                //////dbContext.SaveChanges();
                //////dbContext.Entry(teamTeamBuddyAdmins).State = EntityState.Unchanged;

                dbContext.Entry(entityTeam).State = EntityState.Unchanged;
                //dbContext.Entry(entityUser).State = EntityState.Unchanged;

                entityTeam.UserInTeam.Add(new UserTeam()
                {
                    Id = Guid.NewGuid(),
                    TeamId = entityTeam.Id,
                    UserId = entityUser.Id
                });
                dbContext.SaveChanges();
                //var ccc = new UserTeam()
                //{
                //    Id = Guid.NewGuid(),
                //    TeamId = teamTeamBuddyAdmins.Id,
                //    UserId = userPavelKocourek.Id

                //};
                ////dbContext.UserTeams.Add(ccc);
                //dbContext.UserTeams.Add(ccc);


                ////    });
                ////var Indquery2 = dbContext.UserTeams.Where(Ind => Ind.TeamId == teamId).FirstOrDefault();
                ////Indquery2.User = entityUser;
                //dbContext.SaveChanges();
                //dbContext.Teams.Update(teamTeamBuddyAdmins).State = EntityState.;

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
