using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe
{
    public class ProgramUI
    {
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            Menu coffee = new Menu(1, "1. Coffee", "Bean juice", new List<string>() { "Water", "Beans" }, 2.99);
            Menu espresso = new Menu(2, "2. Shot of Espresso", "Instant gratification", new List<string>() { "Water", "Espresso" }, 1.99);
            Menu pastry = new Menu(3, "3. Pastry", "Tasty treat to go with your drink", new List<string>() { "Sugar", "Spice", "Everything Nice" }, 3.49);
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What would you like to purchase?\n");
                Console.WriteLine(coffee.MealName);
                Console.WriteLine(espresso.MealName);
                Console.WriteLine(pastry.MealName);
                Console.WriteLine("86. Nothing\n");
                string selection = Console.ReadLine();

                if (selection == "1" || selection == "Coffee" || selection == "coffee")
                {
                    Console.WriteLine("Your coffee will be out shortly. Cream and sugar are available at the bar.");
                    Thread.Sleep(4000);
                    break;
                }
                else if (selection == "2" || selection == "Shot of Espresso" || selection == "shot of espresso" || selection == "Espresso" || selection == "espresso")
                {
                    Console.WriteLine("Shots! Shots! Shots!");
                    Thread.Sleep(4000);
                    break;
                }
                else if (selection == "3" || selection == "Pastry" || selection == "pastry") 
                {
                    Console.WriteLine("Your pastry will be out shortly. Napkins can be found at the bar.");
                    Thread.Sleep(4000);
                    break;
                }
                else if (selection == "86" || selection == "Nothing" || selection == "nothing")
                {
                    Console.WriteLine("Why did you come to the counter?");
                    continueToRun = false;
                    Thread.Sleep(4000);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection (try the item number or name)\n");
                    Thread.Sleep(4000);
                }
            }
        }
    }
}
