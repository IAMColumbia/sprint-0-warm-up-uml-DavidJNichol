using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint0_OOP2;


namespace AerialVehicleUnitTest
{
    [TestClass]
    public class DroneTest
    {
        public void DroneTakeoffCheck()
        {
            //arrange
            Drone drone = new Drone();

            //Engine is not on.

            //assert - airplane should not be able to take off
            Assert.AreEqual(drone.TakeOff(), $"{drone} Can't fly because it's engine is not started yet.\n");

            //act Engine is on.
            drone.Engine.Start();

            //assert - airplane should take off, be flying.
            Assert.AreEqual(drone.TakeOff(), $"{drone} is flying.\n");
            Assert.IsTrue(drone.IsFlying);
        }

        [TestMethod]
        public void DroneFlyUpCheck()
        {
            //arrange
            Drone drone = new Drone();

            //act - takeoff procedure
            drone.Engine.Start();
            drone.TakeOff();

            //assert - even though we have taken off, we should technically still be at 0 altitude
            Assert.AreEqual(drone.CurrentAltitude, 0);

            //act - flyup 100
            drone.FlyUp(100);

            //assert - check for 100 alt
            Assert.AreEqual(drone.CurrentAltitude, 100);

            //act - flyup 300
            drone.FlyUp(300);

            //assert - check for 400 alt
            Assert.AreEqual(drone.CurrentAltitude, 400);
        }

        [TestMethod]
        public void DroneMaxAltCheck()
        {
            //arrange
            Drone drone = new Drone();

            //act - takeoff procedure
            drone.Engine.Start();
            drone.TakeOff();

            //act - flyup 500, max alt
            drone.FlyUp(500);

            //assert - check for 500 alt - equal to max
            Assert.AreEqual(drone.CurrentAltitude, 500);

            //act - flyup 1000 to test going over max alt
            drone.FlyUp();

            //assert - if we did it right alt should stay at 500
            Assert.AreEqual(drone.CurrentAltitude, 500);
        }

        [TestMethod]
        public void DroneFlyDownCheck()
        {
            //arrange
            Drone drone = new Drone();

            //act - takeoff procedure
            drone.Engine.Start();
            drone.TakeOff();

            //act - flyup 150 and down 50
            drone.FlyUp(150);
            drone.FlyDown(50);

            //assert - we should be at 100 alt
            Assert.AreEqual(drone.CurrentAltitude, 100);

            //act - flydown to 0
            drone.FlyDown(100);

            //assert - we should be at 0 alt
            Assert.AreEqual(drone.CurrentAltitude, 0);
        }

        [TestMethod]
        public void DroneMinAltCheck()
        {
            //arrange
            Drone drone = new Drone();

            //act - takeoff procedure
            drone.Engine.Start();
            drone.TakeOff();

            //act - flyup 500, down 1000
            drone.FlyUp(500);
            drone.FlyDown(1000);

            //assert - we are still at 500
            Assert.AreEqual(drone.CurrentAltitude, 500);

            //act - fly to 0 then down 5k, going past 0
            drone.FlyDown(500);
            drone.FlyDown(5000);

            //assert - we are at 0 right?
            Assert.AreEqual(drone.CurrentAltitude, 0);
        }
    }
}
