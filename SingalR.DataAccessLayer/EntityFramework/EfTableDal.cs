using SignalR.EntityLayer.Entities;
using SingalR.DataAccessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DataAccessLayer.Repositories;

namespace SingalR.DataAccessLayer.EntityFramework
{
    public class EfTableDal : GenericRepository<RestaurantTable>, ITableDal
    {
        public EfTableDal(SingalRContext context) : base(context)
        {
        }

        public void ChangeRestaurantTableStatusToFalse(int id)
        {
            using var context = new SingalRContext();
             var value=context.RestaurantTables.Where(x => x.RestaurantTableId == id).FirstOrDefault();
            value.Status=false; ;
            context.SaveChanges();
        }

        public void ChangeRestaurantTableStatusToTrue(int id)
        {
            using var context = new SingalRContext();
            var value = context.RestaurantTables.Where(x => x.RestaurantTableId == id).FirstOrDefault();
            value.Status = true; ;
            context.SaveChanges();
        }

        public int RestaurantTableCount()
        {
            using var context = new SingalRContext();
            return context.RestaurantTables.Count();
        }
    }
}
