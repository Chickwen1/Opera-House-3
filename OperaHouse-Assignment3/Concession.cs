using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaHouse_Assignment3
{
    public class Concession
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Concession (string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
