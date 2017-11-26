using SleepLogASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SleepLogASP.DAL
{
    public class SleepContext: DbContext
    {
        public SleepContext() : base("SleepContext")
        {
        }
        public DbSet<Sleep> Sleeps { get; set; }
        public DbSet<SleepTime> SleepTimes { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}