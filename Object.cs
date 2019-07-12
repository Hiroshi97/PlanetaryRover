using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public abstract class Object
    {
        private int _x, _y; //Field of location X, Y
        private string _name; //Field of name
        public Object(int x, int y, string name)
        {
            _name = name;
            _x = x;
            _y = y;
        }
        public virtual string Name
        {
            get { return _name; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}