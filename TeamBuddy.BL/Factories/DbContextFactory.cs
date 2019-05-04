﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TeamBuddy.DAL;

namespace TeamBuddy.BL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        public TeamBuddyDbContext CreateDbContext()
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