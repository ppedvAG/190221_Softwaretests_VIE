using ppedv.Weballian.Domain;
using ppedv.Weballian.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Weballian.Logic
{
    public class Core
    {
        public Core(IDevice device, IRepository repository)
        {
            Device = device;
            Repository = repository;
        }
        public IDevice Device { get; set; }
        public IRepository Repository { get; set; }

        public void GenerateMovies(int amount) // Business-Logik, die ein "Gerät" verwendet
        {
            if (amount <= 0)
                throw new ArgumentException();

            for (int i = 0; i < amount; i++)
                Device.ProduceMovie();
            // Ziel: Businesslogik testen, ohne dass das "echte" Gerät genutzt wird
        }

        public IEnumerable<Person> GetPeopleWithAgeGreaterThan100()
        {
            return Repository.GetAll<Person>().Where(x => x.Age >= 100);
        }
    }
}
