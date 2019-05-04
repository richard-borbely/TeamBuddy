using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.DAL;

namespace TeamBuddy.BL.Factories
{
    public interface IDbContextFactory
    {
        TeamBuddyDbContext CreateDbContext();
    }
}
