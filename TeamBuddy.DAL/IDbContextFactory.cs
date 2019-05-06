namespace TeamBuddy.DAL
{
    public interface IDbContextFactory
    {
        TeamBuddyDbContext CreateDbContext();
    }
}
