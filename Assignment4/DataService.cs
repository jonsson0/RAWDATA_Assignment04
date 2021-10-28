﻿using System;
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
        bool CreateCategory(Category category);

        IList<Product> GetProducts();

        Category GetCategory(int id);


    }

    public class DataService : IDataService
    {
        public bool CreateCategory(Category category)
        {
            var ctx = new NorthwindContext();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            ctx.Add(category);
            return ctx.SaveChanges() > 0;
        }

        public bool CreateCategory(String name, String description)
        {
            var ctx = new NorthwindContext();
            var category = new Category();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            category.Name = name;
            category.Description = description;
            ctx.Add(category);
            return ctx.SaveChanges() > 0;
        }

        public IList<Category> GetCategories()
        {
            var ctx = new NorthwindContext();
            return ctx.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var c = new Category();
            foreach(Category category in GetCategories())
            {
                if(category.Id == id)
                {
                    c = category;
                }
            }
            Console.WriteLine(c.Name);
            return c;
        }


        public IList<Product> GetProducts()
        {
            var ctx = new NorthwindContext();
            return ctx.Products.ToList();
        }
    }
}
    


