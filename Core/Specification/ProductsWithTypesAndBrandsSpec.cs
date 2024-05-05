using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpec : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpec()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
