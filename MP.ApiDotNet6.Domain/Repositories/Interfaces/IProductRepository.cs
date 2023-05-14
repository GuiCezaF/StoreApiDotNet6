using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Products> GetByIdAsync(int id);
        Task<ICollection<Products>> GetProductsAsync();
        Task<Products> CreateAsync(Products products);
        Task EditAsync(Products products);
        Task DeleteAsync(Products products);

    }
}