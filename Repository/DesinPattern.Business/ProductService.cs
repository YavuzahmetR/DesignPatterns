using DesignPattern.DataAccess.Abstract;
using DesignPattern.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesinPattern.Business
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository _repository, IUnitOfWork _unitOfWork)
        {
            this._repository = _repository;
            this._unitOfWork = _unitOfWork;
        }
        public async Task AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _repository.Delete(product);
           await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _repository.Where(predicate).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if(value == null)
            {
                throw new Exception("Entity not found");
            }
            return value;
        }

        public async Task<List<Product>> GetCategoriesOfProducts()
        {
            return await _repository.GetCategoriesOfProducts().ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
