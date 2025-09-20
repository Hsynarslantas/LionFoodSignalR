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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _BookingDal;
        public BookingManager(IBookingDal BookingDal)
        {
            _BookingDal = BookingDal;
        }
        public void TAdd(Booking entity)
        {
            _BookingDal.Add(entity);
        }

        public void TBookingStatusApproved(int id)
        {
            _BookingDal.BookingStatusApproved(id);
        }

        public void TBookingStatusCancelled(int id)
        {
            _BookingDal.BookingStatusCancelled(id);
        }

        public void TDelete(Booking entity)
        {
            _BookingDal.Delete(entity);
        }


        public Booking TGetById(int id)
        {
            return _BookingDal.GetById(id);
        }

        public List<Booking> TGetListAll()
        {
            return _BookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _BookingDal.Update(entity);
        }
    }
}
