namespace backend.Entity
{
    public class ProductView
    {
        public int? MaSp { get; set; }
        public string? TenSp { get; set; }
        public decimal GiaBan { get; set; }
        public string? MoTa { get; set; }
        public decimal SltonHienTai { get; set; }
        public decimal SltonToiThieu { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal? KhuyenMai { get; set; }
        public int MaLsp { get; set; }
        public List<string>? LstImage { get; set; } = new List<string>();
    }
}

