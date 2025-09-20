using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SingalR.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public int TCategoryCount();
        public int TPassiveCategoryCount();
        public int TActiveCategoryCount();
    }
}
