using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.BookingDto;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;
        public BookingController(IBookingService BookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _BookingService = BookingService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _BookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var validationresult=_validator.Validate(createBookingDto);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors);
            }
            var value = _mapper.Map<Booking>(createBookingDto);
            _BookingService.TAdd(value);
            return Ok("Rezervasyon Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _BookingService.TGetById(id);
            _BookingService.TDelete(value);
            return Ok("Rezervasyon Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _BookingService.TUpdate(value);
            return Ok("Rezervasyon Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _BookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _BookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _BookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
    }
}