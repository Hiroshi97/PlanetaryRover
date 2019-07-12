using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace PlanetaryRover
{
    public class Area : Object
    {
        private int _width, _height;
        private ObjectList _list;
        public Area(string name) : base(0, 0, name)
        {
            _width = 20;
            _height = 20;
             _list = new ObjectList();
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }
        public ObjectList List
        {
            get { return _list; }
        }
        public void Detail()
        {
            Console.WriteLine("You're located in " + Name + "\nArea: {0}x{1}", Width, Height);
        }
    }
}
 