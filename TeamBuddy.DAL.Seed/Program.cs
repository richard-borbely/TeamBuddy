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
                Password = "mjasojedov",
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
                Password = "sporni",
                Gender = Gender.Male,
                Email = "xsporn01@vutbr.cz",
                Status = Status.Online
            };
            dbContext.Users.Add(userAlexSporni);

            var userRichardBorbely = new User
            {
                Id = Guid.NewGuid(),
                Username = "xborbe00",
                Name = "Richard Borbély",
                Password = "borbely",
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
                Password = "weis",
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
                Password = "kocourek",
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

            var firstPostInAdmins = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our First Post",
                Text = "Our first post in the admin team how amazing.",
                PostAdditionTime = DateTime.Now,
                Team = teamTeamBuddyAdmins,
                User = userIgorMjasojedov
            };
            dbContext.Posts.Add(firstPostInAdmins);

            var secondPostInAdmins = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our Second Post",
                Text = "Our second post in the admin team how cool.",
                PostAdditionTime = DateTime.Now,
                Team = teamTeamBuddyAdmins,
                User = userAlexSporni
            };
            dbContext.Posts.Add(secondPostInAdmins);

            var thirdPostInAdmins = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our Third Post",
                Text = "Our third post in the admin team how boring.",
                PostAdditionTime = DateTime.Now,
                Team = teamTeamBuddyAdmins,
                User = userDanielWeis
            };
            dbContext.Posts.Add(thirdPostInAdmins);

            var firstCommentInAdmins = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = userIgorMjasojedov,
                Post = firstPostInAdmins
            };
            dbContext.Comments.Add(firstCommentInAdmins);

            var secondCommentInAdmins = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "What an amazing experience to be here.",
                CommentAdditionTime = DateTime.Now,
                User = userRichardBorbely,
                Post = secondPostInAdmins
            };
            dbContext.Comments.Add(secondCommentInAdmins);

            var userIgorAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userIgorMjasojedov,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userIgorAdmins);

            var userAlexAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userAlexSporni,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userAlexAdmins);

            var userRichardAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userRichardBorbely,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userRichardAdmins);

            var userDanielAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userDanielWeis,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userDanielAdmins);

            var userPavelAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userPavelKocourek,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userPavelAdmins);

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
            var optionsBuilder = new DbContextOptionsBuilder<TeamBuddyDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                                        Initial Catalog = TeamBuddyDB;
                                                        MultipleActiveResultSets = True;
                                                        Integrated Security = True; ");
            return new TeamBuddyDbContext(optionsBuilder.Options);
        }
    }
}
