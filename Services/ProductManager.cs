using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id, bool trackChanges)
        {
            var entity = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (entity is null)
                throw new Exception("The product could not found.");

            _unitOfWork.Product.Remove(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) => 
            await _unitOfWork.Product.GetAll(trackChanges).ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id, bool trackChanges)
        {
            var entity = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (entity is null)
                throw new Exception("The product could not found");

            return entity;
        }

        public async Task UpdateProductAsync(int id, Product product, bool trackChanges)
        {
            var entity = await _unitOfWork.Product.GetByConditionAsync(p => p.Id == id, trackChanges);
            if (entity is null)
                throw new Exception("The product could not found");

            entity.ProductName = product.ProductName;
            entity.Stock = product.Stock;
            entity.Price = product.Price;
            entity.CategoryId = product.CategoryId;

            _unitOfWork.Product.Update(entity);
        }
    }
}
