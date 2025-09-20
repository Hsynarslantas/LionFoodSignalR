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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _FeatureDal;
        public FeatureManager(IFeatureDal FeatureDal)
        {
            _FeatureDal = FeatureDal;
        }
        public void TAdd(Feature entity)
        {
            _FeatureDal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _FeatureDal.Delete(entity);
        }


        public Feature TGetById(int id)
        {
            return _FeatureDal.GetById(id);
        }

        public List<Feature> TGetListAll()
        {
            return _FeatureDal.GetListAll();
        }

        public void TUpdate(Feature entity)
        {
            _FeatureDal.Update(entity);
        }
    }
}
