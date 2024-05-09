using Core.Classes;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpec : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpec(ProductQueryParams queryParams)
        {
            Predicate = p => (string.IsNullOrEmpty(queryParams.Search) || p.Name.ToLower().Contains(queryParams.Search ?? "")) &&
                             (!queryParams.BrandId.HasValue || queryParams.BrandId == p.ProductBrandId) &&
                             (!queryParams.TypeId.HasValue || queryParams.TypeId == p.ProductTypeId);
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            switch (queryParams.Sort)
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

            ApplyPagination(queryParams.PageSize, queryParams.PageSize * (queryParams.PageIndex - 1));
        }

        public ProductsWithTypesAndBrandsSpec(int id)
        {
            Predicate = x => x.Id == id;
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
