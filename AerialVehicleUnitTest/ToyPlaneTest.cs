using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint0_OOP2;

namespace AerialVehicleUnitTest
{
    [TestClass]
    public class ToyPlaneTest
    {
        [TestMethod]
        public void ToyPlaneWindUpCheck()
        {
            //arrange
            ToyPlane tp = new ToyPlane();

            //act - wind her up
            tp.WindUp();

            //assert - check if wound
            Assert.IsTrue(tp.isWoundUp);
        }

        [TestMethod]
        public void ToyPlaneEngineCheck()
        {
            //arrange
            ToyPlane tp = new ToyPlane();

            //act - Engine on
            tp.WindUp();
            tp.Engine.Start();

            //assert - check if engine on
            Assert.IsTrue(tp.Engine.isStarted);
        }

        [TestMethod]
        public void ToyPlaneTakeoffCheck()
        {
            //arrange
            ToyPlane tp = new ToyPlane();

            //act - Engine on
            tp.WindUp();
            tp.Engine.Start();
            tp.TakeOff();

            //assert - check if flying
            Assert.IsTrue(tp.IsFlying);           
        }

        [TestMethod]
        public void ToyPlaneFlyUpCheck()
        {
            //arrange
            ToyPlane tp = new ToyPlane();

            //act - Engine on
            tp.WindUp();
            tp.Engine.Start();
            tp.TakeOff();
            tp.FlyUp(25);

            //assert - check if fly up works
            Assert.AreEqual(tp.CurrentAltitude, 25);

            //act - fly to max
            tp.FlyUp(25);

            //assert - check for max altitude
            Assert.AreEqual(tp.CurrentAltitude, 50);

            //act - fly above max
            tp.FlyUp(25);

            //assert - check for max altitude
            Assert.AreEqual(tp.CurrentAltitude, 50);
        }

        [TestMethod]
        public void ToyPlaneDownCheck()
        {
            //arrange
            ToyPlane tp = new ToyPlane();

            //act - Engine on
            tp.WindUp();
            tp.Engine.Start();
            tp.TakeOff();
            tp.FlyUp(25);
            tp.FlyDown(5);

            //assert - check if fly down works
            Assert.AreEqual(tp.CurrentAltitude, 20);

            //act - fly to min
            tp.FlyDown(20);

            //assert - check for min altitude
            Assert.AreEqual(tp.CurrentAltitude, 0);

            //act - fly below min
            tp.FlyDown(25);

            //assert - check for min altitude
            Assert.AreEqual(tp.CurrentAltitude, 0);
        }


        [TestMethod]
        public void ToyPlaneUnwindCheck()
        {
            //arrange
            ToyPlane tp = new ToyPlane();

            //act - Engine on
            tp.WindUp();
            tp.Engine.Start();
            tp.TakeOff();
            tp.Unwind();

            //assert - check if unwound
            Assert.IsFalse(tp.isWoundUp);

            //assert - make sure we aren't flying
            Assert.IsFalse(tp.IsFlying);

            //assert - are we grounded?
            Assert.AreEqual(tp.CurrentAltitude, 0);
        }


    }
}
