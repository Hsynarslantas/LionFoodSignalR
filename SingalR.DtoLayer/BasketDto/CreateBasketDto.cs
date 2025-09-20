using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalR.DtoLayer.BasketDto
{
    public class CreateBasketDto
    {
       
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int RestaurantTableId { get; set; }
       
    }
}
