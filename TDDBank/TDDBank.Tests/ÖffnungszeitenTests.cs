using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank.Tests
{
    [TestClass]
    public class ÖffnungszeitenTests
    {
        [TestMethod]
        [DataRow(2019,2,18,12,31,true)] //Mo - True
        [DataRow(2019,2,20,18,00,true)] //Mi - True
        [DataRow(2019,2,22,10,21,false)] //Fr - False
        [DataRow(2019,2,23,12,31,true)] //Sa - True
        [DataRow(2019,2,23,14,5,false)] //Sa - False
        // Extremfälle
        [DataRow(2019, 2, 20, 10, 30, true)] //Mi - True
        [DataRow(2019, 2, 20, 19, 00, false)]//Mi - False
        [DataRow(2019, 2, 23, 10, 30, true)] //Sa - True
        [DataRow(2019, 2, 23, 14, 00, false)] //Sa - False
        public void Öffnungszeiten_IsOpen(int jahr,int monat,int tag, int stunde, int minute, bool erwartetesResultat)
        {
            var d = new DateTime(jahr, monat, tag, stunde, minute, 0);
            var ö = new Öffnungszeiten();

            Assert.AreEqual(erwartetesResultat, ö.IsOpen(d));
        }
    }
}
