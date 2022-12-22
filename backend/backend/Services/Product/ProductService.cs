using backend.Entity;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductFilter> GetListProductNew(int pageNumber, int pageSize, string? textSearch)
        {
            if (textSearch == null)
            {
                textSearch = string.Empty;
            }
            var product = await _productRepository.GetListProductNew(textSearch);

            ProductFilter productFilter = new ProductFilter
            {
                CurrentPage = pageNumber,
                CurrentPageRecord = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).Count(),
                TotalPage = (int)Math.Ceiling((double)product.Count() / pageSize) > 0 ? (int)Math.Ceiling((double)product.Count() / pageSize) : 1,
                TotalRecord = product.Count(),
                Data = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };

            return productFilter;
        }

        public async Task<ProductFilter> GetProductByCategory(int id, int pageNumber, int pageSize, string? textSearch)
        {
            if(textSearch == null)
            {
                textSearch = string.Empty;
            }    
            var product = await _productRepository.GetProductByCategory(id,textSearch);

            ProductFilter productFilter = new ProductFilter
            {
                CurrentPage = pageNumber,
                CurrentPageRecord = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).Count(),
                TotalPage = (int)Math.Ceiling((double)product.Count() / pageSize) > 0 ? (int)Math.Ceiling((double)product.Count() / pageSize) : 1,
                TotalRecord = product.Count(),
                Data = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };

            return productFilter;
        }

        public async Task<ProductView> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        /// <summary>
        /// Lấy sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public async Task<List<SanPham>> GetProductByIdCart(int id)
        {
            return await _productRepository.GetProductByIdCart(id);
        }

        public async Task<ProductFilter> GetProductByRange(int minRange, int maxRange, int pageNumber, int pageSize, string? textSearch)
        {
            if (textSearch == null)
            {
                textSearch = string.Empty;
            }
            var product = await _productRepository.GetProductByRange(minRange,maxRange,textSearch);

            ProductFilter productFilter = new ProductFilter
            {
                CurrentPage = pageNumber,
                CurrentPageRecord = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).Count(),
                TotalPage = (int)Math.Ceiling((double)product.Count() / pageSize) > 0 ? (int)Math.Ceiling((double)product.Count() / pageSize) : 1,
                TotalRecord = product.Count(),
                Data = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };

            return productFilter;
        }

        public async Task<ProductFilter> GetProducts(int pageNumber, int pageSize, string? textSearch)
        {
            if(textSearch == null)
            {
                textSearch = string.Empty;
            }    
            var product = await _productRepository.GetProducts(textSearch);

            ProductFilter productFilter = new ProductFilter
            {
                CurrentPage = pageNumber,
                CurrentPageRecord = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).Count(),
                TotalPage = (int)Math.Ceiling((double)product.Count() / pageSize) > 0 ? (int)Math.Ceiling((double)product.Count() / pageSize) : 1,
                TotalRecord = product.Count(),
                Data = product.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };

            return productFilter;
        }
    }
}
