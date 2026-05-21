using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagementSystem.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable(p =>
            {
                p.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 365");
            });

            builder.Property(p => p.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50); 

            builder.Property(p => p.Description)
                   .HasMaxLength(200);

            builder.Property(p => p.Price)
                   .HasPrecision(10, 2);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
