using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaschenrechnerLib.MSTest.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
        [TestMethod]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            var t = new TaschenrechnerLib.Taschenrechner();

            int erg = t.Add(5, 3);

            Assert.AreEqual(8, erg);
        }
    }
}
