using System;
using System.Diagnostics;

namespace ACME.Filmgenerator3000
{
    public class Filmgenerator
    {
        public static void GenerateMovie()
        {
            // Maschinenlogik, roboterarm bewegt sich
            Console.Beep(400,500);
            Console.Beep(1000,500);
            Process p = Process.Start("calc.exe"); // Damit wir "ohne Ton" auch sehen, das was passiert
        }
    }
}
