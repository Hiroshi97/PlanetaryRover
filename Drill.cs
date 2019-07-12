using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PlanetaryRover
{
    public class Drill : Device
    {
        private int _percent;
        private Random rand = new Random(); //Call Random object
        int rdn; //Random number
        public Drill(string name) : base(name)
        {
            _percent = 0; //Initialize worn percent = 0%
        }
        public override void Operating(Rover rover)
        {
            List<Specimen> SpecimenList = rover.Area.List.ListOfSpecimen;
            string Msg = "";
            bool Chk = false;
            Console.WriteLine("Drill is {0}% worn", Percentage);
            if (rover.Area != null)
            {
                if (Percentage >= 100)
                    _percent = 100;
                if (Percentage >= 0 && Percentage <= 100)
                {
                    if (Percentage != 100)
                    {
                        foreach (Specimen spec in SpecimenList)
                        {
                            if (rover.X == spec.X && rover.Y == spec.Y)
                            {
                                Chk = true;
                                rover.Area.List.Take(spec);
                                break;
                            }
                        }
                        if (Chk)
                        {
                            _percent += 5;
                            Msg = "Extract Successfully! Drill's " + Percentage.ToString() + "% worn\n";
                        }
                        else
                        {
                            _percent += 10;
                            Msg = "Extract Failed! No specimen found! Drill's " + Percentage.ToString() + "% worn\n";
                        }
                    }
                    else
                    {
                        rdn = rand.Next(1, 5);
                        if (rdn == 1)
                            Msg = "Extract Failed!";
                        else Msg = "Extract Successfully";
                    }
                }
            }
            else Msg = "I have nowhere to extract specimens\n";
            Console.WriteLine(Msg);
        }
        public int Percentage
        {
            get
            {
                return _percent;
            }
        }
    }
}      