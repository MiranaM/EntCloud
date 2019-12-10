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
        public FacilityContext (DbContextOptions<FacilityContext> options) : base(options) {}

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //чтобы был инкремент Id
            foreach (var type in modelBuilder.Model.GetEntityTypes().Select(c => c.ClrType))
            {
                modelBuilder.Entity(type, b =>
                {
                    b.Property("Id").HasValueGenerator<IntValueGenerator>();
                });
            }

            #region ModelBuilder заполнение базы тестовыми данными
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

            modelBuilder.Entity<Address>().HasData(
                    new Address
                    {
                        Id = 1,
                        CountryId = 1,
                        CityId = 1,
                        StreetId = 1,
                        BuildingNumber = 23
                    },
                    new Address
                    {
                        Id = 2,
                        CountryId = 1,
                        CityId = 2,
                        StreetId = 1,
                        BuildingNumber = 12

                    },
                    new Address
                    {
                        Id = 3,
                        CountryId = 1,
                        CityId = 3,
                        StreetId = 2,
                        BuildingNumber = 3
                    }
                );

            modelBuilder.Entity<Facility>().HasData(
                    new Facility
                    {
                        Id = 1,
                        AddressId = 1,
                        OwnerId = 1,
                        Telephone = "123456789"
                    },
                    new Facility
                    {
                        Id = 2,
                        AddressId = 2,
                        OwnerId = 2,
                        Telephone = "98765623"
                    },
                    new Facility
                    {
                        Id = 3,
                        AddressId = 3,
                        OwnerId = 3,
                        Telephone = "2546875243"
                    }
                );
            #endregion

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
