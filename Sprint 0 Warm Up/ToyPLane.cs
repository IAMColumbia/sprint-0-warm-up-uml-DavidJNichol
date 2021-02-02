using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0_OOP2
{
    class ToyPlane : Airplane
    {
        protected bool isWoundUp;

        public ToyPlane()
        {
            MaxAltitude = 50;
        }

        public override string About()
        {
            string airplaneDescription = "This" + this + " has a max altitude of " + MaxAltitude + "ft \n";
            string altitudeDescription = "It's current altitude is " + CurrentAltitude + " ft \n";
            string engineDescription;

            if (Engine.isStarted)
            {
                engineDescription = nameof(Engine) + " is started\n";
            }
            else
            {
                engineDescription = nameof(Engine) + " is not started\n";
            }

            return airplaneDescription + altitudeDescription + engineDescription;
        }

        protected string getWindUpString()
        {
            return this + " is wound up!";
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
            CurrentAltitude = MaxAltitude;
            return this + " has taken off.";
        }

        public void Unwind()
        {
            isWoundUp = false;
        }

        public void WindUp()
        {
            isWoundUp = true;
            getWindUpString();
        }


    }
}
