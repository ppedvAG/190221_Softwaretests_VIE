using ppedv.Weballian.Domain.Interfaces;
using System;

namespace ppedv.Weballian.Logic
{
    public class Core
    {
        public Core(IDevice device)
        {
            Device = device;
        }
        public IDevice Device { get; set; }

        public void GenerateMovies(int amount) // Business-Logik, die ein "Gerät" verwendet
        {
            if (amount <= 0)
                throw new ArgumentException();

            for (int i = 0; i < amount; i++)
                Device.ProduceMovie();
            // Ziel: Businesslogik testen, ohne dass das "echte" Gerät genutzt wird
        }
    }
}
