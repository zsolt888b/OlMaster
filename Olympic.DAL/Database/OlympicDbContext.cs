using Microsoft.EntityFrameworkCore;
using Olympic.DAL.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympic.DAL.Database
{
    public class OlympicDbContext : DbContext
    {
        public OlympicDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Olympicon> Olympicons { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new NationalityConfig());
            builder.ApplyConfiguration(new OlympiconConfig());
            builder.ApplyConfiguration(new MedalConfig());
        }

    }
}
