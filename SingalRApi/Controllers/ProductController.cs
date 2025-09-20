using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DtoLayer.ProductDto;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _ProductService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }
        [HttpGet("GetLast9Products")]
        public IActionResult GetTake9Products()
        {
            var values = _ProductService.TGetLast9Products();
            return Ok(values);
        }
        [HttpGet("ProductPriceByHamburger")]
        public IActionResult ProductPriceByHamburger()
        {
            return Ok(_ProductService.TProductPriceByHamburger());
        }
        [HttpGet("ProductPriceBySmashHamburger")]
        public IActionResult ProductPriceBySmashHamburger()
        {
            return Ok(_ProductService.TProductPriceBySmashBurger());
        }
        [HttpGet("TotalPriceByDrinkCategory")]
        public IActionResult TotalPriceByDrinkCategory()
        {
            return Ok(_ProductService.TTotalPriceByDrinkCategory());
        }
        [HttpGet("TotalPriceByPizzaCategory")]
        public IActionResult TotalPriceByPizzaCategory()
        {
            return Ok(_ProductService.TTotalPriceByPizzaCategory());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_ProductService.TProductPriceAvg());
        }
        [HttpGet("ProductPriceByMaxPrice")]
        public IActionResult ProductPriceByMaxPrice()
        {
            return Ok(_ProductService.TProductNameByMaxPrice());
        }
        [HttpGet("ProductPriceByMinPrice")]
        public IActionResult ProductPriceByMinPrice()
        {
            return Ok(_ProductService.TProductNameByMinPrice());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_ProductService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_ProductService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_ProductService.TProductCount());
        }
        [HttpGet("ProducListtWithCategory")]
        public IActionResult ProducListtWithCategory()
        {
            var context = new SingalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductsWithCategoriesDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _ProductService.TAdd(value);
            return Ok("Ürün Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            _ProductService.TDelete(value);
            return Ok("Ürün Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _ProductService.TUpdate(value);
            return Ok("Ürün Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
    }
}