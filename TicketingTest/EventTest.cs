using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperaHouse_Assignment3;
using System.Collections.Generic;

namespace TicketingTest
{
    [TestClass]
    public class EventTest
    {
        Event shrek, deathShow, belushiShow;
        Stage main, lounge;
        Performer drDeath;
        Performer belushi;
        Concession popcorn, water, snickers;
        Customer jim, jane;


        [TestInitialize]
        public void SetUp()
        {
            Performer osawaHigh = new Performer("Osawa High School", 0);
            shrek = new Event("Shrek", osawaHigh, 150, 12, new DateTime(2015, 4, 18, 19, 30, 0), 60, true);
            drDeath = new Performer("Dr Death", 1500);
            belushi = new Performer("Jim Belushi", 3500);
            deathShow = new Event("Dr. Death's Musical Adventures", drDeath,  200, 20, new DateTime(2015, 4, 25, 19, 0, 0), 60, true);
            belushiShow = new Event("Belushi and the Board of Comedy", belushi,  160, 33, new DateTime(2015, 3, 4, 19, 45, 0), 60, false);
            main = new Stage("Main Stage", 100, 150,"VIP");
            lounge = new Stage("The Lounge", 75, 50,"B");
            popcorn = new Concession("Popcorn", 4.50, 2);
            water = new Concession("Water", 2, 4);
            snickers = new Concession("Snickers", 1.50, 3);
            jim = new Customer("Jim", 10, 30);
            jane = new Customer("Jane", 1, 74);
        }

        [TestMethod]
        public void TestNumTickets()
        {
            Assert.AreEqual(150, shrek.NumTickets);
        }
        [TestMethod]
        public void TestSellTickets()
        {
            Assert.AreEqual(150, shrek.NumTickets);
            double amountSold = shrek.SellTickets(10); //sell 10 tickets
            Assert.AreEqual(120, amountSold); //for $120
            Assert.AreEqual(140, shrek.NumTickets); //only 140 tickets left
            amountSold = shrek.SellTickets(140); //sell the rest of the tickets
            Assert.AreEqual(140 * 12, amountSold);
            Assert.AreEqual(0, shrek.NumTickets);
       
        }

        [TestMethod]
        public void TestSellTooManyTickets()
        {
            shrek.SellTickets(140); 
            Assert.AreEqual(10, shrek.NumTickets);
            Assert.AreEqual(140, shrek.NumSoldTickets);
            shrek.SellTickets(20);//Test another partition. Too many tickets sold-shouldn't change anything
            Assert.AreEqual(140, shrek.NumSoldTickets);
            Assert.AreEqual(10, shrek.NumTickets);
        }

        [TestMethod]
        public void TestReturnTickets()
        {
            shrek.SellTickets(5);
            List<int> ticketNums = new List<int>((new int[] { 1, 2, 3 }));
            double amountReturned = shrek.ReturnTickets(ticketNums);//Return tickets num 1,2,3
            Assert.AreEqual(3 * 12, amountReturned);
            Assert.AreEqual(148, shrek.NumTickets);
        }

        [TestMethod]
        public void TestSales()
        {
            deathShow.Stage = main;
            double amountSold = deathShow.SellTickets(10);
            Assert.AreEqual(10 * 20, amountSold);
            deathShow.SellTickets(5);
            Assert.AreEqual(10 * 20 + 5 * 20, deathShow.TicketSales()); //Check the total ticket sales
            deathShow.SellTickets(185); //sell out
            Assert.AreEqual(10*20 + 5*20 + 185*20, deathShow.TicketSales());

        }
        [TestMethod]
        public void TestDayOfWeek()
        {
            Assert.IsTrue(deathShow.IsWeekend());
            Assert.IsTrue(shrek.IsWeekend());
            Assert.IsFalse(belushiShow.IsWeekend());

        }

        [TestMethod]
        public void TestProfit()
        {
            deathShow.Stage = main;
            deathShow.SellTickets(200);
            double profit = 20 * 200 - 1500 - 150 - 100;
            Assert.AreEqual(profit, deathShow.Profit());
            Assert.IsTrue(deathShow.Profitable());
        }



        [TestMethod]
        public void TestExpenses()
        {
            deathShow.Stage = main;
            double expenses = drDeath.Fee + main.CostPerHour * 1 + main.CleaningFee;
            Assert.AreEqual(expenses, deathShow.ShowExpenses());

            belushiShow.Stage = main;

            expenses = main.CostPerHour * 1 + main.CleaningFee;
            expenses -= expenses * 0.1;
            expenses += belushi.Fee;

            Assert.AreEqual(expenses, belushiShow.ShowExpenses());

        }

        [TestMethod]
        public void TestSeniorDiscount()
        {
            Assert.IsTrue(jane.IsSenior());
            Assert.IsFalse(jim.IsSenior());
        }

        [TestMethod]
        public void TestStageSection()
        {
            deathShow.Stage = main;
            shrek.Stage = lounge;
            Assert.AreEqual(27, shrek.StageSection());
            Assert.AreEqual(70, deathShow.StageSection());
        }

        [TestMethod]
        public void TestProfitability()
        {
            deathShow.Stage = main;
            shrek.Stage = lounge;

            shrek.SellTickets(1);
            deathShow.SellTickets(200);

            Assert.IsFalse(shrek.Profitable());
            Assert.IsTrue(deathShow.Profitable());
        }
    }
}
