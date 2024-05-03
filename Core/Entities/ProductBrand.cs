namespace Core.Entities
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }

        public ProductBrand(string name)
        {
            Name = name;
        }
    }
}