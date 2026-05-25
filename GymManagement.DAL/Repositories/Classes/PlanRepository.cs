using GymManagement.DAL.DbContexts;
using GymManagement.DAL.Models;
using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext dbContext;

        public PlanRepository(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddAsync(Plan plan, CancellationToken cancellationToken = default)
        {
            dbContext.Plans.Add(plan);

            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken cancellationToken = default)
        {
            dbContext.Plans.Remove(plan);

            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken cancellationToken = default)
        {
            IQueryable<Plan> query = tracking ? dbContext.Plans : dbContext.Plans.AsNoTracking();

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Plans.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<int> UpdateAsync(Plan plan, CancellationToken cancellationToken = default)
        {
            dbContext.Plans.Update(plan);

            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
