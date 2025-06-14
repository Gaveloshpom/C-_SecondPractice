﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AutoParkContext))]
    partial class AutoParkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("Car", b =>
                {
                    b.Property<string>("CarNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EnginePower")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("FuelConsumption")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseYearMonth")
                        .HasColumnType("TEXT");

                    b.HasKey("CarNumber");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Departure", b =>
                {
                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<int>("DriverNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<string>("CarNumber")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<int>("Distance")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartureDate", "DriverNumber", "CarNumber");

                    b.HasIndex("CarNumber");

                    b.HasIndex("DriverNumber");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("Driver", b =>
                {
                    b.Property<int>("DriverNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LicenseCategory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LicenseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("PassportNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.HasKey("DriverNumber");

                    b.HasIndex("PassportSeries", "PassportNumber")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Departure", b =>
                {
                    b.HasOne("Car", "Car")
                        .WithMany("Departures")
                        .HasForeignKey("CarNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Driver", "Driver")
                        .WithMany("Departures")
                        .HasForeignKey("DriverNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Car", b =>
                {
                    b.Navigation("Departures");
                });

            modelBuilder.Entity("Driver", b =>
                {
                    b.Navigation("Departures");
                });
#pragma warning restore 612, 618
        }
    }
}
