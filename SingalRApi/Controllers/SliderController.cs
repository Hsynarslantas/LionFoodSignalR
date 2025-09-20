using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;
using SingalR.BusinessLayer.Abstract;
using SingalR.DtoLayer.FeatureDto;

namespace SingalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            return Ok(_sliderService.TGetListAll());
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Slider>(createFeatureDto);
            _sliderService.TAdd(value);
            return Ok("Öne Çıkan Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(_mapper.Map<GetFeatureByIdDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Slider>(updateFeatureDto);
            _sliderService.TUpdate(value);
            return Ok("Öne Çıkan Alan Bilgisi Güncellendi");
        }
    }
}
