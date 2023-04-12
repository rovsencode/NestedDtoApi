using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P326FirstWebAPI.DAL;
using P326FirstWebAPI.Dtos.ProductDtos;
using P326FirstWebAPI.Models;

namespace P326FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll(int page,string search)
        {
            var query = _appDbContext.Products.Include(p=>p.Category).ThenInclude(c=>c.Products).Where(p=>p.IsDelete);

            ProductListDto productListDto = new();
            productListDto.TotalCount = query.Count();
            productListDto.CurrentPage = page; 
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p => p.Name.Contains(search));
            }
            productListDto.productListItemDtos = query.Take(10).Select(p => new ProductListItemDto
            {
                Name = p.Name,
                CostPrice = p.CostPrice,
                SalePrice=p.SalePrice,
                CreatedTime=p.CreatedDate,
                UpdateTime=p.UpdateDate,
                Category = new() {
                    Id=p.CategoryId,
                    Name=p.Category.Name,
                    ProductCount=p.Category.Products.Count(),
                }


            }).ToList();           
            return StatusCode(StatusCodes.Status200OK,productListDto);
        }
        [Route("getOne")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Product product = _appDbContext.Products.Where(p=>p.IsDelete)
                .Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);

            ProductReturnDto productReturnDto= _mapper.Map<ProductReturnDto>(product);
            return Ok(productReturnDto);
           
        }


        private ProductReturnDto MapToProductReturnDto(Product product)
        {
            ProductReturnDto productReturnDto = new()
            {
                Name = product.Name,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                IsActive = product.IsActive,
                Category = new()
                {
                    Name = product.Category.Name,
                    Id = product.Category.Id,
                }

            };
            return productReturnDto;
        }
        [HttpPost]
        public IActionResult AddProduct(ProductCreatedDto productCreatedDto)
        {
            var category=_appDbContext.Categories.Where(c=>c.IsDelete).FirstOrDefault(c=>c.Id==productCreatedDto.CategoryId);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound);
            Product newProduct = new() {
                Name = productCreatedDto.Name,
                CostPrice = productCreatedDto.CostPrice,
                SalePrice = productCreatedDto.SalePrice,
                IsActive = productCreatedDto.IsActive,
                IsDelete=productCreatedDto.IsDelete,
                CategoryId=category.Id
            };

            _appDbContext.Products.Add(newProduct);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, newProduct);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product= _appDbContext.Products.FirstOrDefault(p=>p.Id==id);
            if (product == null) return NotFound();
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id,ProductUpdateDto productUpdateDto)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.Name = productUpdateDto.Name;
            existProduct.SalePrice = productUpdateDto.SalePrice;
            existProduct.CostPrice = productUpdateDto.CostPrice;
            existProduct.IsActive = productUpdateDto.IsActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch]
        public IActionResult ChangeStatus(int id,bool isActive)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.IsActive = isActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}

