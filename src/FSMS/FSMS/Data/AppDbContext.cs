using FSMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSMS.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Dispenser> Dispensers { get; set; }
        public DbSet<Nozzle> Nozzles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<UnitPrice> UnitPrices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
