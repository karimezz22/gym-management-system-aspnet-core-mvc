using GymManagement.DAL.Models;

namespace GymManagement.DAL.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false, CancellationToken cancellationToken = default);
        Task<Plan?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> AddAsync(Plan plan, CancellationToken cancellationToken = default);
        Task<int> UpdateAsync(Plan plan, CancellationToken cancellationToken = default);
        Task<int> DeleteAsync(Plan plan, CancellationToken cancellationToken = default);
    }
}
