using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpec : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpec(string? sort = null, int? brandId = null, int? typeId = null)
        {
            Predicate = p => (!brandId.HasValue || brandId == p.ProductBrandId) &&
                             (!typeId.HasValue || typeId == p.ProductTypeId);
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            switch (sort)
            {
                case "priceAsc":
                    SetOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    SetOrderByDesc(p => p.Price);
                    break;
                case "nameAsc":
                    SetOrderBy(p => p.Name);
                    break;
                case "nameDesc":
                    SetOrderByDesc(p => p.Name);
                    break;
            }

        }

        public ProductsWithTypesAndBrandsSpec(int id)
        {
            Predicate = x => x.Id == id;
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
