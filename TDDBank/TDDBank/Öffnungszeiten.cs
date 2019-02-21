using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    struct Zeiten
    {
        public Zeiten(TimeSpan offenAb, TimeSpan zuAb) : this()
        {
            OffenAb = offenAb;
            ZuAb = zuAb;
        }

        public TimeSpan OffenAb { get; set; }
        public TimeSpan ZuAb { get; set; }
    }

    public class Öffnungszeiten
    {
        public Öffnungszeiten()
        {
            tage.Add(DayOfWeek.Monday, new Zeiten(new TimeSpan(10, 30, 00), new TimeSpan(19, 00, 00)));
            tage.Add(DayOfWeek.Tuesday, new Zeiten(new TimeSpan(10, 30, 00), new TimeSpan(19, 00, 00)));
            tage.Add(DayOfWeek.Wednesday, new Zeiten(new TimeSpan(10, 30, 00), new TimeSpan(19, 00, 00)));
            tage.Add(DayOfWeek.Thursday, new Zeiten(new TimeSpan(10, 30, 00), new TimeSpan(19, 00, 00)));
            tage.Add(DayOfWeek.Friday, new Zeiten(new TimeSpan(10, 30, 00), new TimeSpan(19, 00, 00)));
            tage.Add(DayOfWeek.Saturday, new Zeiten(new TimeSpan(10, 30, 00), new TimeSpan(14 ,00, 00)));
        }
        private Dictionary<DayOfWeek, Zeiten> tage = new Dictionary<DayOfWeek, Zeiten>();

        public bool IsOpen(DateTime time)
        {
            return tage.ContainsKey(time.DayOfWeek) &&
                   tage[time.DayOfWeek].OffenAb <= time.TimeOfDay &&
                   tage[time.DayOfWeek].ZuAb > time.TimeOfDay;
        }
    }
}
