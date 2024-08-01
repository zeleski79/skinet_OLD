using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;      
        private readonly IGenericRepository<ProductType> _productTypesRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductBrand> productBrandsRepo,
                                  IGenericRepository<ProductType> productTypesRepo,
                                  IMapper mapper) {
            _mapper = mapper;
            _productTypesRepo = productTypesRepo;            
            _productsRepo = productsRepo;
            _productBrandsRepo = productBrandsRepo;
        }

        [HttpGet] 
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> getProducts() {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsyncWithSpec(spec);
            //return products.Select(product => _mapper.Map<Product, ProductToReturnDto>(product)).ToList();
            //OR
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<ProductToReturnDto>> getProduct(int id) {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("types")] 
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getProductTypes() {
            var productTypes = await _productTypesRepo.ListAllAsync();
            return Ok(productTypes);
        }

        [HttpGet("brands")] 
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getProductBrands() {
            var productBrands = await _productBrandsRepo.ListAllAsync();
            return Ok(productBrands);
        }
    }
}