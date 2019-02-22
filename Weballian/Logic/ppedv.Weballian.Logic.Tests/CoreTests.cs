using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.Weballian.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_generate_Movies_with_negative_amount_throws_ArgumentException()
        {
            // Was passiert, wenn ich das Gerät nicht habe ?
            Core core = new Core(null); // ich brauche ein "gerät" zum testen D: -> Moq

            // Was macht mein echtes Gerät, wenn die Anzahl nicht stimmt ?
            Assert.ThrowsException<ArgumentException>(() => core.GenerateMovies(-20));
        }
    }
}
