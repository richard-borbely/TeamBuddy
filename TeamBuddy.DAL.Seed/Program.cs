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
            var userSuperser = new User
            {
                Id = Guid.NewGuid(),
                Username = "Superuser",
                Name = "Superuser",
                Password = "f",
                Gender = Gender.Male,
                Email = "f",
                Status = Status.Online
            };
            dbContext.Users.Add(userSuperser);

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

            var teamIFJ = new Team
            {
                Id = Guid.NewGuid(),
                Name = "IFJ",
                Description = "Members of IFJ team."
            };
            dbContext.Teams.Add(teamIFJ);

            var teamIPP = new Team
            {
                Id = Guid.NewGuid(),
                Name = "IPP",
                Description = "Members of IPP team."
            };
            dbContext.Teams.Add(teamIPP);

            var teamICS = new Team
            {
                Id = Guid.NewGuid(),
                Name = "ICS",
                Description = "Members of ICS team."
            };
            dbContext.Teams.Add(teamICS);

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

            var firstPostInIFJ = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our First Post",
                Text = "This subject is the true meaning of hell.",
                PostAdditionTime = DateTime.Now,
                Team = teamIFJ,
                User = userRichardBorbely
            };
            dbContext.Posts.Add(firstPostInIFJ);

            var secondPostInIFJ = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our Second Post",
                Text = "I wish I never done this project.",
                PostAdditionTime = DateTime.Now,
                Team = teamIFJ,
                User = userPavelKocourek
            };
            dbContext.Posts.Add(secondPostInIFJ);

            var firstPostInIPP = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our First Post",
                Text = "Dusan Kolar is a good guy",
                PostAdditionTime = DateTime.Now,
                Team = teamIPP,
                User = userAlexSporni
            };
            dbContext.Posts.Add(firstPostInIPP);

            var firstPostInICS = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our First Post",
                Text = "The most interesting project",
                PostAdditionTime = DateTime.Now,
                Team = teamICS,
                User = userRichardBorbely
            };
            dbContext.Posts.Add(firstPostInICS);

            var secondPostInICS = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our Second Post",
                Text = "My fingers are starting to hurt",
                PostAdditionTime = DateTime.Now,
                Team = teamICS,
                User = userDanielWeis
            };
            dbContext.Posts.Add(secondPostInICS);

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

            var firstCommentInIFJ = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "What an amazing experience to be here.",
                CommentAdditionTime = DateTime.Now,
                User = userAlexSporni,
                Post = firstPostInIFJ
            };
            dbContext.Comments.Add(firstCommentInIFJ);

            var secondCommentInIFJ = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "The weather outside is very positive.",
                CommentAdditionTime = DateTime.Now,
                User = userDanielWeis,
                Post = secondPostInIFJ
            };
            dbContext.Comments.Add(secondCommentInIFJ);

            var firstCommentInICS = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "The weather outside is very positive.",
                CommentAdditionTime = DateTime.Now,
                User = userPavelKocourek,
                Post = firstPostInICS
            };
            dbContext.Comments.Add(firstCommentInICS);

            var secondCommentInICS = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "I dont feel so good Mr. Stark",
                CommentAdditionTime = DateTime.Now,
                User = userIgorMjasojedov,
                Post = secondPostInICS
            };
            dbContext.Comments.Add(secondCommentInICS);

            var firstCommentInIPP = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "The Space is infinite",
                CommentAdditionTime = DateTime.Now,
                User = userRichardBorbely,
                Post = firstPostInIPP
            };
            dbContext.Comments.Add(firstCommentInIPP);

            var userIgorAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userIgorMjasojedov,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userIgorAdmins);

            var userIgorIfj = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userIgorMjasojedov,
                Team = teamIFJ
            };
            dbContext.UserTeams.Add(userIgorIfj);

            var userIgorIpp = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userIgorMjasojedov,
                Team = teamIPP
            };
            dbContext.UserTeams.Add(userIgorIpp);

            var userIgorIcs = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userIgorMjasojedov,
                Team = teamICS
            };
            dbContext.UserTeams.Add(userIgorIcs);

            var userAlexAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userAlexSporni,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userAlexAdmins);

            var userAlexIpp = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userAlexSporni,
                Team = teamIPP
            };
            dbContext.UserTeams.Add(userAlexIpp);

            var userAlexIcs = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userAlexSporni,
                Team = teamICS
            };
            dbContext.UserTeams.Add(userAlexIcs);

            var userRichardAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userRichardBorbely,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userRichardAdmins);

            var userRichardIfj = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userRichardBorbely,
                Team = teamIFJ
            };
            dbContext.UserTeams.Add(userRichardIfj);

            var userRichardIpp = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userRichardBorbely,
                Team = teamIPP
            };
            dbContext.UserTeams.Add(userRichardIpp);

            var userDanielAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userDanielWeis,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userDanielAdmins);

            var userDanielIfj = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userDanielWeis,
                Team = teamIFJ
            };
            dbContext.UserTeams.Add(userDanielIfj);

            var userDanielIcs = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userDanielWeis,
                Team = teamICS
            };
            dbContext.UserTeams.Add(userDanielIcs);

            var userPavelAdmins = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userPavelKocourek,
                Team = teamTeamBuddyAdmins
            };
            dbContext.UserTeams.Add(userPavelAdmins);

            var userPavelIcs = new UserTeam
            {
                Id = Guid.NewGuid(),
                User = userPavelKocourek,
                Team = teamICS
            };
            dbContext.UserTeams.Add(userPavelIcs);

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
