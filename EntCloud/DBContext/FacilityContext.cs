using EntCloud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntCloud.DBContext
{
    public class FacilityContext : DbContext
    {   
        public FacilityContext (DbContextOptions<FacilityContext> options) : base(options)
        {
        }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
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
        }
    }
}
