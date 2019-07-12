using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Battery
    {
        private int _unit;
        private string _name;
        public Battery(string name)
        {
            _name = name;
            _unit = 100;
        }
        public int Unit
        {
            get { return _unit; }
        }
        public void Increment()
        {
            if (Unit >= 0 && Unit < 100)
                _unit++;
        }
        public void Decreasement()
        {
            if (Unit > 0)
                _unit--;
        }
        public string Name
        {
            get { return _name.ToLower(); }
        }
        public string CurrentCharge
        {
            get { return _unit.ToString() + "%"; }
        }
    }
}
