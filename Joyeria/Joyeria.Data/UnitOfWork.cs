using Joyeria.Core;
using Joyeria.Core.Repositories;
using Joyeria.Data.Repositories;

namespace Joyeria.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JoyeriaDbContext _dbContext;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IUserRepository _userRepository;
        private IComplaintRepository _complaintRepository;
        private IOrderRepository _orderRepository;
        public UnitOfWork(JoyeriaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(this._dbContext);
        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(this._dbContext);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(this._dbContext);
        public IComplaintRepository Complaint => _complaintRepository = _complaintRepository ?? new ComplaintRepository(this._dbContext);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(this._dbContext);

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
