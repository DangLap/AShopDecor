using backend.Entity;
using backend.Models;

namespace backend.Repositories
{
    public interface IProductRepository
    {
        Task <List<SanPham>> GetProductByCategory(int id,string textSearch);
        Task<ProductView> GetProductById(int id);
        Task<List<SanPham>> GetProductByIdCart(int id);
        Task<List<SanPham>> GetListProductNew(string textSearch);
        Task<List<SanPham>> GetProducts(string textSearch);
        Task<List<SanPham>> GetProductByRange(int minRange, int maxRange, string textSearch);
    }
}
