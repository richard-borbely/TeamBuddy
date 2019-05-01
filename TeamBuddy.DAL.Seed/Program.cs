using TeamBuddy.DAL.Entities;
using TeamBuddy.DAL.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;

namespace TeamBuddy.DAL.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = CreateDbContext())
            {
                ClearDatabase(dbContext);
                SeedData(dbContext);
            }
        }

        private static void SeedData(TeamBuddyDbContext dbContext)
        {
            var userIgorMjasojedov = new User
            {
                Id = Guid.NewGuid(),
                Username = "xmjaso00",
                Name = "Igor Mjasojedov",
                Password = "8EZofBDj",
                Gender = Gender.Male,
                Email = "xmjaso00@vutbr.cz",
                Status = Status.Offline
            };
            dbContext.Users.Add(userIgorMjasojedov);

            var userAlexSporni = new User
            {
                Id = Guid.NewGuid(),
                Username = "xsporn01",
                Name = "Alex Sporni",
                Password = "HfCyRJRf",
                Gender = Gender.Male,
                Email = "xsporn01@vutbr.cz",
                Status = Status.Online
            };
            dbContext.Users.Add(userAlexSporni);

            var userRichardBorbely = new User
            {
                Id = Guid.NewGuid(),
                Username = "xborbe00",
                Name = "Richard Borbely",
                Password = "WytZkYkg",
                Gender = Gender.Male,
                Email = "xborbe00@vutbr.cz",
                Status = Status.DoNotDisturb
            };
            dbContext.Users.Add(userRichardBorbely);

            var userDanielWeis = new User
            {
                Id = Guid.NewGuid(),
                Username = "xweisd00",
                Name = "Daniel Weis",
                Password = "RBoGVLXo",
                Gender = Gender.Male,
                Email = "xweisd00@vutbr.cz",
                Status = Status.Idle
            };
            dbContext.Users.Add(userDanielWeis);

            var userPavelKocourek = new User
            {
                Id = Guid.NewGuid(),
                Username = "xkocur00",
                Name = "Pavel Kocourek",
                Password = "VudnnGPQ",
                Gender = Gender.Male,
                Email = "xkocur00@vutbr.cz",
                Status = Status.Invisible
            };
            dbContext.Users.Add(userPavelKocourek);

            var teamTeamBuddyAdmins = new Team
            {
                Id = Guid.NewGuid(),
                Name = "TeamBuddy",
                Description = "Members of this team are administrators."
            };
            dbContext.Teams.Add(teamTeamBuddyAdmins);

            var postFirstPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                Team = teamTeamBuddyAdmins,
                User = userIgorMjasojedov
            };
            dbContext.Posts.Add(postFirstPost);

            var commentFirstComment = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = userIgorMjasojedov,
                Post = postFirstPost
            };
            dbContext.Comments.Add(commentFirstComment);
            
            var userTeam_First = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userIgorMjasojedov,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userTeam_First);

            var new_user_alex = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userAlexSporni,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(new_user_alex);
           
            var new_user_richard = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userRichardBorbely,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(new_user_richard);
            
            var new_user_daniel = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userDanielWeis,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(new_user_daniel);
            
            var new_user_pavel = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userPavelKocourek,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(new_user_pavel);

            dbContext.SaveChanges();
        }

        
        private static void ClearDatabase(TeamBuddyDbContext dbContext)
        {
            dbContext.RemoveRange(dbContext.Users);
            dbContext.RemoveRange(dbContext.Teams);
            dbContext.RemoveRange(dbContext.Posts);
            dbContext.RemoveRange(dbContext.Comments);
            dbContext.SaveChanges();
        }


        private static TeamBuddyDbContext CreateDbContext()
        {
            var optionsBuilder =  new DbContextOptionsBuilder<TeamBuddyDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                                        Initial Catalog = TeamBuddyDB;
                                                        MultipleActiveResultSets = True;
                                                        Integrated Security = True; ");
            return new TeamBuddyDbContext(optionsBuilder.Options);
        }
    }
}
