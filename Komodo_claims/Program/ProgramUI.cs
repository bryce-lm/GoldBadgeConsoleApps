using ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsProgram
{
    public class UI
    {
        private Repository _repo = new Repository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                    "Hello, welcome to Komodo Insurance Claims.\n" +
                    "------------------------------------------\n" +
                    "              1. List all claims          \n" +
                    "              2. Take next claim          \n" +
                    "                3. Add a claim            \n" +
                    "                   4. Exit                \n"
                    );

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListClaims();
                        break;
                    case "2":
                        InputClaims();
                        break;
                    case "3":
                        AddClaims();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                }
            }
        }
        public void InputClaims()
        {
            Console.Clear();
            Console.WriteLine("Here are the details on the next claim to be handled: \n");

            Queue<Claims> newList = _repo.GetList();
            Claims nextClaim = newList.Peek();

            Console.WriteLine
                (
                $"ID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Price: ${nextClaim.Price}\n" +
                $"Incident Date: {nextClaim.IncidentDate.ToShortDateString()}\n" +
                $"Claim Date: {nextClaim.ClaimDate.ToShortDateString()}\n" +
                $"Valid: {nextClaim.IsValid}\n" +
                $"\n" +
                $"Is this claim correct? (y/n)"
                );

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("The claim has been added, please enter either y or n followed by enter to proceed.");
                    break;
                case "n":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter either y or n followed by enter to proceed.");
                    break;
            }
            Console.ReadLine();
        }
        public void ListClaims()
        {
            Console.Clear();
            Queue<Claims> claimList = _repo.GetList();

            Console.WriteLine
                (
                "ClaimID  Type   DateOfAccident  DateOfClaim   IsValid   Amount   Description\n"
                );

            foreach (Claims content in claimList)
            {
                Console.WriteLine
                    (
                    $"{ content.ClaimID} {content.ClaimType}     {content.IncidentDate.ToShortDateString()}     {content.ClaimDate.ToShortDateString()}     {content.IsValid}       ${content.Price}    {content.Description}\n"
                    );
            }

            Console.WriteLine("Press any key followed by enter to proceed.");
            Console.ReadKey();
        }
        public void AddClaims()
        {
            Claims content = new Claims();

            Console.Clear();
            Console.WriteLine($"(ID) (Type) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) (Type) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the type of claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    content.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    content.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    content.ClaimType = ClaimType.Theft;
                    break;
            }

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) (Description) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter a description of the claim ");
            content.Description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (Damage) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the claim amount:");
            content.Price = decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (${content.Price}) (Accident Date) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of the incident: ");
            content.IncidentDate = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"({content.ClaimID}) ({content.ClaimType}) ({content.Description}) (${content.Price}) ({content.IncidentDate}) (Claim Date) (Valid)\n");

            Console.WriteLine("Enter the date of claim: ");
            content.ClaimDate = DateTime.Parse(Console.ReadLine());

            _repo.IsValid(content);

            Console.Clear();
            Console.WriteLine
                (
                $"You are about to add the following claim to the queue: \n" +
                $"\n" +
                $"ID: {content.ClaimID}\n" +
                $"Type: {content.ClaimType}\n" +
                $"Description: {content.Description}\n" +
                $"Amount: ${content.Price}\n" +
                $"Incident Date: {content.IncidentDate}\n" +
                $"Claim Date: {content.ClaimDate}\n" +
                $"Valid: {content.IsValid}\n" +
                $"\n" +
                $"Press any key followed by enter to proceed."
                );

            Console.ReadKey();

            _repo.AddClaim(content);

            Console.Clear();
            Console.WriteLine("Claim successfully added to the queue!\n" +
                "Press any key to return to the menu...");
            Console.ReadKey();
        }

        public void SeedContent()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465.", 450.00m, DateTime.Parse("04/25/2018"), DateTime.Parse("04/27/2018"), true);

            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, DateTime.Parse("04/11/2018"), DateTime.Parse("04/13/2018"), false);

            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("04/29/2018"), true);

            _repo.AddClaim(claimOne);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
        }
    }
}