using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SingalR.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        public List<Basket> TGetBasketByTableNumber(int id);
    }
}
