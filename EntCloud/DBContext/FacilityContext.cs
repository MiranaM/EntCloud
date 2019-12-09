using EntCloud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EntCloud.DBContext
{
    public class FacilityContext : DbContext
    {   
        public FacilityContext (DbContextOptions<FacilityContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=localhost;" + "port=3306;" + "userid=root;" + "password=admin;" + "database=ent_facilities");
        //}

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes().Select(c => c.ClrType))
            {
                modelBuilder.Entity(type, b =>
                {
                    b.Property("Id").HasValueGenerator<IntValueGenerator>();
                });
            }           

            modelBuilder.Entity<Street>().HasData(
                    new Street
                    {
                        Id = 1,
                        Name = "Leninskaya",
                    },
                    new Street
                    {
                        Id = 2,
                        Name = "Leningradskaya",
                    },
                    new Street
                    {
                        Id = 3,
                        Name = "Sadovaya",
                    }
                );

            modelBuilder.Entity<City>().HasData(
                    new City
                    {
                        Id = 1,
                        Name = "Moskva",
                    },
                    new City
                    {
                        Id = 2,
                        Name = "St.Peterburg",
                    },
                    new City
                    {
                        Id = 3,
                        Name = "Voronezh",
                    }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Russia",
                },
                new Country
                {
                    Id = 2,
                    Name = "Ukraine",
                },
                new Country
                {
                    Id = 3,
                    Name = "Belarus",
                }
            );

            base.OnModelCreating(modelBuilder);
        }

        public class IntValueGenerator : TemporaryNumberValueGenerator<int>
        {
            private int _current = 0;

            public override int Next(EntityEntry entry)
            {
                return Interlocked.Increment(ref _current);
            }
        }
    }
}
