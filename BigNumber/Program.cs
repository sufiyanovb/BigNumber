using System;
using System.Diagnostics;

namespace BigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber a = "95";
            BigNumber b = "5";

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
