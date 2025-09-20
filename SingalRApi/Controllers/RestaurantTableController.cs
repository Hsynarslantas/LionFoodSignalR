using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.TableDto;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public RestaurantTableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }
        [HttpGet("RestaurantTableCount")]
        public IActionResult RestaurantTableCount()
        {
            return Ok(_tableService.TRestaurantTableCount());
        }
        [HttpGet]
        public IActionResult TableList()
        {
            var values = _tableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTableDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateTable(CreateTableDto createTableDto)
        {
            var value = _mapper.Map<RestaurantTable>(createTableDto);
            _tableService.TAdd(value);
            return Ok("Restoran Masa Bilgisi Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var value = _tableService.TGetById(id);
            _tableService.TDelete(value);
            return Ok("Restoran Masa Bilgisi Silindi");
        }
        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDto updateTableDto)
        {
            var value = _mapper.Map<RestaurantTable>(updateTableDto);
            _tableService.TUpdate(value);
            return Ok("Restoran Masa Bilgisi Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTable(int id)
        {
            var value = _tableService.TGetById(id);
            return Ok(_mapper.Map<GetTableDto>(value));
        }
        [HttpGet("ChangeRestaurantTableStatusToTrue")]
        public IActionResult ChangeRestaurantTableStatusToTrue(int id)
        {
            _tableService.TChangeRestaurantTableStatusToTrue(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("ChangeRestaurantTableStatusToFalse")]
        public IActionResult ChangeRestaurantTableStatusToFalse(int id)
        {
             _tableService.TChangeRestaurantTableStatusToFalse(id);
            return Ok("İşlem Başarılı");
        }
    }
}
