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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public void TAdd(Message entity)
        {
            _messagedal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            _messagedal.Delete(entity);
        }

        public Message TGetById(int id)
        {
            return _messagedal.GetById(id);
        }

        public List<Message> TGetListAll()
        {
            return _messagedal.GetListAll();
        }

        public void TUpdate(Message entity)
        {
            _messagedal.Update(entity);
        }
    }
}
