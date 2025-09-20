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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketdal;

        public BasketManager(IBasketDal basketdal)
        {
            _basketdal = basketdal;
        }

        public void TAdd(Basket entity)
        {
            _basketdal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketdal.Delete(entity);
        }

        public List<Basket> TGetBasketByTableNumber(int id)
        {
            return _basketdal.GetBasketByTableNumber(id);
        }

        public Basket TGetById(int id)
        {
            return _basketdal.GetById(id);
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
