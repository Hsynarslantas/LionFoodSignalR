using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Abstract;

namespace SingalR.BusinessLayer.Concrete
{
    public class TableManager : ITableService
    {
        private readonly ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public void TAdd(RestaurantTable entity)
        {
            _tableDal.Add(entity);
        }

        public void TChangeRestaurantTableStatusToFalse(int id)
        {
            _tableDal.ChangeRestaurantTableStatusToFalse(id);    
        }

        public void TChangeRestaurantTableStatusToTrue(int id)
        {
            _tableDal.ChangeRestaurantTableStatusToTrue(id);
        }

        public void TDelete(RestaurantTable entity)
        {
            _tableDal.Delete(entity);
        }

        public RestaurantTable TGetById(int id)
        {
            return _tableDal.GetById(id);
        }

        public List<RestaurantTable> TGetListAll()
        {
           return _tableDal.GetListAll();
        }

        public int TRestaurantTableCount()
        {
           return _tableDal.RestaurantTableCount();
        }

        public void TUpdate(RestaurantTable entity)
        {
            _tableDal.Update(entity);
        }
    }
}
