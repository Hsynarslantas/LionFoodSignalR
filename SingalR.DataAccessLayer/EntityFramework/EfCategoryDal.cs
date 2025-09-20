using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;
using SingalR.DataAccessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DataAccessLayer.Repositories;

namespace SingalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SingalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new SingalRContext();
            return context.Categories.Where(x=>x.Status==true).Count();
        }

        public int CategoryCount()
        {
            using var context = new SingalRContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new SingalRContext();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
