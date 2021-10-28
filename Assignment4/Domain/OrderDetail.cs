using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Domain
{
    public class OrderDetail
    {
        public int UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { set; get; }
       




public override string ToString()
        {
            return $"Unit Price = {UnitPrice}, Quantity = {Quantity}, Discount = {Discount}, Order = {Order}, Product = {Product}";
        }
    }
   
}
