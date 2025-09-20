using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.EntityLayer.Entities;

namespace SingalR.DataAccessLayer.Abstract
{
    public interface ITableDal:IGenericDal<RestaurantTable>
    {
        int RestaurantTableCount();
        void ChangeRestaurantTableStatusToFalse(int id);
        void ChangeRestaurantTableStatusToTrue(int id);
    }
}
