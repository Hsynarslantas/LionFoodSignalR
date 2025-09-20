using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingalRWebUI.Dtos.BasketDto;
using SingalRWebUI.Dtos.ProductDto;

namespace SingalRWebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7217/api/Product/ProducListtWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id,int restauranttableId)
        {
            if (restauranttableId == 0)
            {
                return BadRequest("RestaurantTableId 0 geliyor.");
            }
            CreateBasketDto createBasketDto = new CreateBasketDto
            {
                ProductId = id,
                RestaurantTableId = restauranttableId   
            };
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7217/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7217/api/MenuTables/ChangeMenuTableStatusToTrue?id=" + restauranttableId);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return Json(createBasketDto);
        }
    }
}
