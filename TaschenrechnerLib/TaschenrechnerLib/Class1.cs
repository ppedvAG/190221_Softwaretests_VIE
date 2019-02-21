using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaschenrechnerLib
{
    public class Taschenrechner
    {
        public int Add(int z1, int z2)
        {
            return checked(z1 + z2); // Bei Arithm. Überlauf/Unterlauf wird eine OverflowException geworfen
        }
    }
}
