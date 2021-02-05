using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0_OOP2
{
    public class ToyPlane : Airplane
    {
        public bool isWoundUp;

        public ToyPlane()
        {
            MaxAltitude = 50;
        }

        public override string About()
        {
            string airplaneDescription = "This" + this + " has a max altitude of " + MaxAltitude + "ft \n";
            string altitudeDescription = "It's current altitude is " + CurrentAltitude + " ft \n";

            return airplaneDescription + altitudeDescription + Engine.About();
        }

        protected string getWindUpString()
        {
            if (isWoundUp)
                return this + " is wound up!";
            else
                return this + " is not wound.";
        }

        public override void StartEngine()
        {
            if(isWoundUp)
            {
                Engine.isStarted = true;
            }
        }

        public override string TakeOff()
        {
            if(Engine.isStarted)
            {
                IsFlying = true;
                return this + " has taken off.";
            }
            else
            {
                return this + " needs to turn its engine on first!.";
            }
        }

        public void Unwind()
        {
            CurrentAltitude = 0;
            isWoundUp = false;
            IsFlying = false;
        }

        public void WindUp()
        {
            isWoundUp = true;
            getWindUpString();
        }


    }
}
