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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _SocialMediaDal;
        public SocialMediaManager(ISocialMediaDal SocialMediaDal)
        {
            _SocialMediaDal = SocialMediaDal;
        }
        public void TAdd(SocailMedia entity)
        {
            _SocialMediaDal.Add(entity);
        }

        public void TDelete(SocailMedia entity)
        {
            _SocialMediaDal.Delete(entity);
        }


        public SocailMedia TGetById(int id)
        {
            return _SocialMediaDal.GetById(id);
        }

        public List<SocailMedia> TGetListAll()
        {
            return _SocialMediaDal.GetListAll();
        }

        public void TUpdate(SocailMedia entity)
        {
            _SocialMediaDal.Update(entity);
        }
    }
}
