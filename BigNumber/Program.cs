using System;

namespace BigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new BigNumber(long.MaxValue.ToString());
            var b = new BigNumber(long.MaxValue.ToString());

            var c = a + b;
            Console.WriteLine(c.ToString());

            var d = a * b;
            Console.WriteLine(d.ToString());

            Console.ReadKey();
        }
    }
}
