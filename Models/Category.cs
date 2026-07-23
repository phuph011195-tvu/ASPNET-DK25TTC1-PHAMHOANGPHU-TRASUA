using System.ComponentModel.DataAnnotations;

namespace TrasuaMON.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        // Mối quan hệ: 1 danh mục có nhiều sản phẩm
        public ICollection<Product>? Products { get; set; }
    }
}