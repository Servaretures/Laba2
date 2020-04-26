using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] Ar = { 2, 4, -1, -6 };
            float sum = 0;
            double res = Laba2.Program.Taks3_Function(Ar,out sum);
            Assert.AreEqual(res,8);
            Assert.AreEqual(sum, 2);
        }
    }
}
