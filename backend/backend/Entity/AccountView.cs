using backend.Models;

namespace backend.Entity
{
    public class AccountView
    {
        public int IdAccount { get; set; }
        public int IdUser { get; set; }
        public string? UserName { get; set; }

        /// <summary>
        /// Loại Nhân viên,người dùng,....
        /// </summary>
        public string? Type { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public string? Gender { get; set; }

        public string? token { get; set; }

        public List<CartProductView> CartProducts { get; set; } = new List<CartProductView>();
    }
}
