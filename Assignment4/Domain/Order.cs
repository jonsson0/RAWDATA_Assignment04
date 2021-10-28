using System;

namespace Assignment4.Domain
{

    public class Order
    {
        public int OrderId { get; set
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; 
        public string ShipCity { get; set; 

        

        public override string ToString()
        {
            return $"OrderId = {OrderId}, OrderDate = {OrderDate}," +
                $" RequiredDate = {RequiredDate}, ShippedDate = {ShippedDate}, ShippedDate = {ShippedDate}, Freight = {Freight}," +
                $" ShipName = {ShipName}, ShipCity = {ShipCity};
        }
    }
}
