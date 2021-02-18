using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
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
                    "Welcome to the Komodo Employee Badge information application.\n" +
                    "-------------------------------------------------------------\n" +
                    "                       1. Create a badge                     \n" +
                    "                   2. Update/Delete a badge                  \n" +
                    "                      3. List all badges                     \n" +
                    "                            4. Exit                          \n"
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Create();
                        break;
                    case "2":
                        UpdateDelete();
                        break;
                    case "3":
                        List();
                        break;
                    case "4":
                        isRunning = false;
                        break;

                }
            }
        }

        public void Create()
        {
            Badges content = new Badges();
            content.DoorAccess = new List<string>();

            Console.Clear();
            Console.WriteLine("Input a badge #: ");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine($"Badge ID: {content.BadgeID}\n");
            Console.WriteLine($"Enter a door that Badge #{content.BadgeID} needs access to: \n" +
                $"\n");
            content.DoorAccess.Add(Console.ReadLine());

            bool yes = true;

            while (yes)
            {
                Console.WriteLine($"Would you like to add another door to Badge #{content.BadgeID}? (y/n)");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "y":
                        Console.WriteLine($"Enter a door that Badge #{content.BadgeID} needs access to: ");
                        content.DoorAccess.Add(Console.ReadLine());
                        break;
                    case "n":
                        yes = false;
                        break;
                }
            }

            _repo.AddBadge(content);

            Console.Clear();

            Console.WriteLine($"Badge #{content.BadgeID} has been created");
               Console.WriteLine("Press a key to proceed.");

            Console.ReadKey();
        }

        public void UpdateDelete()
        {
            Badges content = new Badges();
            content.DoorAccess = new List<string>();

            Console.Clear();
            Console.WriteLine("Please input the badge # to either update or delete.");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine
                (
                $"Please select a function below\n" +
                $"------------------------------\n"+
                $"       1. Add a door          \n" +
                $"      2. Remove a door        \n" +
                $"      3. Return to menu       \n"
                );

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddDoorToEdit(content.BadgeID);
                    break;
                case "2":
                    RemoveDoorFromEdit(content.BadgeID);
                    break;
                case "3":
                    RunMenu();
                    break;
            }
        }

        public void AddDoorToEdit(int badgeid)
        {
            Console.WriteLine("Input a door you would like to add.");
            string door = Console.ReadLine();
            _repo.GiveAccess(badgeid, door);

            Console.WriteLine("Press a key to proceed.");
            Console.ReadKey();

        }

        public void RemoveDoorFromEdit(int badgeid)
        {
            Console.WriteLine("Input a door you would like to delete.");
            string door = Console.ReadLine();
            _repo.RemoveAccess(badgeid, door);

            Console.WriteLine("Press a key to proceed.");
            Console.ReadKey();
        }

        public void List()
        {
            Dictionary<int, List<string>> BadgeList = _repo.GetDictonary();

            foreach (KeyValuePair<int, List<string>> badge in BadgeList)
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
            }
            Console.WriteLine("\nPress a key to proceed.");
            Console.ReadLine();
        }



        public void SeedContent()
        {
            Badges badgeOne = new Badges(12345, new List<string> { "A7" });
            Badges badgeTwo = new Badges(22345, new List<string> { "A1, A4, B1, & B2" });
            Badges badgeThree = new Badges(32345, new List<string> { "A4 & A5" });
            _repo.AddBadge(badgeOne);
            _repo.AddBadge(badgeTwo);
            _repo.AddBadge(badgeThree);
        }
    }
}