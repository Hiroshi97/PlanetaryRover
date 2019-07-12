using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Radar : Device
    {
        private string _type;
        public Radar(string name, string type) : base(name)
        {
            _type = type.ToLower();
        }
        public override void Operating(Rover rover)
        {
            int i, j; //counter loop
            string Msg = ""; //message
            List<Specimen> SpecimenList = rover.Area.List.ListOfSpecimen;
            List<Specimen> tempList = new List<Specimen>(); //a temporary list of specimens
            if (rover.Area != null)
            {
                for (i = 0; i < 4; i++)
                    Battery.Decreasement();
                for (i = rover.X - 5; i <= rover.X + 5; i++)
                {
                    if (i > 20) //check if rover go outside
                        break;
                    if (i < 0)
                    {
                        i = 0;
                        continue;
                    }
                    for (j = rover.Y - 5; j <= rover.Y + 5; j++)
                    {
                        if (j > 20) //check if rover go outside
                            break;
                        if (j < 0)
                        {
                            j = 0;
                            continue;
                        }
                        if (SpecimenList == null)
                        {
                            break;
                        }
                        else
                        {
                            foreach (Specimen spec in SpecimenList)
                            {
                                if (spec.X == i && spec.Y == j)
                                    tempList.Add(spec);
                            }
                        }
                    }
                }
                switch (Type.ToLower())
                {
                    case "location":
                        {
                            i = 1; //counter loop & ordering number
                            if (tempList.Count != 0)
                            {
                                foreach (Specimen spec in tempList)
                                {
                                    Msg = Msg + "Location of Found Specimen " + i + ": " + spec.X.ToString() + ", " + spec.Y.ToString() + "\n";
                                    i++;
                                }
                            }
                            else Msg = "--> There is no specimen around there";
                        }
                        break;
                    case "size":
                        {
                            if (tempList.Count != 0)
                            {
                                foreach (Specimen spec in tempList)
                                {
                                    Msg = Msg + "Size of Found Specimen " + i + ": " + spec.Size.ToString() + "\n";
                                    i++;
                                }
                            }
                            else Msg = "--> There is no specimen around there";
                        }
                        break;
                    case "name":
                        {
                            if (tempList.Count != 0)
                            {
                                foreach (Specimen spec in tempList)
                                {
                                    Msg = Msg + "Name of Found Specimen " + i + ": " + spec.Name + "\n";
                                    i++;
                                }
                            }
                            else Msg = "--> There is no specimen around there";
                        }
                        break;
                }
                Console.WriteLine(Msg);
            }
            else Console.WriteLine("Where can I scan?");
        }
        public string Type
        {
            get { return _type; }
        }
    }
}