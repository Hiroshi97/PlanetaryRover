using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Rover : Object
    {
        private List<Device> _rovers; //List of Devices that Rover has
        private List<Battery> _batteries; //List of Battery that Rover has
        private Area _area = null;
        public Rover(int x, int y, string name) : base(x, y, name)
        {
            _rovers = new List<Device>();
            _batteries = new List<Battery>();
        }
        public bool IsAttached(string name) //Check if device is attached or not
        {
            foreach (Device device in _rovers)
            {
                if (device.Name == name)
                    return true;
            }
            return false;
        }
        public void Attach(Device device)
        {
            _rovers.Add(device);
            int tempUnit = 0;
            foreach (Battery battery in _batteries)
            {
                if (battery.Unit > tempUnit) //find the greatest charge
                {
                    tempUnit = battery.Unit;
                    device.Battery = battery;
                }
            }
        }
        public void Detach(Device device) //Detach devices
        {
            _rovers.Remove(device);
        }
        public void ChangeBattery(Device device, string name) //Change Battery for devices
        {
            string Message = "";
            foreach (Battery battery in _batteries)
            {
                if (device.Battery.Name == name)
                {
                    Message = "You've already connected with this battery!";
                    break;
                }
                else if (device.Battery.Name != battery.Name && HasBattery(name.ToLower()) && name.ToLower() == battery.Name)
                {
                    device.Battery = battery;
                    Message = "Successful!";
                    break;
                }
                else
                    Message = "Rover doesn't have this battery...";
            }
            Console.WriteLine(Message);
        }
        public bool HasBattery(string name) //Check if Rover has a specific battery
        {
            foreach (Battery battery in _batteries)
            {
                if (battery.Name == name.ToLower())
                    return true;
            }
            return false;
        }
        public void TotalOfBatteries(int n) //Total of Battery when creating a Rover
        {
            int i; // counter loop
            for (i = 1; i <= n; i++)
            {
                Battery battery = new Battery("Battery " + i.ToString());
                _batteries.Add(battery);
            }
        }
        public string ListOfBatteries //List of current batteries in a Rover
        {
            get
            {
                string temp = null; //initialize null string
                foreach (Battery battery in _batteries)
                {
                    temp = temp + battery.Name + ":" + battery.CurrentCharge + "\n"; //return a list of battery with their charge
                }
                if (temp == null)
                    return null;
                else return temp;
            }
        }
        public void Perform(Device device)
        {
            if (IsAttached(device.Name) && device.Battery.Unit > 0)
                device.Operating(this);
            else if (device.Battery.Unit <= 0)
                Console.WriteLine("Battery is 0%. Can't perform!");
            else Console.WriteLine("This device: " + device.Name + " is not attached or is detached!\n");
        }
        public Area Area
        {
            get { return _area; }
            set { _area = value; }
        }
        public List<Device> DeviceList
        {
            get { return _rovers; }
        }
        public void Information()
        {
            string info = "";
            Console.WriteLine("INFORMATION:\n" + "Name: " + this.Name + "\n" + "This rover has: \n" + this.ListOfBatteries);
            foreach (Device dev in _rovers)
                info = info + " " + dev.GetType().Name.ToString() + ": " + dev.Name + " (" + dev.Battery.Name + ")" + "\n";
            Console.WriteLine("ATTACHED DEVICES: \n" + info);
        }
        public void Location()
        {
            Area.Detail();
            Console.WriteLine("Current Location: {0}, {1}\n", X, Y);
        }
    }
}
