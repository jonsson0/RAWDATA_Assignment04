using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Domain
{
    //ass4 inside
    //[Table("categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Product { set; get; }


        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Product = {Product}";
        }
    }
}
