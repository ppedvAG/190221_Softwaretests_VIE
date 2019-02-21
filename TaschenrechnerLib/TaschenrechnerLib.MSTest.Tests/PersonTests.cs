using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLib.MSTest.Tests
{
    [TestClass]
    public class PersonTests
    {
        // Übung:
        // False wenn:
        //       Unterschiedliche Datentypen
        //       Null
        // True wenn:
        //       Referenzen gleich
        //       Datentyp gleich und Werte gleich (easy: Vorname == obj.Vorname)

        // Null
        [TestMethod]
        public void Person_Equals_Compare_Instance_To_NULL_Throws_ArgumentNullException()
        {
            Person p = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            Assert.ThrowsException<ArgumentNullException>(() => p.Equals(null));
        }

        [TestMethod]
        [DataRow(42)]
        [DataRow("Hallo Welt")]
        [DataRow(12345.7899)]
        public void Person_Equals_Compare_Instance_To_Wrong_Type_Returns_False(object wrongType)
        {
            Person p = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            Assert.IsFalse(p.Equals(wrongType));
        }

        [TestMethod]
        public void Person_Equals_Compare_Instance_To_Same_Reference_Returns_True()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = p1; // Referenzkopie

            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void Person_Equals_Compare_Instance_To_Object_With_Same_Values_Returns_True()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            Person p2 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };

            Assert.IsTrue(p1.Equals(p2));
        }
    }
}
