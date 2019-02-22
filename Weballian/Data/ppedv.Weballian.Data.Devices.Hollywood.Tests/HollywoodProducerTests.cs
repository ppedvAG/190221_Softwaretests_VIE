using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.Weballian.Data.Devices.Hollywood.Tests
{
    [TestClass]
    public class HollywoodProducerTests
    {
        [TestMethod]
        public void HollywoodProducer_can_produce_movie()
        {
            HollywoodProducer.ProduceMovie();
            // Problem: die echte Maschine "bewegt" sich beim testen des Treibers
            // Wir müssen den Treiber so testen, dass keine echte Hardware auf Unittests reagiert

            // Lösung: Gerät simulieren -> Mock
        }
    }
}
