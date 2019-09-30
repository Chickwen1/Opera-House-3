using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaHouse_Assignment3
{
    public class Ticket
    {
        
        public double TicketPrice { get; set; }
        public int SeatNumber { get; set; }
        public bool Sold { get; set; }

        public Ticket(double ticketPrice, int seatNumber, bool sold)
        {
            this.TicketPrice = ticketPrice;
            this.SeatNumber = seatNumber;
            this.Sold = sold;
        }
    }
}
