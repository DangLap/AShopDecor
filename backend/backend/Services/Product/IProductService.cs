using backend.Entity;
using backend.Models;

namespace backend.Services
{
    public interface IProductService
    {
        Task<ProductFilter> GetProductByCategory(int id, int pageNumber, int pageSize, string? textSearch);
        Task<ProductView> GetProductById(int id);
        Task <List<SanPham>> GetProductByIdCart(int id);
        Task<ProductFilter> GetListProductNew(int pageNumber, int pageSize, string? textSearch);
        Task <ProductFilter> GetProducts(int pageNumber, int pageSize, string? textSearch);
        Task<ProductFilter> GetProductByRange(int minRange, int maxRange, int pageNumber, int pageSize, string? textSearch);
    }
}
