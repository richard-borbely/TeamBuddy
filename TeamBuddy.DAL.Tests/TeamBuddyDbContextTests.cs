using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TeamBuddy.DAL.Entities;
using TeamBuddy.DAL.Enumerations;


namespace TeamBuddy.DAL.Tests
{
    public class TeamBuddyDbContextTests
    {
        private readonly IDbContextFactory dbContextFactory;

        public TeamBuddyDbContextTests()
        {
            dbContextFactory = new InMemoryDbContextFactory();
        }


        [Fact]
        public void CreateUserTest()
        {
            //Arrange
            var user = new User
            {
                Name = "Dimitrij Orlov",
                Gender = Gender.Male,
                Email = "orlov.dima@gmail.com",
                Status = Status.Offline
            };

            //Act
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
               
            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                User retrievedUser = null;
                try
                {
                    retrievedUser = dbContext.Users.First(t => t.Id == user.Id);
                    Assert.NotNull(retrievedUser);
                }
                finally
                {
                    //Teardown
                    if (retrievedUser != null)
                    {
                        dbContext.Users.Remove(retrievedUser);
                    }
                }
            }
        }

        [Fact]
        public void CreateTeamTest()
        {
            //Arrange
            var team = new Team
            {
                Name = "TeamBoddy",
                Description = "The first team of this app."
            };

            //Act
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Team retrievedTeam = null;
                try
                {
                    retrievedTeam = dbContext.Teams.First(t => t.Id == team.Id);
                    Assert.NotNull(retrievedTeam);
                }
                finally
                {
                    //Teardown
                    if (retrievedTeam != null)
                    {
                        dbContext.Teams.Remove(retrievedTeam);
                    }
                }
            }
        }

        [Fact]
        public void CreatePostTest()
        {
            //Arrange
            var post = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                Time_of_post = DateTime.Now,
                User = new User
                {
                    Name = "Dimitrij Orlov",
                    Gender = Gender.Male,
                    Email = "orlov.dima@gmail.com",
                    Status = Status.Offline
                },
                Team = new Team
                {
                    Name = "TeamBoddy",
                    Description = "The first team of this app."
                }
            };

            //Act
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Post retrievedPost = null;
                try
                {
                    retrievedPost = dbContext.Posts
                        .Include(p => p.User)
                        .Include(p => p.Team)
                        .First(p => p.Id == post.Id);
                    Assert.NotNull(retrievedPost);
                    Assert.NotNull(retrievedPost.User);
                    Assert.NotNull(retrievedPost.Team);
                    var retrievedUser = dbContext.Users
                        .First(u => u.Id == post.User.Id);
                    Assert.NotNull(retrievedUser);
                    var retrievedTeam = dbContext.Teams
                        .First(t => t.Id == post.Team.Id);
                    Assert.NotNull(retrievedTeam);
                }
                finally
                {
                    //Teardown
                    if (retrievedPost != null)
                    {
                        dbContext.Remove(retrievedPost);
                    }
                }
            }
        }
    
    }
}
