using DesignPattern.DataAccess.Abstract;
using DesignPattern.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesinPattern.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Category entity)
        {
            await categoryRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            categoryRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task<List<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
        {
            return await categoryRepository.Where(predicate).ToListAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await categoryRepository.GetAll().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var value = await categoryRepository.GetByIdAsync(id);
            if (value == null)
            {
                throw new Exception("Entity not found");
            }
            return value;
        }
        public async Task UpdateAsync(Category entity)
        {
            categoryRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
