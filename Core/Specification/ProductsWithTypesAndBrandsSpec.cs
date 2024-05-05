using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpec : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpec()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductsWithTypesAndBrandsSpec(int id)
        {
            Predicate = x => x.Id == id;
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
