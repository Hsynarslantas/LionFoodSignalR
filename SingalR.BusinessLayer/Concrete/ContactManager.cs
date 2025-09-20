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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _ContactDal;
        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }
        public void TAdd(Contact entity)
        {
            _ContactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _ContactDal.Delete(entity);
        }


        public Contact TGetById(int id)
        {
            return _ContactDal.GetById(id);
        }

        public List<Contact> TGetListAll()
        {
            return _ContactDal.GetListAll();
        }

        public void TUpdate(Contact entity)
        {
            _ContactDal.Update(entity);
        }
    }
}
