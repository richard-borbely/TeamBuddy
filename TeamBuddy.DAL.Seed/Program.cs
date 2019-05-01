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
            var userAlexanderOvechkin = new User
            {
                Id = Guid.NewGuid(),
                Username = "xovca00",
                Name = "Alexander Ovechkin",
                Password = "veryStrongPass13",
                Gender = Gender.Male,
                Email = "ovechkin.alex@gmail.com",
                Status = Status.Offline
            };
            dbContext.Users.Add(userAlexanderOvechkin);

            var teamTeamBuddyAdmins = new Team
            {
                Id = Guid.NewGuid(),
                Name = "TeamBuddy",
                Description = "The first team of this app."
            };
            dbContext.Teams.Add(teamTeamBuddyAdmins);

            var postFirstPost = new Post
            {
                Id = Guid.NewGuid(),
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                Team = teamTeamBuddyAdmins,
                User = userAlexanderOvechkin
            };
            dbContext.Posts.Add(postFirstPost);

            var commentFirstComment = new Comment
            {
                Id = Guid.NewGuid(),
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = userAlexanderOvechkin,
                Post = postFirstPost
            };
            dbContext.Comments.Add(commentFirstComment);
            /*
            var userTeam_First = new UserTeam
            {
                Id = userAlexanderOvechkin.Id,
                User = userAlexanderOvechkin,
                TeamId = teamTeamBuddyAdmins.Id,
                Team = teamTeamBuddyAdmins
            };
            */
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
