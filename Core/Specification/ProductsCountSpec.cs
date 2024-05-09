using Core.Classes;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductsCountSpec : Specification<Product>
    {
        public ProductsCountSpec(ProductQueryParams queryParams)
        {
            Predicate = p => (!string.IsNullOrEmpty(queryParams.Search) || p.Name.ToLower().Contains(queryParams.Search ?? "")) &&
                           (!queryParams.BrandId.HasValue || queryParams.BrandId == p.ProductBrandId) &&
                           (!queryParams.TypeId.HasValue || queryParams.TypeId == p.ProductTypeId);
        }
    }
}
