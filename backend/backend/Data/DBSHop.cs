﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using backend.Models;

namespace backend.Data
{
    public partial class DBSHop : DbContext
    {
        public DBSHop()
        {
        }

        public DBSHop(DbContextOptions<DBSHop> options)
            : base(options)
        {
        }

        public virtual DbSet<Anh> Anh { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<PhieuNhapKho> PhieuNhapKho { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anh>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Anh__MaSP__37A5467C");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaHd })
                    .HasName("PK__ChiTietH__35575272E3D9DF58");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ChiTietHoaDon)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHoa__MaHD__3F466844");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietHoaDon)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietHoa__MaSP__3E52440B");
            });

            modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.MaPnk })
                    .HasName("PK__ChiTietP__448B3665B2599193");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.MaPnk).HasColumnName("MaPNK");

                entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.MaPnkNavigation)
                    .WithMany(p => p.ChiTietPhieuNhap)
                    .HasForeignKey(d => d.MaPnk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPh__MaPNK__4316F928");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietPhieuNhap)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietPhi__MaSP__4222D4EF");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E09B55A78F");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.TongGia).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.IdKhachHang).HasColumnType("int");

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasMany(d => d.IdnguoiDung)
                    .WithMany(p => p.MaHd)
                    .UsingEntity<Dictionary<string, object>>(
                        "QuanLy",
                        l => l.HasOne<NguoiDung>().WithMany().HasForeignKey("IdnguoiDung").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__QuanLy__IDNguoiD__300424B4"),
                        r => r.HasOne<HoaDon>().WithMany().HasForeignKey("MaHd").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__QuanLy__MaHD__2F10007B"),
                        j =>
                        {
                            j.HasKey("MaHd", "IdnguoiDung").HasName("PK__QuanLy__A8E8DB509817FC34");

                            

                            j.IndexerProperty<int>("MaHd").HasColumnName("MaHD");

                            j.IndexerProperty<int>("IdnguoiDung").HasColumnName("IDNguoiDung");
                        });
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLsp)
                    .HasName("PK__LoaiSanP__3B983FFED0E2CA35");

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.IdnguoiDung)
                    .HasName("PK__NguoiDun__FCD7DB09E65A4439");

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Loai)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TenNV");

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NhaCungC__3A185DEBF971E213");

                entity.Property(e => e.MaNcc).HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sđt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SĐT");

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<PhieuNhapKho>(entity =>
            {
                entity.HasKey(e => e.MaPnk)
                    .HasName("PK__PhieuNha__3AE3E79775080B42");

                entity.Property(e => e.MaPnk).HasColumnName("MaPNK");

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.PhieuNhapKho)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuNhap__IDNgu__35BCFE0A");

                entity.HasMany(d => d.MaNcc)
                    .WithMany(p => p.MaPnk)
                    .UsingEntity<Dictionary<string, object>>(
                        "Thuoc",
                        l => l.HasOne<NhaCungCap>().WithMany().HasForeignKey("MaNcc").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Thuoc__MaNCC__3B75D760"),
                        r => r.HasOne<PhieuNhapKho>().WithMany().HasForeignKey("MaPnk").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Thuoc__MaPNK__3A81B327"),
                        j =>
                        {
                            j.HasKey("MaPnk", "MaNcc").HasName("PK__Thuoc__994262496AA9FABA");

                            j.ToTable("Thuoc");

                            j.IndexerProperty<int>("MaPnk").HasColumnName("MaPNK");

                            j.IndexerProperty<int>("MaNcc").HasColumnName("MaNCC");
                        });
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CCA4A83B0");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.KhuyenMai).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaLsp).HasColumnName("MaLSP");

                entity.Property(e => e.MoTa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SltonHienTai)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("SLTonHienTai");

                entity.Property(e => e.SltonToiThieu)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("SLTonToiThieu");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TenSP");
                entity.Property(e => e.AnhDaiDien).HasColumnName("AnhDaiDien");

                entity.HasOne(d => d.MaLspNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.MaLsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPham__MaLSP__32E0915F");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdnguoiDung).HasColumnName("IDNguoiDung");

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnguoiDungNavigation)
                    .WithMany(p => p.TaiKhoan)
                    .HasForeignKey(d => d.IdnguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaiKhoan__IDNguo__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}