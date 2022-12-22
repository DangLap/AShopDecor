using backend.Entity;
using backend.Models;

namespace backend.Repositories
{
    public interface IAccountRepository
    {
        TaiKhoan Login(string username, string password);
        Task<NguoiDung> getUser(int idnguoiDung);
    }
}
