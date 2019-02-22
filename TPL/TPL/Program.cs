using AutoFixture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task
            // Parallel
            // .AsParallel() -> LINQ

            #region Threads

            //Thread t1 = new Thread(Punkterl);
            //Thread t2 = new Thread(Stricherl);

            //t1.Start();
            //t2.Start(); 
            #endregion

            #region Starten und warten auf Tasks
            ////Task t1 = new Task(MachEtwas);
            ////t1.Start();

            ////Task.Factory.StartNew(() =>
            ////{
            ////    Console.WriteLine("Ich mache auch etwas");
            ////}); // 4.0

            ////Task.Run(() =>
            ////{
            ////    Console.WriteLine("Und ich ebenfalls...");
            ////}); // 4.5

            //Task<string> t1 = Task.Run(() =>
            //{
            //    Thread.Sleep(5000);
            //    return DateTime.Now.ToLongTimeString();
            //});

            ////Task.WaitAll(t1);
            ////Task.WaitAny(t1, t2, t3);

            ////t1.Wait();
            //Thread.Sleep(8000);
            //string erg = t1.Result;
            //Console.WriteLine(erg); 
            #endregion

            #region Exceptions im Task
            //Task t1 = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    throw new DivideByZeroException();
            //});
            //Task t2 = Task.Run(() =>
            //{
            //    Thread.Sleep(3000);
            //    throw new FormatException();
            //});
            //Task t3 = Task.Run(() =>
            //{
            //    Thread.Sleep(5000);
            //    throw new StackOverflowException();
            //});

            //try
            //{
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex)
            //{
            //} 
            #endregion

            #region Parallel
            //Parallel.For(0, 1000,new ParallelOptions { MaxDegreeOfParallelism = 2 }, i =>
            //  {
            //      Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            //  });

            //string[] namen = { "Tom Ate", "Anna Nass", "Peter Silie", "Frank Ose", "Martha Pfahl", "Klara Fall", "Rainer Zufall", "Bill Dung", "Axel Schweiß", "Albert Tross" };

            //Parallel.ForEach(namen, item =>
            //{
            //    Console.WriteLine(item);
            //}); 
            #endregion

            // Performancetest
            var fix = new Fixture();
            Console.WriteLine("Create Testdata");
            var personenEnumerable = fix.CreateMany<Person>(100_000);
            Console.WriteLine("Testdata created");

            Stopwatch watch = new Stopwatch();
            var personen = personenEnumerable.ToList();

            //var gefiltert = personen.Where(x => x.Kontostand > 1000).AsParallel();

            decimal gesamtKontostand = 0;
            watch.Start();
            for (int i = 0; i < personen.Count; i++)
                gesamtKontostand += personen[i].Kontostand;
            watch.Stop();

            Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms {gesamtKontostand}");

            gesamtKontostand = 0;
            watch.Restart();
            foreach (var item in personen)
                gesamtKontostand += item.Kontostand;
            watch.Stop();
            Console.WriteLine($"Foreach: {watch.ElapsedMilliseconds}ms {gesamtKontostand}");

            watch.Restart();
            gesamtKontostand = personen.Sum(x => x.Kontostand);
            watch.Stop();
            Console.WriteLine($"LINQ: {watch.ElapsedMilliseconds}ms {gesamtKontostand}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void MachEtwas()
        {
            Console.WriteLine("Es wird etwas gemacht ...");
        }

        #region Threads
        //private static void Stricherl()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(200);
        //        Console.Write("-");
        //    }
        //}
        //private static void Punkterl()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(50);
        //        Console.Write(".");
        //    }
        //} 
        #endregion
    }
}
