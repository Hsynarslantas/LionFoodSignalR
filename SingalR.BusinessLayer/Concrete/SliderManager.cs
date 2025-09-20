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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderdal;

        public SliderManager(ISliderDal sliderdal)
        {
            _sliderdal = sliderdal;
        }

        public void TAdd(Slider entity)
        {
          _sliderdal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
           _sliderdal.Delete(entity);
        }

        public Slider TGetById(int id)
        {
            return _sliderdal.GetById(id);
        }

        public List<Slider> TGetListAll()
        {
            return _sliderdal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            _sliderdal.Update(entity);
        }
    }
}
