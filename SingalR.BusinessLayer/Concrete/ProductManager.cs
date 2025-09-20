using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;
using SingalR.BusinessLayer.Abstract;
using SingalR.DataAccessLayer.Abstract;
using SingalR.DataAccessLayer.EntityFramework;
using SingalR.DataAccessLayer.Migrations;

namespace SingalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _ProductDal;
        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }
        public void TAdd(Product entity)
        {
            _ProductDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _ProductDal.Delete(entity);
        }


        public Product TGetById(int id)
        {
            return _ProductDal.GetById(id);
        }

        public List<Product> TGetLast9Products()
        {
            return _ProductDal.GetLast9Products();
        }

        public List<Product> TGetListAll()
        {
            return _ProductDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _ProductDal.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _ProductDal.ProductCount();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _ProductDal.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _ProductDal.ProductCountByCategoryNameHamburger();
        }

        public string TProductNameByMaxPrice()
        {
            return _ProductDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _ProductDal.ProductNameByMinPrice();
        }

        public decimal TProductPriceAvg()
        {
            return _ProductDal.ProductPriceAvg();
        }

        public decimal TProductPriceByHamburger()
        {
            return _ProductDal.ProductPriceByHamburger();
        }

        public decimal TProductPriceBySmashBurger()
        {
            return _ProductDal.ProductPriceBySmashBurger();
        }

        public decimal TTotalPriceByDrinkCategory()
        {
           return _ProductDal.TotalPriceByDrinkCategory();
        }

        public decimal TTotalPriceByPizzaCategory()
        {
            return _ProductDal.TotalPriceByPizzaCategory();
        }

        public void TUpdate(Product entity)
        {
            _ProductDal.Update(entity);
        }
    }
}
