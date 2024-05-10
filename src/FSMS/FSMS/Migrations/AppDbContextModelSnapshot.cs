﻿// <auto-generated />
using System;
using FSMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FSMS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DispenserTank", b =>
                {
                    b.Property<Guid>("DispensersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TanksId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DispensersId", "TanksId");

                    b.HasIndex("TanksId");

                    b.ToTable("DispenserTank", "Fuel");
                });

            modelBuilder.Entity("FSMS.Entities.Allocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Allocations", "User");
                });

            modelBuilder.Entity("FSMS.Entities.Dates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UnitPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UnitPriceId");

                    b.ToTable("Dates", "Sales");
                });

            modelBuilder.Entity("FSMS.Entities.Dispenser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Dispensers", "Fuel");
                });

            modelBuilder.Entity("FSMS.Entities.Nozzle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DispenserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DispenserId");

                    b.ToTable("Nozzles", "Fuel");
                });

            modelBuilder.Entity("FSMS.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DispenserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NozzleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("UnitPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DispenserId");

                    b.HasIndex("NozzleId");

                    b.HasIndex("UnitPriceId");

                    b.ToTable("Sales", "Sales");
                });

            modelBuilder.Entity("FSMS.Entities.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TankId");

                    b.ToTable("Sensors", "Measures");
                });

            modelBuilder.Entity("FSMS.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<Guid>("TankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TankId");

                    b.ToTable("States", "Measures");
                });

            modelBuilder.Entity("FSMS.Entities.Tank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<string>("Sensors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tanks", "Fuel");
                });

            modelBuilder.Entity("FSMS.Entities.UnitPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Fuel")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("UnitPrices", "Sales");
                });

            modelBuilder.Entity("FSMS.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", "User");
                });

            modelBuilder.Entity("FSMS.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles", "User");
                });

            modelBuilder.Entity("DispenserTank", b =>
                {
                    b.HasOne("FSMS.Entities.Dispenser", null)
                        .WithMany()
                        .HasForeignKey("DispensersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSMS.Entities.Tank", null)
                        .WithMany()
                        .HasForeignKey("TanksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FSMS.Entities.Allocation", b =>
                {
                    b.HasOne("FSMS.Entities.User", null)
                        .WithMany("Allocations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FSMS.Entities.Dates", b =>
                {
                    b.HasOne("FSMS.Entities.UnitPrice", "UnitPrice")
                        .WithMany("Dates")
                        .HasForeignKey("UnitPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnitPrice");
                });

            modelBuilder.Entity("FSMS.Entities.Nozzle", b =>
                {
                    b.HasOne("FSMS.Entities.Dispenser", null)
                        .WithMany("Nozzles")
                        .HasForeignKey("DispenserId");
                });

            modelBuilder.Entity("FSMS.Entities.Sale", b =>
                {
                    b.HasOne("FSMS.Entities.Dispenser", null)
                        .WithMany("Sales")
                        .HasForeignKey("DispenserId");

                    b.HasOne("FSMS.Entities.Nozzle", "Nozzle")
                        .WithMany()
                        .HasForeignKey("NozzleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSMS.Entities.UnitPrice", "UnitPrice")
                        .WithMany()
                        .HasForeignKey("UnitPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nozzle");

                    b.Navigation("UnitPrice");
                });

            modelBuilder.Entity("FSMS.Entities.Sensor", b =>
                {
                    b.HasOne("FSMS.Entities.Tank", "Tank")
                        .WithMany()
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("FSMS.Entities.State", b =>
                {
                    b.HasOne("FSMS.Entities.Tank", "Tank")
                        .WithMany("TankStates")
                        .HasForeignKey("TankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tank");
                });

            modelBuilder.Entity("FSMS.Entities.User", b =>
                {
                    b.HasOne("FSMS.Entities.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FSMS.Entities.Dispenser", b =>
                {
                    b.Navigation("Nozzles");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("FSMS.Entities.Tank", b =>
                {
                    b.Navigation("TankStates");
                });

            modelBuilder.Entity("FSMS.Entities.UnitPrice", b =>
                {
                    b.Navigation("Dates");
                });

            modelBuilder.Entity("FSMS.Entities.User", b =>
                {
                    b.Navigation("Allocations");
                });

            modelBuilder.Entity("FSMS.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
