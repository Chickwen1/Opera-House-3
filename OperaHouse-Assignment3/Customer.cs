using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaHouse_Assignment3
{
    public class Customer
    {
        public string Name { get; set; }
        public int NumberOfTickets { get; set; }
        public int Age { get; set; }

        public Customer(string name, int numberOfTickets, int age)
        {
            this.Name = name;
            this.NumberOfTickets = numberOfTickets;
            this.Age = age;
        }

        public bool IsSenior()
        {
            if (Age >= 65)
                return true;
            else return false;
        }
    }
}
