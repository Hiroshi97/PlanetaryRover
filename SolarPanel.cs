using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class SolarPanel : Device
    {
        public SolarPanel(string name) : base(name)
        {
        }
        public override void Operating(Rover rover)
        {
            Battery.Increment();
        }
    }
}