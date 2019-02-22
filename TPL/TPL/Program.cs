using System;
using System.Collections.Generic;
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
