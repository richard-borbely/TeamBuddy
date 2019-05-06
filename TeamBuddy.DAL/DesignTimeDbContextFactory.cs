using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TeamBuddy.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TeamBuddyDbContext>
    {
        public TeamBuddyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TeamBuddyDbContext>();
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                                Initial Catalog = TeamBuddyDB;
                                MultipleActiveResultSets = True;
                                Integrated Security = True");
            return new TeamBuddyDbContext(optionsBuilder.Options);
        }
    }
}
