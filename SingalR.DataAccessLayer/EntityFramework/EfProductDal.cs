using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using SingalR.DataAccessLayer.Abstract;
using SingalR.DataAccessLayer.Concrete;
using SingalR.DataAccessLayer.Repositories;

namespace SingalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SingalRContext context) : base(context)
        {
        }

        public List<Product> GetLast9Products()
        {
            using var context = new SingalRContext();
            var values=context.Products.Take(9).ToList();
            return values;
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SingalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values; 
        }

        public int ProductCount()
        {
            using var context = new SingalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
           using var context=new SingalRContext();
            return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName== "İçecek").Select(z=>z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x=>x.Price==(context.Products.Max(y=>y.Price))).Select(z=>z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SingalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceByHamburger()
        {
            using var context = new SingalRContext();
            return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryId)).FirstOrDefault()).Average(a=>a.Price);
        }

        public decimal ProductPriceBySmashBurger()
        {
            using var context= new SingalRContext();
            return context.Products.Where(x => x.ProductName == "Smash Burger").Select(y=>y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
           using var context=new SingalRContext();
            int id=context.Categories.Where(x=>x.CategoryName=="İçecek").Select(y=>y.CategoryId).FirstOrDefault();
            return context.Products.Where(x=>x.CategoryId==id).Sum(y=>y.Price);
        }

        public decimal TotalPriceByPizzaCategory()
        {
            using var context = new SingalRContext();
            int id = context.Categories.Where(x => x.CategoryName == "Pizza").Select(y => y.CategoryId).FirstOrDefault();
            return context.Products.Where(x => x.CategoryId == id).Sum(y => y.Price);
        }
    }
}
