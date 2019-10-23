using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nextload.JXHouse.Framework;

namespace Nextload.JXHouse.Models.Context
{
    public class TumoverDbContext : DbContext
    {
        private Logger _logger = Logger.CreateLogger(typeof(TumoverDbContext));
        public TumoverDbContext() : base("name = tumoverStr")
        {
            Database.SetInitializer<TumoverDbContext>(null);
            Database.Log = sql => _logger.Info(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<HouseUsage> HouseUsages { get; set; }
        public DbSet<HouseUsage2> HouseUsage2s { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<TotalTumover> TotalTumovers { get; set; }
        public DbSet<Tumover> Tumovers { get; set; }
    }
}
