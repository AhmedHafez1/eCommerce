using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Classes;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<ProductType> _typeRepo;
        private readonly IRepository<ProductBrand> _brandRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<ProductType> typeRepo, IRepository<ProductBrand> brandRepo, IRepository<Product> productRepo, IMapper mapper)
        {
            _typeRepo = typeRepo;
            _brandRepo = brandRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] ProductQueryParams queryParams)
        {
            var products = await _productRepo.ListWithSpecAsync(new ProductsWithTypesAndBrandsSpec(queryParams));
            var totalCount = await _productRepo.CountWithSpecAsync(new ProductsCountSpec(queryParams));

            var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(queryParams.PageIndex, totalCount, queryParams.PageSize, productsDtos));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productRepo.FindWithSpecAsync(new ProductsWithTypesAndBrandsSpec(id));
            return _mapper.Map<ProductDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _brandRepo.ListAllAsync();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            var productTypes = await _typeRepo.ListAllAsync();
            return Ok(productTypes);
        }
    }
}
