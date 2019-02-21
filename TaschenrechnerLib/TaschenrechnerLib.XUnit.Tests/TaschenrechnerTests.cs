using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaschenrechnerLib.XUnit.Tests
{
    public class TaschenrechnerTests
    {
        [Fact]
        [Trait("XUnit","")]
        public void Taschenrechner_Add_5_and_3_results_8()
        {
            // Arrange
            var t = new TaschenrechnerLib.Taschenrechner();
            // Act
            int erg = t.Add(5, 3);
            // Assert
            Assert.Equal(8, erg);
        }

        [Theory] // Anstelle von Fact
        [Trait("XUnit","")]
        [InlineData(3, 5, 8)]
        [InlineData(0, 0, 0)]
        [InlineData(123, -20, 103)]
        public void Taschenrechner_Add(int z1, int z2, int expected)
        {
            var t = new Taschenrechner();
            var erg = t.Add(z1, z2);
            Assert.Equal(expected, erg);
        }
    }
}
