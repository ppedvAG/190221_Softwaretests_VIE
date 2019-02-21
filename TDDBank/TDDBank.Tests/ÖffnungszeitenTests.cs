using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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


        [TestMethod]
        public void Öffnungszeiten_IsNowOpen()
        {
            //var ö = new Öffnungszeiten();

            //Assert.IsTrue(ö.IsNowOpen());
            //// Problem: Unittest geht jetzt (15:23), aber am Abend oder am WE nicht mehr

            using (ShimsContext.Create())
            {
                // Hier gilt "meine" 
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(1845, 3, 11, 12, 30, 59);

                // Andere Abhängigkeiten zum Spaß :)

                System.IO.Fakes.ShimFile.ExistsString = x => true;
                Assert.IsTrue(File.Exists("7:\\demo\\diedateigibtesnichASOD<aosd.<asd<sad<sad&&%&"));

                var ö = new Öffnungszeiten();
                Assert.IsTrue(ö.IsNowOpen());
            }

            // Anwendungsfälle:
            // Simulation von einem Sensor: Testcases für zu heiß, normal, kalt, keine sensordaten, Extremdaten
            // Keine echte DB-Verbindung
            // Netzwerkverbindung
            // Rest-API liefert immer den selben JSON/XML - String
            // => schnell und immer konsistente Daten
        }
    }
}
