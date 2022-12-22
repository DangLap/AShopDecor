using backend.Data;
using backend.Entity;
using backend.Models;

namespace backend.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DBSHop _context;
       
        public CartRepository(DBSHop context)
        {
            _context = context;
            
        }

        public async Task<int> AddProductToCart(ChiTietHoaDon item, int idCustomer)
        {
            var cartMaster = _context.HoaDon.Where(n => n.IdKhachHang == idCustomer && n.TrangThai == "Gio Hang").FirstOrDefault();
            
            if (cartMaster == null)
            {
                HoaDon hd = new HoaDon
                {
                    IdKhachHang = idCustomer,
                    TongGia = 0,
                    TrangThai = "Gio Hang",
                    NgayLap = DateTime.Now
                };


                _context.HoaDon.Add(hd);
                _context.SaveChanges();

            }
            _context.ChiTietHoaDon.Add(item);
            _context.SaveChanges();
            return idCustomer;
           
            
        }

        public async Task<int> AddProductToCart(int idCustomer, int idProduct, int count)
        {
            var cartMaster =  _context.HoaDon.Where(n => n.IdKhachHang == idCustomer && n.TrangThai == "Gio Hang").FirstOrDefault();
            var product = _context.SanPham.Where(n => n.MaSp == idProduct).FirstOrDefault();
            if (cartMaster == null && product != null)
            {
                HoaDon hd = new HoaDon
                {
                    IdKhachHang = idCustomer,
                    TongGia = product.GiaBan * count,
                    TrangThai = "Gio Hang",
                    NgayLap = DateTime.Now
                };

                cartMaster = hd;

                _context.HoaDon.Add(hd);
                _context.SaveChanges();

            }
            var productDetail = new ChiTietHoaDon
            {
                SoLuong = count,
                MaHd = cartMaster.MaHd,
                MaSp = idProduct
            };
            var productDetailExists = _context.ChiTietHoaDon.Where(n => n.MaHd == cartMaster.MaHd && n.MaSp == idProduct).FirstOrDefault();
            // Nếu sản phẩm đã có r thì chỉ tăng số lượng 
            if (productDetailExists != null)
            {
                productDetailExists.SoLuong += count;
            }
            else
            {
                _context.ChiTietHoaDon.Add(productDetail);
            }    
            _context.SaveChanges();
            return count;
        }

        public async Task<bool> Checkout(int userId)
        {
            var bill = _context.HoaDon.Where(n => n.IdKhachHang == userId && n.TrangThai == "Gio Hang").FirstOrDefault();
            if (bill != null)
            {
                bill.TrangThai = "Đã thanh toán";
                var chiTietHd = _context.ChiTietHoaDon.Where(n => n.MaHd == bill.MaHd).ToList();

                foreach(var item in chiTietHd)
                {
                    var product = _context.SanPham.Where(n => n.MaSp == item.MaSp).FirstOrDefault();
                    if(product != null)
                    {
                        product.SltonHienTai -= item.SoLuong;
                    }
                }

                _context.SaveChanges();
                return true;
            }
            return false;
            
        }

        public async Task<ChiTietHoaDon> DeleteProductToCart(ChiTietHoaDon item)
        {
            var entity = _context.ChiTietHoaDon.Where(n => n.MaHd == item.MaHd && n.MaSp == item.MaSp).FirstOrDefault();
            if(entity != null)
            {
                _context.ChiTietHoaDon.Remove(entity);
                _context.SaveChanges();
            }
            return item;
        }

        public async Task<int> DeleteProductToCart(int idUser, int idProduct)
        {
            var entity = _context.HoaDon.Where(n => n.IdKhachHang == idUser && n.TrangThai == "Gio Hang").FirstOrDefault();
            if(entity != null)
            {
                var productCart = _context.ChiTietHoaDon.Where(n => n.MaSp == idProduct && n.MaHd == entity.MaHd).FirstOrDefault();
                if(productCart != null)
                {
                    _context.ChiTietHoaDon.Remove(productCart);
                    _context.SaveChanges();
                }
                return 1;
            }
            return 0;
        }

        public async Task<int> EditProductToCart(ChiTietHoaDon item)
        {
            var entity = _context.ChiTietHoaDon.Where(n => n.MaHd == item.MaHd && n.MaSp == item.MaSp).FirstOrDefault();

            if (entity != null)
            {
                entity.SoLuong = item.SoLuong;
                _context.SaveChanges();
                return 1;
            }
            else return 0;
        }

        public  List<CartProductView> GetProductsByUserId(int userId)
        {
            var cart = _context.HoaDon.Where(n => n.IdKhachHang == userId && n.TrangThai == "Gio Hang").FirstOrDefault();
            if(cart != null)
            {
                var cartProducts = _context.ChiTietHoaDon.Where(n => n.MaHd == cart.MaHd).ToList();

                List<CartProductView> lstProductView = new List<CartProductView>();
                foreach (var item in cartProducts)
                {
                    var product = _context.SanPham.Where(n => n.MaSp == item.MaSp).FirstOrDefault();
                    var cartProductView = new CartProductView
                    {
                        MaSp = item.MaSp,
                        TenSp = product.TenSp,
                        GiaBan = product.GiaBan,
                        MaLsp = product.MaLsp,
                        AnhDaiDien = product.AnhDaiDien,
                        SoLuong = item.SoLuong

                    };
                    lstProductView.Add(cartProductView);
                }
                return lstProductView;

            }
            return new List<CartProductView>();
        }
    }
}
