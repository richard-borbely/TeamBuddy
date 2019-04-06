using Microsoft.EntityFrameworkCore;

namespace TeamBuddy.DAL.Tests
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        public TeamBuddyDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeamBuddyDbContext>();
            optionsBuilder.UseInMemoryDatabase("TeamBuddyDb");
            return new TeamBuddyDbContext(optionsBuilder.Options);
        }
    }
}
