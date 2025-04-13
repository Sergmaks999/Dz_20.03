using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}";
        }
    }
}