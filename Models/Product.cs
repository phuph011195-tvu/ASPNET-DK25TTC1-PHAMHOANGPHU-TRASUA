using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrasuaMON.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên món không được để trống")]
        [Display(Name = "Tên món trà sữa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá tiền không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0")]
        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Mô tả món")]
        public string? Description { get; set; }

        // Khóa ngoại liên kết tới bảng Category
        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}