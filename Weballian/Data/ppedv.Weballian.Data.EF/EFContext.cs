using ppedv.Weballian.Domain;
using System;
using System.Data.Entity;

namespace ppedv.Weballian.Data.EF
{
    public class EFContext : DbContext
    {
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Person> Person { get; set; }
        public DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasMany(x => x.Actors)
                                        .WithMany(x => x.Movies);
            // Many-to-Many Beziehung zwischen Movie und Person;
        }
    }
}
