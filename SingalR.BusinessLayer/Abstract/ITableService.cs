using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SingalR.BusinessLayer.Abstract
{
    public interface ITableService : IGenericService<RestaurantTable>
    {
        public int TRestaurantTableCount();
        void TChangeRestaurantTableStatusToFalse(int id);
        void TChangeRestaurantTableStatusToTrue(int id);
    }
}
