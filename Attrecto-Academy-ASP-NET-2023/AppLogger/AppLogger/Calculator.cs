using System;

namespace AppLogger
{
    public class Logger
    {
        static void Main(string[] args)
        {
            Console.Write("Adj meg egy számot: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adj meg egy másik számot: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Összeg: ");
            Console.WriteLine(num1 + num2);
            Console.WriteLine("Különbség: ");
            Console.WriteLine(num1 - num2);
            Console.WriteLine("Szorzat: ");
            Console.WriteLine(num1 * num2);
            Console.WriteLine("Hányados: ");
            Console.WriteLine(num1 / num2);

            Console.ReadLine();


        }
    }
}