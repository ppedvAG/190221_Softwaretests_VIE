using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLib
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public override bool Equals(object obj)
        {
            // Übung:
            // False wenn:
            //       Unterschiedliche Datentypen
            //       Null
            // True wenn:
            //       Referenzen gleich
            //       Datentyp gleich und Werte gleich (easy: Vorname == obj.Vorname)

            throw new NotImplementedException();
        }
    }
}
