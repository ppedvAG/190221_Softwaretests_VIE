using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLib
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            if (!(obj is Person))
                return false;
            if (this == obj)
                return true;

            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {   // easy-Variante
            int hashcode = 0;
            hashcode += Vorname.GetHashCode();
            hashcode += Nachname.GetHashCode();
            hashcode += Alter;
            hashcode += Convert.ToInt32(Kontostand);

            return hashcode;
        }
    }
}
