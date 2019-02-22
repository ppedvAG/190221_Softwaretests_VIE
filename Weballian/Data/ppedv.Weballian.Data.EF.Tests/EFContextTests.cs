using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Weballian.Domain;

namespace ppedv.Weballian.Data.EF.Tests
{
    [TestClass]
    public class EFContextTests
    {
        //const string connectionString = @"Server=.;Database=Weballian_NOT_Production;Trusted_Connection=true";
        const string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=Weballian_NOT_Production;Trusted_Connection=true;AttachDbFilename=C:\temp\meineDB.mdf";
        #region Setup für Tests
        [ClassInitialize]
        public static void InitTests(TestContext c)
        {
            using (var context = new EFContext(connectionString))
            {
                if (!context.Database.Exists())
                    context.Database.Create();
            }
        }
        [ClassCleanup]
        public static void Teardown()
        {
            using (var context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();
            }
        }
        #endregion

        [TestMethod]
        public void EFContext_can_create_EFContext()
        {
            var context = new EFContext(connectionString);
        }

        [TestMethod]
        public void EFContext_can_create_DB()
        {
            using (var context = new EFContext(@"Server=(localDB)\MSSQLLocalDB;Database=Weballian_CreateDBTest;Trusted_Connection=true;AttachDbFilename=C:\temp\meineDB.mdf"))
            {
                if (context.Database.Exists())
                    context.Database.Delete();
                // Leerzustand

                Assert.IsFalse(context.Database.Exists());
                context.Database.Create();
                Assert.IsTrue(context.Database.Exists());

                // Teardown
                context.Database.Delete();
            }
        }

        // CRUD -> Create, Read, Update, Delete

        [TestMethod]
        public void EFContext_can_CRUD_Person()
        {
            Person p = new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100m };
            string newLastName = "Mustermann";

            // Create
            using (var context = new EFContext(connectionString))
            {
                context.Person.Add(p); // Insert
                context.SaveChanges();
            }

            using (var context = new EFContext(connectionString))
            {
                // Check Create
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNotNull(loadedPerson);
                Assert.AreEqual(p.FirstName, loadedPerson.FirstName);

                // Update
                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }

            using (var context = new EFContext(connectionString))
            {
                // Check Update
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNotNull(loadedPerson);
                Assert.AreEqual(newLastName, loadedPerson.LastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }
            using (var context = new EFContext(connectionString))
            {
                // Check Delete
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNull(loadedPerson);
            }
        }

        [TestMethod]
        public void EFContext_can_CRUD_Person_Fluent()
        {
            Person p = new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100m };
            string newLastName = "Mustermann";

            // Create
            using (var context = new EFContext(connectionString))
            {
                context.Person.Add(p); // Insert
                context.SaveChanges();
            }

            using (var context = new EFContext(connectionString))
            {
                // Check Create
                var loadedPerson = context.Person.Find(p.ID);
                loadedPerson.Should().NotBeNull();
                // loadedPerson.FirstName.Should().Be(p.FirstName);

                // Objectgraph
                loadedPerson.Should().BeEquivalentTo(p);

                // Update
                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }

            using (var context = new EFContext(connectionString))
            {
                // Check Update
                var loadedPerson = context.Person.Find(p.ID);
                loadedPerson.Should().NotBeNull();
                loadedPerson.LastName.Should().Be(newLastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }
            using (var context = new EFContext(connectionString))
            {
                // Check Delete
                var loadedPerson = context.Person.Find(p.ID);
                loadedPerson.Should().BeNull();
            }
        }
    }
}
