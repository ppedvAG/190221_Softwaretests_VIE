using System;
using System.Collections.Generic;

namespace ppedv.Weballian.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual HashSet<Person> Actors { get; set; } = new HashSet<Person>();
    }
}
