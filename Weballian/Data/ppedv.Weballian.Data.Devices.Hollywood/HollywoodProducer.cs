using ACME.Filmgenerator3000;
using System;

namespace ppedv.Weballian.Data.Devices.Hollywood
{
    public class HollywoodProducer
    {
        public static void ProduceMovie()
        {
            // "Treiber", der intern die Maschine ansteuert
            Filmgenerator.GenerateMovie();
        }
    }
}
