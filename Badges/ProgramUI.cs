using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Badges
{
    public class ProgramUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void SeedContent()
        {
            //List<string> firstList = new List<string>() {" "}
            _badgeRepo.CreateNewBadge(12345, new List<string>() { "A7" });
            _badgeRepo.CreateNewBadge(22345, new List<string>() { "A1", "A4", "B1", "B2" });
            _badgeRepo.CreateNewBadge(32345, new List<string>() { "A4", "A5" });
        }

        public void RunMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin, What would you like to do?");
            Console.Write("1. Add a badge\n");
            Console.Write("2. Edit a badge\n");
            Console.Write("3. List all badges\n");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                List<string> newDoorName = new List<string>();
                Console.Write("What is the number on the badge: ");
                string badgeID = Console.ReadLine();
                Console.Write("List a door that it needs access to: ");
                string doorName = Console.ReadLine();
                newDoorName.Add(doorName);
                bool isTrue = true;
                while (isTrue)
                {
                    Console.Write("Any other doors(y/n)? ");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        Console.Write("List a door that it needs access to: ");
                        string anotherDoorName = Console.ReadLine();
                        newDoorName.Add(anotherDoorName);
                    }
                    else if (yesOrNo == "n")
                    {
                        _badgeRepo.CreateNewBadge(Convert.ToInt32(badgeID), newDoorName);
                        isTrue = false;
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid selection.");
                        Thread.Sleep(4000);
                    }
                }
                RunMenu();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.Write("What is the badge number to update? ");
                string badgeID = Console.ReadLine();
                List<string> doorAccess = _badgeRepo.GetDoorAccess(Convert.ToInt32(badgeID));
                Console.WriteLine(badgeID + " has access to doors ");
                foreach (string door in doorAccess)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Remove a door");
                Console.WriteLine("2. Add a door");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Which door would you like to remove? ");
                    string doorName = Console.ReadLine();
                    _badgeRepo.DeleteDoorOfBadge(Convert.ToInt32(badgeID), doorName);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the new door: ");
                    string newDoorName = Console.ReadLine();
                    _badgeRepo.UpdateDoorOnExistingBadge(Convert.ToInt32(badgeID), newDoorName);
                    bool isTrue = true;
                    while (isTrue)
                    {
                        Console.Write("Any other doors(y/n)? ");
                        string yesOrNo = Console.ReadLine();
                        if (yesOrNo == "y")
                        {
                            Console.Write("List a door that it needs access to: ");
                            string anotherDoorName = Console.ReadLine();
                            _badgeRepo.UpdateDoorOnExistingBadge(Convert.ToInt32(badgeID), anotherDoorName);
                        }
                        else if (yesOrNo == "n")
                        {
                            isTrue = false;
                        }
                        else
                        {
                            Console.WriteLine("This is not a valid selection.");
                            Thread.Sleep(4000);
                        }
                    }
                    RunMenu();
                }
                else
                {
                    Console.WriteLine("This is not a valid selection.");
                    Thread.Sleep(4000);
                }
            }
        }
    }
}
