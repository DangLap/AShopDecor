namespace backend.Models
{
    public class ProductFilter
    {
        public int TotalPage { get; set; }

        public int TotalRecord { get; set; }

        public int CurrentPage { get; set; }

        public int CurrentPageRecord { get; set; }

        public List<SanPham> Data { get; set; } = new List<SanPham> { };
    }
}
