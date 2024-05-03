
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public ProductType ProductType { get; set; } = null!;
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; } = null!;
        public int ProductBrandId { get; set; }

        public Product(string name, int productTypeId, int productBrandId)
        {
            Name = name;
            ProductTypeId = productTypeId;
            ProductBrandId = productBrandId;
        }
    }
}
