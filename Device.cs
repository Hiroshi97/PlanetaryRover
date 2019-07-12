using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public abstract class Device
    {
        private string _name;
        private Battery _batteries;
        public Device(string name)
        {
            _name = name.ToLower();
        }
        public string Name
        {
            get { return _name; }
        }
        public Battery Battery
        {
            get { return _batteries; }
            set { _batteries = value; }
        }
        public abstract void Operating(Rover rover);
    }
}
