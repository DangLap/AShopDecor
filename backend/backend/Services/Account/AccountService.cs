using backend.Entity;
using backend.Models;
using backend.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class AccountService : IAccountService
    {

        private readonly IConfiguration _config;
        private readonly IAccountRepository _accountRepository;
        private readonly ICartRepository _cartRepository;
        public AccountService(IAccountRepository accountRepository, IConfiguration config,ICartRepository cartRepository)
        {
            _config = config;
            _accountRepository = accountRepository;
            _cartRepository = cartRepository;
        }
        public async Task<AccountView> Login(string username, string password)
        {
            var account = _accountRepository.Login(username, password);
            if (account == null)
            {
                return null;
            }
            else
            {
                var user = await _accountRepository.getUser(account.IdnguoiDung);
                var cartProduct = _cartRepository.GetProductsByUserId(account.IdnguoiDung).ToList();
                var tokenStr = GenerateJWT(account);
                AccountView accoutView = new AccountView
                {
                    IdAccount = account.Id,
                    IdUser = user.IdnguoiDung,
                    UserName = user.TenNv,
                    Type = user.Loai,
                    Email = user.Email,
                    PhoneNumber = user.Sdt,
                    Address = user.DiaChi,
                    Gender = user.GioiTinh,
                    CartProducts = cartProduct,
                    token = tokenStr
                    
                };
                return accoutView;
            }

        }

        private string GenerateJWT(TaiKhoan account)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
            (_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),

                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddDays(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

    }

    
}
