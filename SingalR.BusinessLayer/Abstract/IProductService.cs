using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SingalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        public int TProductCountByCategoryNameDrink();
        public int TProductCountByCategoryNameHamburger();
        public decimal TProductPriceAvg();
        public string TProductNameByMaxPrice();
        public string TProductNameByMinPrice();
        public decimal TProductPriceByHamburger();
        decimal TProductPriceBySmashBurger();
        decimal TTotalPriceByPizzaCategory();
        decimal TTotalPriceByDrinkCategory();
        List<Product> TGetLast9Products();


    }
}
