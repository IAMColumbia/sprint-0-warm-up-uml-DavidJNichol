using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint0_OOP2;

namespace AerialVehicleUnitTest
{
    [TestClass]
    public class AirplaneTest
    {
        [TestMethod]
        public void AirplaneAboutCheck()
        {
            //arrange
            Airplane airplane = new Airplane();

            //act

            //assert
            Assert.AreEqual(airplane.About(), "This" + "Sprint0_OOP2.Airplane" + " has a max altitude of " + airplane.MaxAltitude + "ft \n" + "It's current altitude is " + airplane.CurrentAltitude + " ft \n" + airplane.Engine.About());
        }

        [TestMethod]
        public void AirplaneTakeoffCheck()
        {
            //arrange
            Airplane airplane = new Airplane();

            //Engine is not on.

            //assert - airplane should not be able to take off
            Assert.AreEqual(airplane.TakeOff(), "Sprint0_OOP2.Airplane Can't fly because it's engine is not started yet.\n");

            //act Engine is on.
            airplane.Engine.Start();

            //assert - airplane should take off, be flying.
            Assert.AreEqual(airplane.TakeOff(), "Sprint0_OOP2.Airplane is flying.\n");
            Assert.IsTrue(airplane.IsFlying);
        }

        [TestMethod]
        public void AirplaneFlyUpCheck()
        {
            //arrange
            Airplane airplane = new Airplane();

            //act - takeoff procedure
            airplane.Engine.Start();
            airplane.TakeOff();

            //assert - even though we have taken off, we should technically still be at 0 altitude
            Assert.AreEqual(airplane.CurrentAltitude, 0);

            //act - flyup 1000
            airplane.FlyUp();

            //assert - check for 1000 alt
            Assert.AreEqual(airplane.CurrentAltitude, 1000);

            //act - flyup 20k
            airplane.FlyUp(20000);

            //assert - check for 21k alt
            Assert.AreEqual(airplane.CurrentAltitude, 21000);
        }

        [TestMethod]
        public void AirplaneMaxAltCheck()
        {
            //arrange
            Airplane airplane = new Airplane();

            //act - takeoff procedure
            airplane.Engine.Start();
            airplane.TakeOff();

            //act - flyup 41000
            airplane.FlyUp(41000);

            //assert - check for 41000 alt - equal to max
            Assert.AreEqual(airplane.CurrentAltitude, 41000);

            //act - flyup 1000 to test going over max alt
            airplane.FlyUp(1000);

            //assert - if we did it right alt should stay at 41k
            Assert.AreEqual(airplane.CurrentAltitude, 41000);
        }

        [TestMethod]
        public void AirplaneFlyDownCheck()
        {
            //arrange
            Airplane airplane = new Airplane();

            //act - takeoff procedure
            airplane.Engine.Start();
            airplane.TakeOff();

            //act - flyup 10000 and down 5000
            airplane.FlyUp(10000);
            airplane.FlyDown(5000);

            //assert - we should be at 5000 alt
            Assert.AreEqual(airplane.CurrentAltitude, 5000);

            //act - flydown to 0
            airplane.FlyDown(5000);

            //assert - we should be at 0 alt
            Assert.AreEqual(airplane.CurrentAltitude, 0);
        }

        [TestMethod]
        public void AirplaneMinAltCheck()
        {
            //arrange
            Airplane airplane = new Airplane();

            //act - takeoff procedure
            airplane.Engine.Start();
            airplane.TakeOff();

            //act - flyup 41000, down 45000
            airplane.FlyUp(41000);
            airplane.FlyDown(45000);

            //assert - we are still at 41k
            Assert.AreEqual(airplane.CurrentAltitude, 41000);

            //act - fly to 0 then down 5k, going past 0
            airplane.FlyDown(41000);
            airplane.FlyDown(5000);

            //assert - we are at 0 right?
            Assert.AreEqual(airplane.CurrentAltitude, 0);
        }


    }
}
