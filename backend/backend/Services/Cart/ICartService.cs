using backend.Models;


namespace backend.Services
{
    public interface ICartService
    {
        
        Task <int> EditProductToCart(ChiTietHoaDon item);
        Task <int> DeleteProductToCart(int idUser,int idProduct);
        Task<int> AddProductToCart(int idCustomer, int idProduct, int count);
        Task<bool> Checkout(int userId);
    }
}
