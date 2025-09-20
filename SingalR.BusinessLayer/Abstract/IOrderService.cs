using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SingalR.BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        public int TTotalOrderCount();
        public int TActiveOrderCount();
        public decimal TLastOrderPrice();
    }
}
