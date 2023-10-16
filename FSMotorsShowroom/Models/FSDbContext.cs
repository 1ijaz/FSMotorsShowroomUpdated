﻿using FS_Motors.Models;
using FSMotorsShowroom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FSMotorsShowroom.Models
{
    public class FSDbContext : IdentityDbContext<IdentityUser>
    {
        public FSDbContext(DbContextOptions<FSDbContext> options) : base(options)
        {
        }

        public DbSet<Car> cars { get; set; }
        public DbSet<CarModel> carModels { get; set; }
        public DbSet<Investor> investors { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserType> userTypes { get; set; }
        public DbSet<WorkShop> workShops { get; set; }
        public DbSet<Investment> investments { get; set; }
        public DbSet<Showroom> Showroom { get; set; } = default!;

        //public DbSet<FSMotorsShowroom.Models.Category> Category { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = "1",
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@11"),
                    FirstName="",
                    LastName="",
                }
            );
        }

    }

}
