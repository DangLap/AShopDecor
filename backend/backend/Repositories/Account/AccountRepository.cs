using backend.Data;
using backend.Entity;
using backend.Models;

namespace backend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DBSHop _context;

        public AccountRepository(DBSHop context)
        {
            _context = context;
        }

        public async Task<NguoiDung> getUser(int idnguoiDung)
        {
            return await _context.NguoiDung.FindAsync(idnguoiDung);
        }

        public TaiKhoan Login(string username, string password)
        {
            return _context.TaiKhoan.Where(n => n.Username == username && n.PassWord == password).FirstOrDefault();
        }
    }
}
