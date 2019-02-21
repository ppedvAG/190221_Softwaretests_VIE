using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaschenrechnerLib.MSTest.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
        // Normalfall
        [TestMethod]
        [TestCategory("MSTest")]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            // Arrange
            var t = new TaschenrechnerLib.Taschenrechner();
            // Act
            int erg = t.Add(5, 3);
            // Assert
            Assert.AreEqual(8, erg);
        }

        // Extremfälle

        // Max
        [TestMethod]
        [TestCategory("MSTest")]
        public void Taschenrechner_Add_Int32MaxValue_and_1_throws_OverflowException()
        {
            // Arrange
            var t = new TaschenrechnerLib.Taschenrechner();
            // Act und Assert
            Assert.ThrowsException<OverflowException>(() => t.Add(Int32.MaxValue, 1));
        }
        // Min
        [TestMethod]
        [TestCategory("MSTest")]
        public void Taschenrechner_Add_Int32MinValue_and_NEG1_throws_OverflowException()
        {
            // Arrange
            var t = new TaschenrechnerLib.Taschenrechner();
            // Act und Assert
            Assert.ThrowsException<OverflowException>(() => t.Add(Int32.MinValue, -1));
        }

        // Null
        [TestMethod]
        [TestCategory("MSTest")]
        public void Taschenrechner_Add_0_and_0_results_0()
        {
            // Arrange
            var t = new TaschenrechnerLib.Taschenrechner();
            // Act
            int erg = t.Add(0, 0);
            // Assert
            Assert.AreEqual(0, erg); // float wäre da bestimmt interessant ( 0.1 + 0.2 )
        }

        // Mehrere Testfälle zusammenfassen
        [TestMethod]
        [TestCategory("MSTest")]
        [DataRow(3,5,8)]
        [DataRow(0,0,0)]
        [DataRow(123,-20,103)]
        public void Taschenrechner_Add(int z1, int z2, int expected)
        {
            var t = new Taschenrechner();
            var erg = t.Add(z1, z2);
            Assert.AreEqual(expected, erg);
        }
    }
}
