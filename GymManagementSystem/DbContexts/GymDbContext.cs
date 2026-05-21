using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymManagementSystem.DbContexts
{
    public class GymDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = GymManagementSystemDb; Trusted_Connection = true; TrustServerCertificate = true");
        }

        public DbSet<Plan> Plans => Set<Plan>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
