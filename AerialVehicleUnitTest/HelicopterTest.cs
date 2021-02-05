using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint0_OOP2;

namespace AerialVehicleUnitTest
{
    [TestClass]
    public class HelicopterTest
    {
        public void HelicopterTakeoffCheck()
        {
            //arrange
            Helicopter helicopter = new Helicopter();

            //Engine is not on.

            //assert - airplane should not be able to take off
            Assert.AreEqual(helicopter.TakeOff(), $"{helicopter} Can't fly because it's engine is not started yet.\n");

            //act Engine is on.
            helicopter.Engine.Start();

            //assert - airplane should take off, be flying.
            Assert.AreEqual(helicopter.TakeOff(), $"{helicopter} is flying.\n");
            Assert.IsTrue(helicopter.IsFlying);
        }

        [TestMethod]
        public void HelicopterFlyUpCheck()
        {
            //arrange
            Helicopter helicopter = new Helicopter();

            //act - takeoff procedure
            helicopter.Engine.Start();
            helicopter.TakeOff();

            //assert - even though we have taken off, we should technically still be at 0 altitude
            Assert.AreEqual(helicopter.CurrentAltitude, 0);

            //act - flyup 1000
            helicopter.FlyUp();

            //assert - check for 1000 alt
            Assert.AreEqual(helicopter.CurrentAltitude, 1000);

            //act - flyup 2k
            helicopter.FlyUp(2000);

            //assert - check for 3k alt
            Assert.AreEqual(helicopter.CurrentAltitude, 3000);
        }

        [TestMethod]
        public void HelicopterMaxAltCheck()
        {
            //arrange
            Helicopter helicopter = new Helicopter();

            //act - takeoff procedure
            helicopter.Engine.Start();
            helicopter.TakeOff();

            //act - flyup 8000, max alt
            helicopter.FlyUp(8000);

            //assert - check for 8000 alt - equal to max
            Assert.AreEqual(helicopter.CurrentAltitude, 8000);

            //act - flyup 1000 to test going over max alt
            helicopter.FlyUp(1000);

            //assert - if we did it right alt should stay at 41k
            Assert.AreEqual(helicopter.CurrentAltitude, 8000);
        }

        [TestMethod]
        public void HelicopterFlyDownCheck()
        {
            //arrange
            Helicopter helicopter = new Helicopter();

            //act - takeoff procedure
            helicopter.Engine.Start();
            helicopter.TakeOff();

            //act - flyup 6000 and down 5000
            helicopter.FlyUp(6000);
            helicopter.FlyDown(5000);

            //assert - we should be at 1000 alt
            Assert.AreEqual(helicopter.CurrentAltitude, 1000);

            //act - flydown to 0
            helicopter.FlyDown();

            //assert - we should be at 0 alt
            Assert.AreEqual(helicopter.CurrentAltitude, 0);
        }

        [TestMethod]
        public void HelicopterMinAltCheck()
        {
            //arrange
            Helicopter helicopter = new Helicopter();

            //act - takeoff procedure
            helicopter.Engine.Start();
            helicopter.TakeOff();

            //act - flyup 5000, down 10000
            helicopter.FlyUp(5000);
            helicopter.FlyDown(10000);

            //assert - we are still at 5k
            Assert.AreEqual(helicopter.CurrentAltitude, 5000);

            //act - fly to 0 then down 5k, going past 0
            helicopter.FlyDown(5000);
            helicopter.FlyDown(5000);

            //assert - we are at 0 right?
            Assert.AreEqual(helicopter.CurrentAltitude, 0);
        }

    }
}
