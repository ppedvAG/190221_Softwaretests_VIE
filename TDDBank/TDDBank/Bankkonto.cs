using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public enum Reichtum { Nichts, Arm, Ok, Reich, Megareich }
    public class Bankkonto
    {
        public decimal Kontostand { get; private set; } // kleiner Bug ;)
        public Reichtum Wohlstand
        {
            get
            {
                switch (Kontostand)
                {
                    case 0:
                        return Reichtum.Nichts;
                    case decimal k when k < 100:
                        return Reichtum.Arm;
                    case decimal k when k < 1000:
                        return Reichtum.Ok;
                    case decimal k when k < 10000:
                        return Reichtum.Reich;
                    default: // > 10_000
                        return Reichtum.Megareich;
                }
            }
        }
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
        #region Pattern-Matching C# 7.0 und 7.1
        //public void TesteAufTyp<T>(T item)
        //{
        //    switch (item)
        //    {
        //        case Int32 zahl1:
        //            zahl1 += 5;
        //            break;
        //        default:
        //            break;
        //    }
        //} 
        #endregion
    }
}
