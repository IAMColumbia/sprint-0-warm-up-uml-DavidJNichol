using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprint0_OOP2;

namespace AerialVehicleUnitTest
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void EngineStartCheck()
        {
            //arrange
            Engine engine = new Engine();

            //assert - engine should not be on
            Assert.AreEqual(engine.About(), $"{engine} is not started\n");

            //act - turn that beauty on
            engine.Start();

            //assert - engine better be on by now
            Assert.IsTrue(engine.isStarted);

            //assert - let's check the about
            Assert.AreEqual(engine.About(), $"{engine} is started\n");
        }

        [TestMethod]
        public void EngineStopCheck()
        {
            //arrange
            Engine engine = new Engine();

            //act - turn that beauty on
            engine.Start();

            //assert - engine better be on by now
            Assert.IsTrue(engine.isStarted);

            //act - goodnight sweet prince :)
            engine.Stop();

            //assert - engine is now off
            Assert.IsFalse(engine.isStarted);

            //assert - let's check the about
            Assert.AreEqual(engine.About(), $"{engine} is not started\n");

        }
    }
}
