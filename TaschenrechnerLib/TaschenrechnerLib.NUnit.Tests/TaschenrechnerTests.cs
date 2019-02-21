using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLib.NUnit.Tests
{
    [TestFixture]
    public class TaschenrechnerTests
    {
        [Test]
        [Category("NUnit")]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            // Arrange
            var t = new TaschenrechnerLib.Taschenrechner();
            // Act
            int erg = t.Add(5, 3);
            // Assert
            Assert.AreEqual(8, erg);
        }

        [Test]
        [Category("NUnit")]
        [TestCase(3, 5, 8)]
        [TestCase(0, 0, 0)]
        [TestCase(123, -20, 103)]
        public void Taschenrechner_Add(int z1, int z2, int expected)
        {
            var t = new Taschenrechner();
            var erg = t.Add(z1, z2);
            Assert.AreEqual(expected, erg);
        }
    }
}
