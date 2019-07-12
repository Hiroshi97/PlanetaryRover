using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] scientist = { "Tom", "Oliver", "Ben", "Andy", "Jason", "Wendy", "Anna" };
            string[] kind = { "Rock", "Fossil", "Lizard", "Stone", "Bone", "Skeleton", "Soil" };
            int i; //counter loop
            Random random = new Random(); //Random object
            Execute exe = new Execute(); //Initialize program
            List<Rover> CreatedRover = new List<Rover>();
            List<Specimen> CreatedSpecimen = new List<Specimen>();
            Rover rover1 = new PlanetaryRover.Rover(15, 20, "Sun"); //Create 2 rovers
            Rover rover2 = new PlanetaryRover.Rover(0, 20, "Moon");
            CreatedRover.Add(rover1); //Add 2 rovers to a list
            CreatedRover.Add(rover2);
            Area area = new Area("Mars"); //Area
            for (i = 0; i < 10; i++)
            {
                Specimen specimen = new Specimen(random.Next(area.Width), random.Next(area.Height), scientist[random.Next(scientist.Length)] + ": " + kind[random.Next(kind.Length)], random.Next(100));

                area.List.Put(specimen);
            }
            rover1.Area = area; //Where 2 rovers are located at
            rover2.Area = area;
            string command = "";
            while (command.ToLower() != "exit")
            {
                string Msg = "", choice = "";
                i = 0; //counter
                Console.WriteLine("There is a list of rovers");
                foreach (Rover r in CreatedRover)
                {
                    i++;
                    Msg = Msg + i.ToString() + ". " + r.Name + "\n";
                }
                Console.WriteLine(Msg);
                Console.WriteLine("Which rover do you select?");
                choice = Console.ReadLine();
                while (choice != "1" && choice != "2" && choice.ToLower() != "exit")
                {
                    Console.WriteLine("Wrong input! Type again");
                    choice = Console.ReadLine();
                }
                if (choice.ToLower() == "exit")
                    command = choice;
                while (choice == "1" || choice == "2")
                {
                    if (choice == "1")
                    {
                        Console.Write("\nWelcome to " + rover1.Name + "'s interface. What do you want me to do?\nCommand --> "); command = Console.ReadLine();
                        string[] execommand = command.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (command.ToLower() == "back" || command.ToLower() == "reset" || command.ToLower() == "exit")
                            break;
                        else
                            exe.Exe(rover1, execommand);
                    }
                    else if (choice == "2")
                    {
                        Console.Write("\nWelcome to " + rover2.Name + "'s interface. What do you want me to do?\nCommand --> ");
                        command = Console.ReadLine();
                        string[] execommand = command.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (command.ToLower() == "back" || command.ToLower() == "reset" || command.ToLower() == "exit")
                            break;
                        else
                            exe.Exe(rover2, execommand);
                    }
                }
            }
        }
    }
}
