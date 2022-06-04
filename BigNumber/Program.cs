using System;
using System.Diagnostics;

namespace BigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber a = "100";
            BigNumber b = "948";

            var sw = new Stopwatch();
            sw.Start();
            var c = a + b;
            sw.Stop();

            Console.WriteLine($"operator +, result = {c.ToString()}|{sw.ElapsedTicks} ticks");

            sw.Reset();

            sw.Start();
            var d = a * b;
            sw.Stop();
            Console.WriteLine($"operator *, result = {d.ToString()}|{sw.ElapsedTicks} ticks");

            Console.ReadKey();
        }
    }
}
