using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DtoLayer.BasketDto;
using SingalRApi.Models;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _BasketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _BasketService = basketService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBasketByRestaurantTableId(int id)
        {
            var values = _BasketService.TGetBasketByTableNumber(id);
            return Ok(values);
           
        }
        [HttpGet("BasketListByRestaurantTableWithProductName")]
        public IActionResult BasketListByRestaurantTableWithProductName(int id)
        {
            using var context = new SingalRContext();
            var values=context.Baskets.Include(x=>x.Product).Where(y=>y.RestaurantTableId==id).Select(z=> new ResultBasketListWithProducts
            {
                BasketId = z.BasketId,
                ProductCount = z.ProductCount,
                RestaurantTableId=z.RestaurantTableId,
                ProductPrice = z.ProductPrice,
                ProductId=z.ProductId,
                TotalPrice=z.TotalPrice,
                ProductName=z.Product.ProductName

            }).ToList();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateBasket(int id)
        {
          using var context=new SingalRContext();
            CreateBasketDto createBasketDto = new CreateBasketDto();
            _BasketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                ProductCount = 1,
                RestaurantTableId = createBasketDto.RestaurantTableId,
                ProductPrice = context.Products.Where
                (x => x.ProductId == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice=createBasketDto.TotalPrice,
            });
            return Ok();
            
        }
        [HttpDelete]
        public IActionResult DeleteBasket(int id)
        {
            var value = _BasketService.TGetById(id);
            _BasketService.TDelete(value);
            return Ok("Sepetteki Seçilen  Ürün Silindi");
        }
    }
}
