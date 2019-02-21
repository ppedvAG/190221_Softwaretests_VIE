using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public class Bankkonto
    {
        public decimal Kontostand { get; set; }

        public void Einzahlen(decimal v)
        {
            if (v <= 0)
                throw new ArgumentException();
            this.Kontostand += v;
        }

        public void Abheben(decimal v)
        {
            if (v <= 0 || v > this.Kontostand)
                throw new ArgumentException();
           this.Kontostand -= v;
        }
    }
}
