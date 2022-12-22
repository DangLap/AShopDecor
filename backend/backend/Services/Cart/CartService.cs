using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> AddProductToCart(int idCustomer, int idProduct, int count)
        {
            return await _cartRepository.AddProductToCart(idCustomer, idProduct, count);
        }

        public Task<bool> Checkout(int userId)
        {
            return _cartRepository.Checkout(userId);
        }

        //public async Task<ChiTietHoaDon> DeleteProductToCart(ChiTietHoaDon item)
        //{
        //    return await _cartRepository.DeleteProductToCart(item);
        //}

        public async Task<int> DeleteProductToCart(int idUser, int idProduct)
        {
            return await _cartRepository.DeleteProductToCart(idUser,idProduct);
        }

        public async Task<int> EditProductToCart(ChiTietHoaDon item)
        {
            return await _cartRepository.EditProductToCart(item);
        }
    }
}
