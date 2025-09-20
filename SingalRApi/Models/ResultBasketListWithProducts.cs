using SignalR.EntityLayer.Entities;

namespace SingalRApi.Models
{
    public class ResultBasketListWithProducts
    {
        public int BasketId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int RestaurantTableId { get; set; }
        public string ProductName { get; set; }

    }
}
