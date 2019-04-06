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


    }
}
