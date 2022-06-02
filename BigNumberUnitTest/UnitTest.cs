using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigNumberUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodOverFlow()
        {
            var a = new BigNumber.BigNumber("5");
            var b = new BigNumber.BigNumber("5");

            Assert.AreEqual(true, (a + b).ToString() == "10");
        }

        [TestMethod]
        public void TestMethodZeroAtStart()
        {
            var a = new BigNumber.BigNumber("000000000000000000000000000000000000000000000000005");
            var b = new BigNumber.BigNumber("00005");

            Assert.AreEqual(true, (a + b).ToString() == "10");
        }


        [TestMethod]
        public void TestMethodMultiply()
        {
            var a = new BigNumber.BigNumber("000000000000000000000000000000000000000000000000005");
            var b = new BigNumber.BigNumber("00005");

            Assert.AreEqual(true, (a * b).ToString() == "25");
        }


        [TestMethod]
        public void TestMethodRemoveZeroAtStart()
        {
            var a = new BigNumber.BigNumber("00000000000000000000000000000000000000000000000000");

            Assert.AreEqual(true, (a).ToString() == "0");
        }

    }
}
