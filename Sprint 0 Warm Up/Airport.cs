using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0_OOP2
{
    class Airport
    {
        protected int maxVehicles;
        private List<AerialVehicle> vehicles;

        public string airportCode { get; set; }

        public Airport(string Code)
        {
            this.airportCode = Code;
        }

        public Airport(string Code, int maxVehicles)
        {
            this.maxVehicles = maxVehicles;
            this.airportCode = Code;
        }

        private string AllTakeOff()
        {
            foreach (AerialVehicle a in vehicles)
            {
                a.TakeOff();
            }
            return "All vehicles have taken off.";
        }

        private string Land(AerialVehicle a)
        {
            if(vehicles.Count < maxVehicles)
            {
                a.CurrentAltitude = 0;
                a.IsFlying = false;
                return $"{a} has landed.";
            }
            else
            {
                return $"{a} cannot land because the airport is full!";
            }
        }

        private string Land(List<AerialVehicle> landing)
        {
            if(landing.Count < maxVehicles)
            {
                foreach(AerialVehicle a in landing)
                {
                    a.CurrentAltitude = 0;
                    a.IsFlying = false;                    
                }
                return "All vehicles have landed.";
            }
            else
            {
                return "These vehicles cannot land because the airport is full!";
            }
        }

        private string TakeOff(AerialVehicle a)
        {
            a.TakeOff();
            return $"{a} has taken off.";
        }
    }
}
