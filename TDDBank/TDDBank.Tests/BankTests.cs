using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDBank.Tests
{
    [TestClass]
    public class BankTests
    {
        /* Anforderungen:
         * Betrag abheben(nicht negativ, nicht unter 0)
         */

        [TestMethod]
        public void Bankkonto_new_account_has_zero_balance()
        {
            var konto = new Bankkonto();
            Assert.AreEqual(0, konto.Kontostand);
        }

        [TestMethod]
        public void Bankkonto_can_deposit()
        {
            var konto = new Bankkonto();
            konto.Einzahlen(5m);
            Assert.AreEqual(5m, konto.Kontostand);

            konto.Einzahlen(3m);
            Assert.AreEqual(8m, konto.Kontostand);
        }

        // "Was ist jetzt aber, wenn der Kunde 0 einzahlt ?"
        // "Was ist, wenn der Kunde -2 einzahlt ?"
        // => Hier in der "Planungsphase" kann man schon über Extremfälle nachdenken, bevor überhaupt die Klasse Bankkonto implementiert wird

        [TestMethod]
        public void Bankkonto_deposit_negative_value_throws_ArgumentException()
        {
            var konto = new Bankkonto();
            Assert.ThrowsException<ArgumentException>(() => konto.Einzahlen(-2m));
        }

        [TestMethod]
        public void Bankkonto_can_withdraw()
        {
            var konto = new Bankkonto();
            konto.Einzahlen(10m);

            konto.Abheben(2m);
            Assert.AreEqual(8m, konto.Kontostand);
            konto.Abheben(5m);
            Assert.AreEqual(3m, konto.Kontostand);
        }

        [TestMethod]
        public void Bankkonto_withdraw_negative_value_throws_ArgumentException()
        {
            var konto = new Bankkonto();
            konto.Einzahlen(10m);

            Assert.ThrowsException<ArgumentException>(() => konto.Abheben(-2m));
        }

        [TestMethod]
        public void Bankkonto_withdraw_over_balance_throws_ArgumentException()
        {
            var konto = new Bankkonto();
            konto.Einzahlen(5m);

            Assert.ThrowsException<ArgumentException>(() => konto.Abheben(10m));
        }

        // Zustand ist sozusagen "eincheckbar" -> Jetzt fehlt nur noch die Implementierung (LiveUnitTesting)

        [TestMethod]
        public void Bankkonto_FakeTest_Kontostand_Returns_5_000_000()
        {
            using (ShimsContext.Create())
            {
                TDDBank.Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 5_000_000m;

                var konto = new Bankkonto(); // müsste ja 0 sein beim erstellen
                Assert.AreEqual(5_000_000m, konto.Kontostand); // Fake sagt: 5_000_000
            }
        }

        [TestMethod]
        public void Bankkonto_Wohlstand()
        {
            using (ShimsContext.Create())
            {
                var konto = new Fakes.StubBankkonto();
                Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 0;

                Assert.AreEqual(Reichtum.Nichts, konto.Wohlstand);

                Fakes.ShimBankkonto.AllInstances.KontostandGet = x => 5000;
                Assert.AreEqual(Reichtum.Reich, konto.Wohlstand);
            }
            // Code Coverage: Rechtsklick auf Test -> AnalyzeCodeCoverage
        }
    }
}
