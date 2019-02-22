using System.Collections.Generic;

namespace ppedv.Weballian.Domain
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public decimal Balance { get; set; }

        public virtual HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
