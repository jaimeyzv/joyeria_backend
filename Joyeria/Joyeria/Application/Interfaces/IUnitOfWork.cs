using Joyeria.Application.Interfaces.Repositories;

namespace Joyeria.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IUserRepository Users { get; }
        IComplaintRepository Complaint { get; }
        IOrderRepository Orders { get; }

        Task<int> SaveChangesAsync();
    }
}
