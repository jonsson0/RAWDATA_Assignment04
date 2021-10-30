using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment4.Domain
{
    public class OrderDetail
    {
        public int UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public int OrderId { get; set; }
        public List<Order> Orders { get; set; }
        public int ProductId { get; set; }
        public  Product Product { set; get; }
         
        
   




public override string ToString()
        {
            return $"Unit Price = {UnitPrice}, Quantity = {Quantity}, Discount = {Discount}, Order = {Orders}, Product = {Product}";
        }
        
     
    }
   
}
