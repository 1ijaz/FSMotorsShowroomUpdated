﻿// <auto-generated />
using System;
using FSMotorsShowroom.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FSMotorsShowroom.Migrations
{
    [DbContext(typeof(FSDbContext))]
    [Migration("20231102184437_appuser")]
    partial class appuser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FSMotorsShowroom.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("BackImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BodyImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CarModeilId")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("CarStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.Property<string>("EngineImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelMilage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorsePower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InteriorImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MaintananceCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MakeCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MakeYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoOfCylinders")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassengerCapacity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SalesTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ShowroomCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TankCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TransmissionMode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarId");

                    b.HasIndex("CarModeilId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.CarModel", b =>
                {
                    b.Property<int>("CarModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarModelId"));

                    b.Property<string>("CarModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarModelId");

                    b.ToTable("carModels");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.Investment", b =>
                {
                    b.Property<int>("InvestmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvestmentId"));

                    b.Property<decimal>("BuyingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CarStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvestorId")
                        .HasColumnType("int");

                    b.Property<decimal?>("MaintananceCost")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalesTax")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SellingPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ShowroomCost")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SoldDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TotalPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvestmentId");

                    b.HasIndex("CarId");

                    b.HasIndex("InvestorId");

                    b.ToTable("investments");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.Investor", b =>
                {
                    b.Property<int>("InvestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvestorId"));

                    b.Property<decimal?>("InvestUnallocatedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InvestorAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestorContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalInvestAmount")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvestorId");

                    b.ToTable("investors");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.Showroom", b =>
                {
                    b.Property<int>("ShowroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowroomId"));

                    b.Property<string>("ShowroomAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShowroomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShowroomId");

                    b.ToTable("Showroom");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuyerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuyerContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TaxRate")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c89311e5-e6ad-48e4-a4fb-679d9ad01b7e",
                            Email = "Admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEENwf1j0Oiy0l6PxmKjJwo8wP6WCv8BRlMl/gBrhPGC5GYg9r378IpqwEvq4+kQ4WA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "12ecbb28-e1bf-4403-bbee-34eca7d337f4",
                            TwoFactorEnabled = false,
                            UserName = "Admin@gmail.com"
                        });
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"));

                    b.Property<string>("User_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("userTypes");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.WorkShop", b =>
                {
                    b.Property<int>("WorkShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkShopId"));

                    b.Property<string>("WorkShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkshopLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkShopId");

                    b.ToTable("workShops");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.Car", b =>
                {
                    b.HasOne("FSMotorsShowroom.Models.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModeilId");

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("FSMotorsShowroom.Models.Investment", b =>
                {
                    b.HasOne("FSMotorsShowroom.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSMotorsShowroom.Models.Investor", "Investor")
                        .WithMany()
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FSMotorsShowroom.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FSMotorsShowroom.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FSMotorsShowroom.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FSMotorsShowroom.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
