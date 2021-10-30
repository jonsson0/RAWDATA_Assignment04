using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment4.Domain
{

    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
       
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }

        

        

        public override string ToString()
        {
            return $"OrderId = {Id}, Date = {Date}, Required = {Required}, Freight = {Freight}, ShipName = {ShipName}, ShipCity = {ShipCity}, Order Details = {OrderDetails}";
        }
    }
}
