using FS_Motors.Models;
using FSMotorsShowroom.Models;
using Microsoft.EntityFrameworkCore;


namespace FSMotorsShowroom.Models
{
    public class FSDbContext : DbContext
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
        public DbSet<Showroom> Showroom { get; set; } = default!;

        //public DbSet<FSMotorsShowroom.Models.Category> Category { get; set; } = default!;
    }

}
