using System.ComponentModel.DataAnnotations;

namespace QuanLyTraSua.Models
{
    public class LoaiTraSua
    {
        [Key]
        public int MaLoai { get; set; }

        public string TenLoai { get; set; }
    }
}