using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Specimen : Object
    {
        private int _size;
        public Specimen(int x, int y, string name, int size) : base(x, y, name)
        {
            _size = size;
        }
        public int Size
        {
            get { return _size; }
        }
    }
}
