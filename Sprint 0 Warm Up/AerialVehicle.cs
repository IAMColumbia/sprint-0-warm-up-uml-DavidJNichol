using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0_OOP2
{
    public abstract class AerialVehicle
    {
        public int CurrentAltitude { get; set; }
        public Engine Engine { get; set; }
        public bool IsFlying { get; set; }
        public int MaxAltitude { get; set; }

        public AerialVehicle()
        {
            Engine = new Engine();
        }

        public virtual string About()
        {
            string airplaneDescription = "This" + this + " has a max altitude of " + MaxAltitude + "ft \n";
            string altitudeDescription = "It's current altitude is " + CurrentAltitude + " ft \n";
           

            return airplaneDescription + altitudeDescription + Engine.About();
        }

        public void FlyDown()
        {
            int defaultFeet = 1000;
            if (CurrentAltitude - defaultFeet >= 0)
            {
                CurrentAltitude -= defaultFeet;
                // Call plane description
                About();
            }
            else
            {
                Console.WriteLine("Parameter exceeds max altitude");
            }
        }

        public void FlyDown(int howManyFeet)
        {
            if (CurrentAltitude - howManyFeet >= 0)
            {
                CurrentAltitude -= howManyFeet;
                // Call plane description
                About();
            }
            else
            {
                Console.WriteLine("Parameter exceeds minimum altitude");
            }
        }

        public void FlyUp()
        {
            int defaultFeet = 1000;
            if (CurrentAltitude <= MaxAltitude - defaultFeet)
            {
                CurrentAltitude += defaultFeet;
                // Call plane description
                About();
            }
            else
            {
                Console.WriteLine("Parameter exceeds max altitude");
            }
        }

        public void FlyUp(int howManyFeet)
        {                       
            if (CurrentAltitude <= MaxAltitude - howManyFeet)
            {
                CurrentAltitude += howManyFeet;
                // Call plane description
                About();
            }
            else
            {
                Console.WriteLine("Parameter exceeds max altitude");
            }         
        }

        protected string GetEngineStartedString()
        {
            return this + " has started its engine.\n";
        }

        public virtual void StartEngine()
        {
            if(Engine.isStarted)
            {
                Console.WriteLine(this + "'s engine is already started.\n");
            }
            else
            {
                Console.WriteLine(GetEngineStartedString());
                Engine.Start();
            }
        }

        public void StopEngine()
        {
            if (Engine.isStarted)
            {
                Console.WriteLine(this + " has stopped its engine.\n");
                Engine.Stop();
            }
            else
            {
                Console.WriteLine(this + " 's engine is not on yet.\n");
            }
        }

        public virtual string TakeOff()
        {

            if (Engine.isStarted)
            {
                IsFlying = true;
                return this + " is flying.\n";
            }
            else
            {
                IsFlying = false;
                return this + " Can't fly because it's engine is not started yet.\n";
            }
        }



    }
}
