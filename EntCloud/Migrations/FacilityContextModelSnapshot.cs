﻿// <auto-generated />
using EntCloud.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntCloud.Migrations
{
    [DbContext(typeof(FacilityContext))]
    partial class FacilityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntCloud.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingNumber");

                    b.Property<int>("CityId");

                    b.Property<int>("CountryId");

                    b.Property<int>("StreetId");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntCloud.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Moskva"
                        },
                        new
                        {
                            Id = 2,
                            Name = "St.Peterburg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Voronezh"
                        });
                });

            modelBuilder.Entity("EntCloud.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ukraine"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Belarus"
                        });
                });

            modelBuilder.Entity("EntCloud.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<int>("OwnerId");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("EntCloud.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Streets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Leninskaya"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Leningradskaya"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sadovaya"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
