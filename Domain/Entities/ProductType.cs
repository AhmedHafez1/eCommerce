namespace Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }

        public ProductType(string name)
        {
            Name = name;
        }
    }
}