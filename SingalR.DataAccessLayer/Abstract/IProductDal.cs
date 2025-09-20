using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SingalR.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        public int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        decimal ProductPriceAvg();
        string ProductNameByMinPrice();
        string ProductNameByMaxPrice();
        decimal ProductPriceByHamburger();
        decimal ProductPriceBySmashBurger();
        decimal TotalPriceByDrinkCategory();
        decimal TotalPriceByPizzaCategory();
        List<Product> GetLast9Products();
    }
}
