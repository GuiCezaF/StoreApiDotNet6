using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories.Interfaces;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Products> CreateAsync(Products products)
        {
            _db.Add(products);
            await _db.SaveChangesAsync();
            return products;
        }

        public async Task DeleteAsync(Products products)
        {
            _db.Remove(products);
            await _db.SaveChangesAsync();

        }

        public async Task EditAsync(Products products)
        {
            _db.Update(products);
            await _db.SaveChangesAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Products>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}