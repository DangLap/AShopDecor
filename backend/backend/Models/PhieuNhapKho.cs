﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class PhieuNhapKho
    {
        public PhieuNhapKho()
        {
            ChiTietPhieuNhap = new HashSet<ChiTietPhieuNhap>();
            MaNcc = new HashSet<NhaCungCap>();
        }

        public int MaPnk { get; set; }
        public DateTime NgayNhap { get; set; }
        public int IdnguoiDung { get; set; }

        public virtual NguoiDung IdnguoiDungNavigation { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }

        public virtual ICollection<NhaCungCap> MaNcc { get; set; }
    }
}