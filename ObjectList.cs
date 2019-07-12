using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class ObjectList
    {
        private List<Object> _objects;
        public ObjectList()
        {
            _objects = new List<Object>();
        }
        public void Put(Object obj)
        {
            _objects.Add(obj);
        }
        public Object Take(Object obj)
        {
            Object ThingToTake = null;
            foreach (Object objs in _objects)
            {
                if (objs.Name == obj.Name)
                {
                    ThingToTake = objs;
                }
            }
            _objects.Remove(ThingToTake);
            return ThingToTake;
        }
        public Object Fetch(Object objs)
        {
            foreach (Object obj in _objects)
            {
                if (obj.Name == objs.Name)
                    return obj;
            }
            return null;
        }
        public List<Specimen> ListOfSpecimen
        {
            get
            {
                List<Specimen> result = new List<Specimen>();
                foreach (Specimen spec in _objects)
                    result.Add(spec);
                return result;
            }
        }
    }
}

