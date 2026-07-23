using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTraSua.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        public string TenSP { get; set; }

        public decimal Gia { get; set; }

        public string? HinhAnh { get; set; }

        public string? MoTa { get; set; }

        public int MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public LoaiTraSua? LoaiTraSua { get; set; }
    }
}