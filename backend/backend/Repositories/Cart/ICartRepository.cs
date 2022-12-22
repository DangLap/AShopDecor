using backend.Entity;
using backend.Models;

namespace backend.Repositories
{
    public interface ICartRepository
    {
        
        Task<int> EditProductToCart(ChiTietHoaDon item);
        Task<int> AddProductToCart(int idCustomer, int idProduct, int count);

        List<CartProductView> GetProductsByUserId (int userId);
        Task<int> DeleteProductToCart(int idUser, int idProduct);
        Task<bool> Checkout(int userId);
    }
}
