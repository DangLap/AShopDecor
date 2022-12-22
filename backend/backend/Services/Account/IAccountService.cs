using backend.Entity;

namespace backend.Services
{
    public interface IAccountService
    {
        Task<AccountView> Login(string username, string password);
    }
}
