using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigNumberUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new BigNumber.BigNumber("5");
            var b = new BigNumber.BigNumber("5");

            Assert.AreEqual(true, (a + b).ToString() == "10");
        }
    }
}
