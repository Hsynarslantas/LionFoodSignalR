using AutoMapper;
using SignalR.EntityLayer.Entities;
using SingalR.DtoLayer.TableDto;

namespace SingalRApi.Mapping
{
    public class RestaurantTableMapping:Profile
    {
        public RestaurantTableMapping()
        {
            CreateMap<RestaurantTable, ResultTableDto>().ReverseMap();
            CreateMap<RestaurantTable, CreateTableDto>().ReverseMap();
            CreateMap<RestaurantTable, UpdateTableDto>().ReverseMap();
            CreateMap<RestaurantTable, GetTableDto>().ReverseMap();
           
        }
    }
}
