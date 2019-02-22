using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Weballian.Domain;
using ppedv.Weballian.Domain.Interfaces;

namespace ppedv.Weballian.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_generate_Movies_with_negative_amount_throws_ArgumentException()
        {
            var mock = new Mock<IDevice>();
            Core core = new Core(mock.Object,null); // repo wird nicht gebraucht

            // Was macht mein echtes Gerät, wenn die Anzahl nicht stimmt ?
            Assert.ThrowsException<ArgumentException>(() => core.GenerateMovies(-20));

            mock.Verify(x => x.ProduceMovie(), Times.Never());
        }

        [TestMethod]
        public void Core_can_generate_5_Movies()
        {
            var mock = new Mock<IDevice>();
            Core core = new Core(mock.Object,null); // repo wird nicht gebraucht

            core.GenerateMovies(5); // Wie kann ich jetzt quasi prüfen, dass die Methode .ProduceMovie() aufgerufen wurde ?

            mock.Verify(x => x.ProduceMovie(), Times.Exactly(5));
        }

        [TestMethod]
        public void Core_can_GetPeopleWithAgeGreaterThan100()
        {
            // Typische Businesslayer-Logik: Hol was aus der DB und mach was mit den Daten
            var mock = new Mock<IRepository>();

            // Setup: Wir geben die Ergebnisse vor:
            mock.Setup(x => x.GetAll<Person>())
                .Returns(() =>
                {
                    return new Person[]
                    {
                        new Person{FirstName="Tom",LastName="Ate",Age=110,Balance=100},
                        new Person{FirstName="Anna",LastName="Nass",Age=120,Balance=200},
                        new Person{FirstName="Peter",LastName="Silie",Age=130,Balance=300},
                        new Person{FirstName="Martha",LastName="Pfahl",Age=20,Balance=300},
                        new Person{FirstName="Klara",LastName="Fall",Age=67,Balance=123123300}
                    };
                });

            Core core = new Core(null,mock.Object); // device wird nicht benötigt
            var result = core.GetPeopleWithAgeGreaterThan100();

            Assert.AreEqual(3, result.Count());
        }
    }
}
