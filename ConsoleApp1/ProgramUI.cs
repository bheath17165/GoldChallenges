using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Claims
{
    public class ProgramUI
    {
    private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            MenuItems();
            RunMenu();
        }

        public void MenuItems()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _claimRepo.EnterNewClaim(claim1);
            _claimRepo.EnterNewClaim(claim2);
            _claimRepo.EnterNewClaim(claim3);
        }

        private void RunMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Choose a menu item: \n\n" +
                "1. See all claims\n\n" +
                "2. Take care of next claim\n\n" +
                "3. Enter a new claim\n\n");
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                Queue<Claim> listOfContent = _claimRepo.SeeAllClaims();
                foreach (Claim claim in listOfContent)
                {
                    Console.WriteLine(claim.ClaimID);
                    Console.WriteLine(claim.ClaimType);
                    Console.WriteLine(claim.Description);
                    Console.WriteLine(claim.ClaimAmount);
                    Console.WriteLine(claim.DateOfIncident);
                    Console.WriteLine(claim.DateOfClaim);
                }
                Console.ReadKey();
            }
            else if (selection == "2")
            {
                Console.Clear();

                Claim currentClaim = _claimRepo.Peek();
                if (currentClaim == null)
                {
                    Console.WriteLine("No claims found.");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine(
                    $"{currentClaim.ClaimID}\n" +
                    $"{currentClaim.ClaimType}\n" +
                    $"{currentClaim.Description}\n" +
                    $"{currentClaim.ClaimAmount}\n" +
                    $"{currentClaim.DateOfIncident}\n" +
                    $"{currentClaim.DateOfClaim}\n" +
                    $"{currentClaim.IsValid}\n");
                    Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        _claimRepo.Dequeue();
                        RunMenu();
                    }
                    else if (yesOrNo == "n")
                    {
                        RunMenu();
                    }
                    else
                    {
                        Console.WriteLine("This is not a valid selection.");
                        Thread.Sleep(4000);
                    }
                }
            }
                
            else if (selection == "3")
            {
                Console.Clear();

                Claim claim4 = new Claim();
                Console.Write("Enter the claim id: ");
                claim4.ClaimID = int.Parse(Console.ReadLine());
                Console.Write("Enter the claim type: ");
                claim4.ClaimType = (ClaimType) Enum.Parse(typeof(ClaimType), Console.ReadLine());
                Console.Write("Enter a claim description: ");
                claim4.Description = Console.ReadLine();
                Console.Write("Amount of Damage: $");
                claim4.ClaimAmount = double.Parse(Console.ReadLine());
                Console.Write("Date of Accident: ");
                claim4.DateOfIncident = DateTime.Parse(Console.ReadLine());
                Console.Write("Date of Claim: ");
                claim4.DateOfClaim = DateTime.Parse(Console.ReadLine());

                _claimRepo.EnterNewClaim(claim4);
                RunMenu();
            }
        }
    }
}
