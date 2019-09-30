using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaHouse_Assignment3
{
    public class Event
    {
        private int originalTicketCount;

        public DateTime EventTime { get; set; }
        public string Title { get; set; }
        public Performer Performer { get; set; }
        public int NumTickets
        {
            get { return originalTicketCount - NumSoldTickets; }
        }
        public int NumSoldTickets
        {
            get
            {
                int i = 0;
                foreach (Ticket t in tickets)
                {
                    if (t.Sold == true)
                    {
                        i++;
                    }
                }
                return i;
            }
            
        }

        public bool ConcessionSales { get; set; }
        public int DurationMinutes { get; set; }

        public Stage Stage { get; set; }
        public Concession Concession { get; set; }
        public Customer Customer { get; set; }
        public int TicketPrice { get; set; }
        private List<Ticket> tickets;
        public Event(string title, Performer performer, int numTickets, int ticketPrice, DateTime eventTime, int durationMinutes, bool concessionSales)
        {
            this.Title = title;
            this.Performer = performer;
            if (numTickets < 0)
                numTickets = 0;
            this.originalTicketCount = numTickets;
            this.EventTime = eventTime;
            this.TicketPrice = ticketPrice;
            this.DurationMinutes = durationMinutes;
            this.ConcessionSales = concessionSales;

            tickets = new List<Ticket>();
            for (int i = 0; i < numTickets; i++)
            {
                tickets.Add(new Ticket(ticketPrice, i, false));
            }
            
        }

        public override string ToString()
        {
            string result = Title + " by " + Performer + " on " + EventTime.ToShortDateString();
            result += " at " + EventTime.ToShortTimeString() + ". Concessions: ";
            result += ConcessionSales ? "Yes. " : "No. ";
            result += "Tickets available: " + NumTickets;
            return result;
        }


        public bool IsWeekend()
        {
            if (EventTime.DayOfWeek == DayOfWeek.Sunday || EventTime.DayOfWeek == DayOfWeek.Saturday)
                return true;
            else return false;

        }

        public double ConcessionRevenue()
        {
            double concessionRevenue = Concession.Price * Concession.Quantity;
            return concessionRevenue;
        }

        public double ShowExpenses()
        {
            double stageCost = Stage.CostPerHour * DurationMinutes / 60.0 + Stage.CleaningFee;
            if (!IsWeekend())
                stageCost *= 0.9;
            return stageCost + Performer.Fee;

        }

        public double Profit()
        {

            return TicketSales() - ShowExpenses();
        }

        public bool Profitable()
        {
            return Profit() > 0;
        }

        public double TicketSales()
        {
            return NumSoldTickets * TicketPrice;
        }

        public double TicketDiscount()
        {
            if (Customer.IsSenior() == true)
            {
                return TicketPrice * .9;
            }
            else return TicketPrice;
        }

        public double SellTickets(int tickets)
        {
            int i = 0;
            if (NumTickets - tickets >= 0)
            {
                foreach (Ticket t in this.tickets)
                {
                    while (i < tickets && t.Sold == false)
                    {
                        t.Sold = true;
                        i++;
                    }
                }
                return i * TicketPrice;
            }
            else
            {
                return 0;
            }
        }

        public double StageSection()
        {
            switch (Stage.StageSection)
            {
                case "A":
                    return TicketPrice + 20;
                case "B":
                    return TicketPrice + 15;
                case "C":
                    return TicketPrice + 10;
                case "D":
                    return TicketPrice + 5;
                case "VIP":
                    return TicketPrice + 50;
                default:
                    return TicketPrice;
            }
        }

        public double ReturnTickets(List<int> ticket)
        {
            double sum = 0;
            foreach (Ticket t in tickets)
            {
                foreach (int n in ticket)
                {
                    if (t.SeatNumber == n && t.Sold == true)
                    {
                        t.Sold = false;
                        sum += TicketPrice;
                
                    }
                }
            }
            return sum;
        }
    }

}

