using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment4.Domain;
using Assignment4;

namespace Assignment4
{
    // Ass4
    public interface IDataService
    {
        IList<Category> GetCategories();

        Category CreateCategory(String name, String description);

        bool DeleteCategory(int categoryID);

       bool UpdateCategory(int categoryID, string newName, string newDescription);

        IList<Product> GetProducts(int id);

        Category GetCategory(int id);

        Order GetOrder(int id);

        IList<Order> Order();

        Product GetProduct(int productId);




    }

    public class DataService : IDataService
    {
       /* I DONT KNOW IF WE MAY NEED THIS YET
        public bool CreateCategory(Category category)
        {
            var ctx = new NorthwindContext();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            ctx.Add(category);
            return ctx.SaveChanges() > 0;
        }
       */

        public 
            //bool
           Category CreateCategory(String name, String description)
        {
            var ctx = new NorthwindContext();
            var category = new Category();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            category.Name = name;
            category.Description = description;
            ctx.Add(category);
            ctx.SaveChanges();
            return category;
        }

        
        public bool DeleteCategory(int categoryID)
        {

            var ctx = new NorthwindContext();
            var category = ctx.Categories.Find(categoryID);

            if (category == null)
            {
                return false;
            }
            else
            {
                ctx.Remove(category);
                ctx.SaveChanges();
                return true;
            }
            
        }
       public bool UpdateCategory(int categoryID, string newName, string newDescription)
        {
           
            var ctx = new NorthwindContext();
            var category = ctx.Categories.Find(categoryID);
            if(category == null)
            {
                return false;
            }
            category.Name = newName;
            category.Description = newDescription;
            ctx.SaveChanges();
            return true;
        }


        public IList<Category> GetCategories()
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.Find(id);
        }


        public IList<Product> GetProducts(int id)
        {
            var ctx = new NorthwindContext();
            return ctx.Products.Include(x => x.Category).ToList();
        }

        public Product GetProduct(int productId)
        {
            var ctx = new NorthwindContext();
            Product result = ctx.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == productId);
            return result;
        }

        public IList<Product> GetProductByCategory(int categoryId)
        {
            var ctx = new NorthwindContext();

            var products = ctx.Products.Include(x => x.Category).Where(p => p.CategoryId == categoryId).ToList();
            return products;
        }

        public IList<Order> Order()
        {
            var cxt = new NorthwindContext();
            return cxt.Orders.ToList();
        }

        public Order GetOrder(int id)
        {
            var ctx = new NorthwindContext();
            return ctx.Orders.Find(id);

            /*
            var o = new Order();
            var od = new OrderDetail();
            foreach (Order order in Order())
            {
                if (order.Id == id)
                {
                    o = order;
                }
            }
            return o;
            */
               
        }
        
    }
}
    


