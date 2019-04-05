using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.DAL
{
    public interface IDbContextFactory
    {
        TeamBuddyDbContext CreateDbContext();
    }
}
