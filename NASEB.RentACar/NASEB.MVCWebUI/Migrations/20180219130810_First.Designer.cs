﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NASEB.DAL.Concrete.EF;
using System;

namespace NASEB.MVCWebUI.Migrations
{
    [DbContext(typeof(EFNASEBDBContext))]
    [Migration("20180219130810_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NASEB.Entities.Concrete.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("BranchID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("ExistingBranchID");

                    b.Property<string>("LicenseInfo")
                        .IsRequired();

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<int>("Status");

                    b.Property<int>("UserID");

                    b.HasKey("CarID");

                    b.HasIndex("ExistingBranchID");

                    b.HasIndex("UserID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("AuthorizedName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Fax")
                        .HasMaxLength(15);

                    b.Property<string>("OtherPhone")
                        .HasMaxLength(15);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("TaskAdministration")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("TaskNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("TradeRegisterNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("UserID");

                    b.Property<bool>("isActive");

                    b.HasKey("CompanyID");

                    b.HasIndex("UserID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int?>("CompanyID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PasportNumber");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long?>("TRIDNo");

                    b.Property<int>("UserID");

                    b.Property<bool>("isCorporate");

                    b.Property<bool>("isTRCitizen");

                    b.Property<bool>("isTRIDVerified");

                    b.HasKey("CustomerID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("TRIDNo")
                        .IsUnique()
                        .HasFilter("[TRIDNo] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Log", b =>
                {
                    b.Property<Guid>("LogID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Detail")
                        .IsRequired();

                    b.Property<int>("UserID");

                    b.HasKey("LogID");

                    b.HasIndex("UserID");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.NASEBRole", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.NASEBUser", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("BranchID");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("isActive");

                    b.HasKey("UserID");

                    b.HasIndex("BranchID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Rent", b =>
                {
                    b.Property<int>("RentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarID");

                    b.Property<int?>("CompanyID");

                    b.Property<int>("CustomerID");

                    b.Property<double?>("DamagePrice");

                    b.Property<double?>("DelayFine");

                    b.Property<int>("DeliveredBranchID");

                    b.Property<DateTime?>("DeliveredDate");

                    b.Property<bool>("PaymentComplate");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<double?>("RemaindDebt")
                        .IsRequired();

                    b.Property<int>("RentBranchID");

                    b.Property<int>("RentDay");

                    b.Property<DateTime>("RentEndDate");

                    b.Property<DateTime>("RentStartDate");

                    b.Property<double>("TotalRentPrice");

                    b.Property<double?>("TrafficTicket");

                    b.Property<int>("UserID");

                    b.Property<bool>("isCommercial");

                    b.Property<bool>("isComplate");

                    b.HasKey("RentID");

                    b.HasIndex("CarID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("DeliveredBranchID");

                    b.HasIndex("RentBranchID");

                    b.HasIndex("UserID");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.UserRole", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("RoleID");

                    b.HasKey("UserID", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Car", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.Branch", "ExistingBranch")
                        .WithMany("ExistingCars")
                        .HasForeignKey("ExistingBranchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NASEB.Entities.Concrete.NASEBUser", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Company", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.NASEBUser", "User")
                        .WithMany("Companies")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Customer", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.Company", "Company")
                        .WithMany("Customers")
                        .HasForeignKey("CompanyID");

                    b.HasOne("NASEB.Entities.Concrete.NASEBUser", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Log", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.NASEBUser", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.NASEBUser", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.Branch", "Branch")
                        .WithMany("Employees")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.Rent", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NASEB.Entities.Concrete.Company", "Company")
                        .WithMany("Rents")
                        .HasForeignKey("CompanyID");

                    b.HasOne("NASEB.Entities.Concrete.Customer", "Customer")
                        .WithMany("Rents")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NASEB.Entities.Concrete.Branch", "DeliveredBranch")
                        .WithMany("DeliveredRents")
                        .HasForeignKey("DeliveredBranchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NASEB.Entities.Concrete.Branch", "RentBranch")
                        .WithMany()
                        .HasForeignKey("RentBranchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NASEB.Entities.Concrete.NASEBUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NASEB.Entities.Concrete.UserRole", b =>
                {
                    b.HasOne("NASEB.Entities.Concrete.NASEBRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NASEB.Entities.Concrete.NASEBUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
