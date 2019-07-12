using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Execute
    {
        private List<Device> CreatedDevice = new List<Device>(); //List of devices for rover 1
        public void PrintHelp()
        {
            Console.WriteLine("USEFUL COMMANDS\n");
            Console.WriteLine("**************************************************");
            Console.WriteLine("? - To see useful commands table");
            Console.WriteLine("prepare - To create automatically all necessary devices for the chosen rover");
            Console.WriteLine("attach/detach */all/auto - To attach/ detach aspecific device or attach all (all/auto)");
            Console.WriteLine("information/rover - To check information of the chosen rover");
            Console.WriteLine("location - To check a current location of the chosen rover");
            Console.WriteLine("battery/batteries - To check a battery list of the chosen rover");
            Console.WriteLine("perform - To operate the chosen attached device in rover");
            Console.WriteLine("check - To check if one or many devices are attached or not");
            Console.WriteLine("check battery/batteries- To check a list of assigned battery");
            Console.WriteLine("check information/rover- To check information of the chosen rover");
            Console.WriteLine("**************************************************");
        }
        public void PreparePreset(Rover rover)
        {
            rover.TotalOfBatteries(5);
            Device motorup1 = new Motor("motor up", "up"); //Devices
            CreatedDevice.Add(motorup1);
            Device motordown1 = new Motor("motor down", "down"); //Devices
            CreatedDevice.Add(motordown1);
            Device motorleft1 = new Motor("motor left", "left"); //Devices
            CreatedDevice.Add(motorleft1);
            Device motorright1 = new Motor("motor right", "right"); //Devices
            CreatedDevice.Add(motorright1);
            Device solar1 = new SolarPanel("solar");
            CreatedDevice.Add(solar1);
            Device radarloc1 = new Radar("radar loc", "location");
            CreatedDevice.Add(radarloc1);
            Device radarsize1 = new Radar("radar size", "size");
            CreatedDevice.Add(radarsize1);
            Device radarname1 = new Radar("radar name", "name");
            CreatedDevice.Add(radarname1);
            Device drill1 = new Drill("drill");
            CreatedDevice.Add(drill1);
            Console.WriteLine("Preset Batteries and Devices are created\n");
            Console.WriteLine("List Of Created Devices");
            foreach (Device d in CreatedDevice)
            {
                Console.WriteLine(d.Name);
            }
        }
        public Device CheckNameType(Rover rover, string name)
        {
            foreach (Device d in rover.DeviceList)
            {
                if (d.Name.ToLower() == name.ToLower())
                    return d;
            }
            return null;
        }
        public void Exe(Rover rover, string[] text)
        {
            if (text.Length == 1)
            {
                if (text[0] == "perform") //Perform command
                {
                    Console.WriteLine("What is its name?");
                    string name = Console.ReadLine();
                    if (CheckNameType(rover, name.ToLower()) != null)
                    {
                        rover.Perform(CheckNameType(rover, name.ToLower()));
                    }
                    else Console.WriteLine("There is no " + name + " device in this rover!");
                }
                else if (text[0] == "information" || text[0] == "rover")
                    rover.Information(); //Call Information method from rover
                else if (text[0] == "look")
                    rover.Area.Detail();
                else if (text[0] == "location")
                    rover.Location();
                else if (text[0] == "battery" || text[0] == "batteries")
                    Console.WriteLine("List of Batteries: \n" + rover.ListOfBatteries);
                else if (text[0] == "prepare")
                    PreparePreset(rover);
                else if (text[0] == "?")
                    PrintHelp();
                else Console.WriteLine("What are you trying to do???");
            }
            else if (text.Length == 2)
            {
                if (text[0] == "check") //Check command
                {
                    switch (text[1])
                    {
                        case "battery":
                        case "batteries":
                            Console.WriteLine("List of Batteries: \n" + rover.ListOfBatteries);
                            break;
                        case "rover":
                        case "information":
                            rover.Information();
                            break;
                        default:
                            {
                                if (rover.IsAttached(text[1]))
                                    Console.WriteLine(text[1] + " is attached!");
                                else Console.WriteLine(text[1] + "is not attached!");
                            }
                            break;
                    }
                }
                if (text[0] == "change" && (text[1] == "battery" || text[1] == "batteries"))
                {
                    string temp, temp1;
                    Console.WriteLine("What is a name of the device that you want to change battery?");
                    temp = Console.ReadLine();
                    foreach (Device dev in rover.DeviceList)
                    {
                        if (rover.IsAttached(temp) && dev.Name == temp)
                        {
                            Console.WriteLine("What is a name of battery?");
                            temp1 = Console.ReadLine();
                            rover.ChangeBattery(dev, temp1);
                        }
                    }
                }
                if (text[0] == "attach" && CreatedDevice.Count != 0)
                {
                    if (text[1] == "auto" || text[1] == "all")
                    {
                        foreach (Device d in CreatedDevice)
                            if (!rover.IsAttached(d.Name))
                                rover.Attach(d);
                    }
                    else if (text[1] == "motor" || text[1] == "radar" || text[1] == "solar" || text[1] == "drill")
                    {
                        string name;
                        Console.WriteLine("What is device's name?");
                        name = Console.ReadLine();
                        foreach (Device d in CreatedDevice)
                            if (d.Name == name.ToLower())
                                rover.Attach(d);
                    }
                    else Console.WriteLine("There is no possible device to attach!");
                }
                if (text[0].ToLower() == "detach")
                {
                    if (text[1] == "auto" || text[1] == "all")
                    {
                        foreach (Device d in CreatedDevice)
                            rover.Detach(d);
                        Console.WriteLine("--> Detach successfully!");
                    }
                    else if (text[1] == "motor" || text[1] == "radar" || text[1] == "solar" || text[1] == "drill")
                    {
                        string name;
                        Console.WriteLine("\nWhat is device's name?");
                        name = Console.ReadLine();
                        foreach (Device d in CreatedDevice)
                            if (d.Name == name.ToLower())
                                rover.Detach(d);
                    }
                    else Console.WriteLine("There is no possible device to attach!");
                }
            }
            else Console.WriteLine("What are you trying to do???");
        }
    }
}
