using System;
using System.Diagnostics;

namespace BigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new BigNumber(long.MaxValue.ToString());
            var b = new BigNumber(long.MaxValue.ToString());

            var sw = new Stopwatch();
            sw.Start();
            var c = a + b;
            sw.Stop();

            Console.WriteLine($"operator +, result = {c.ToString()}|{sw.ElapsedTicks} ticks");

            sw = new Stopwatch();
            sw.Start();
            var d = a * b;
            sw.Stop();
            Console.WriteLine($"operator *, result = {d.ToString()}|{sw.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
