using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryRover
{
    public class Motor : Device
    {
        private string _type;
        public Motor(string name, string type) : base(name)
        {
            _type = type.ToLower();
        }
        public override void Operating(Rover rover)
        {
            if (rover.Area != null)
            {
                Battery.Decreasement(); //Decrease unit of battery while operating
                switch (Type)
                {
                    case "up":
                        rover.X--;
                        break;
                    case "down":
                        rover.X++;
                        break;
                    case "left":
                        rover.Y--;
                        break;
                    case "right":
                        rover.Y++;
                        break;
                    default:
                        Console.WriteLine("What is this type?");
                        break;
                }
                if (rover.X < 0)
                    rover.X = 0;
                if (rover.Y < 0)
                    rover.Y = 0;
                if (rover.X > 20)
                    rover.X = 20;
                if (rover.Y > 20)
                    rover.Y = 20;
            }
            else Console.WriteLine("I have nowhere to move");
        }
        public string Type
        {
            get { return _type; }
        }
    }
}
