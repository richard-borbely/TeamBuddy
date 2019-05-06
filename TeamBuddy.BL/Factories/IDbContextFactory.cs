using TeamBuddy.DAL;

namespace TeamBuddy.BL.Factories
{
    public interface IDbContextFactory
    {
        TeamBuddyDbContext CreateDbContext();
    }
}
