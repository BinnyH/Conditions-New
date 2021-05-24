using System;
using System.Collections.Generic;
using System.Linq;
using Conditions.Models;

namespace Conditions
{
    class Program
    {
        static void Main(string[] args)
        {

            #region "Initial Setup"
            List<TicketModel> ticketTypes = new List<TicketModel>();
            ticketTypes.Add(new TicketModel { TicketName = "Adult", TicketPrice = 4.99, TicketCode = "ADULT", TicketOption="A" });
            ticketTypes.Add(new TicketModel { TicketName = "Child", TicketPrice = 2.99, TicketCode = "CHILD", TicketOption="C" });
            ticketTypes.Add(new TicketModel { TicketName = "Student", TicketPrice = 3.75, TicketCode = "STUDENT", TicketOption="S" });
            ticketTypes.Add(new TicketModel { TicketName = "Retired", TicketPrice = 2.99, TicketCode = "RETIRED", TicketOption="R" });

            List<BasketItem> basket = new List<BasketItem>();
            #endregion


            ////customer selects ticket type
            //TicketModel selectedTicketModel = (from tm in ticketTypes where tm.TicketCode == "ADULT" select tm).Single();
            ////customer enters quantity
            ////add order into basket
            //basket.Add(new BasketItem { Quantity = 4, ticketModel = selectedTicketModel })

            double ticketPrice = 0;

            Console.WriteLine("Welcome!\nAdult tickets = £4.99.\nChild tickets = £2.99.\nStudent tickets = £3.75\nRetired tickets = £2.29.");

            //Allow for buying of multiple types of tickets

            #region "Basket Entry"

            string ticketTypeEntered = "";

          
            {
                //Ask the use to choose an option.
                Console.WriteLine("\nPlease select the option you want?");

                foreach (TicketModel ticketModel in ticketTypes)
                {
                    Console.WriteLine("\t" + ticketModel.TicketOption + " - " + ticketModel.TicketName);
                }

                //Console.WriteLine("\tA - Adult");
                //Console.WriteLine("\tC - Child");
                //Console.WriteLine("\tS - Student");
                //Console.WriteLine("\tR - Retired");
                Console.Write("Your Option?");
                ticketTypeEntered = Console.ReadLine();

                TicketModel selectedTicketType = null;

                switch (ticketTypeEntered)
                {
                    case "A":
                        Console.WriteLine(4.99);
                        ticketPrice = 4.99;
                        selectedTicketType = (from tm in ticketTypes where tm.TicketCode == "ADULT" select tm).Single();
                        break;
                    case "C":
                        Console.WriteLine(2.99);
                        ticketPrice = 2.99;
                        selectedTicketType = (from tm in ticketTypes where tm.TicketCode == "CHILD" select tm).Single();
                        break;
                    case "S":
                        Console.WriteLine(3.75);
                        ticketPrice = 3.75;
                        selectedTicketType = (from tm in ticketTypes where tm.TicketCode == "STUDENT" select tm).Single();
                        break;
                    case "R":
                        Console.WriteLine(2.29);
                        ticketPrice = 2.29;
                        selectedTicketType = (from tm in ticketTypes where tm.TicketCode == "RETIRED" select tm).Single();
                        break;
                }

                if(selectedTicketType != null)
                {
                    //carry on
                }

                Console.WriteLine("Please select how many tickets you would like to purchase?");

                int numberOfTickets = 0;
                //return to hear if...
                while (numberOfTickets <= 0)
                {

                    //option to buy muliple tickets 
                    string userAnswer = Console.ReadLine();
                    numberOfTickets = int.Parse(userAnswer);

                    if (numberOfTickets <= 0)
                    {
                        Console.WriteLine("Please select how many tickets you would like to purchase.");
                        Console.ReadLine();
                    }

                    string userAnswer2 = Console.ReadLine();

                }
            }

            #endregion

            #region "Checkout Process"

            double totalCost = (from basketItem in basket
                                   select basketItem.ticketModel.TicketPrice * basketItem.Quantity
 
                               ).Sum();

            Console.WriteLine("Your total comes to £" + totalCost.ToString("0.00") + ". Please insert cash or card.");
            //wait for enough money
            double cashAmount = 0;

            //loop here until they provide enough payment

            while (cashAmount < totalCost)
            {

                string userResponse = Console.ReadLine();

                cashAmount = double.Parse(userResponse);

                if (cashAmount < totalCost)
                {
                    Console.WriteLine("That is not enough. Please insert Cash or Card");
                }
                 else 
                {
                    if (cashAmount == totalCost)
                    {
                        Console.WriteLine("Here is your ticket. Enjoy the show!");
                    }
                    else
                    {
                        double change = cashAmount - totalCost;
                        Console.WriteLine("Here is your ticket and £" + change.ToString("0.00") + " change. Enjoy the show!");
                    }
                }
            }

            //wait before closing
            Console.ReadKey();

            #endregion 
        }
    }
}
