using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigNumberUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodOverFlow()
        {
            BigNumber.BigNumber a = "5";
            BigNumber.BigNumber b = "5";

            Assert.AreEqual(true, (a + b).ToString() == "10");
        }

        [TestMethod]
        public void TestMethodZeroAtStart()
        {
            BigNumber.BigNumber a = "000000000000000000000000000000000000000000000000005";
            BigNumber.BigNumber b = "00005";

            Assert.AreEqual(true, (a + b).ToString() == "10");
        }


        [TestMethod]
        public void TestMethodMultiply()
        {
            BigNumber.BigNumber a = "000000000000000000000000000000000000000000000000005";
            BigNumber.BigNumber b = "00005";

            Assert.AreEqual(true, (a * b).ToString() == "25");
        }


        [TestMethod]
        public void TestMethodRemoveZeroAtStart()
        {
            BigNumber.BigNumber a = "00000000000000000000000000000000000000000000000000";

            Assert.AreEqual(true, (a).ToString() == "0");
        }

    }
}
