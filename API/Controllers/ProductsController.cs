using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<ProductType> _typeRepo;
        private readonly IRepository<ProductBrand> _brandRepo;
        private readonly IRepository<Product> _productRepo;

        public ProductsController(IRepository<ProductType> typeRepo, IRepository<ProductBrand> brandRepo, IRepository<Product> productRepo)
        {
            _typeRepo = typeRepo;
            _brandRepo = brandRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepo.FindAsyncWithSpec(new ProductsWithTypesAndBrandsSpec());

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProduct(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _brandRepo.GetAllAsync();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            var productTypes = await _typeRepo.GetAllAsync();
            return Ok(productTypes);
        }
    }
}
