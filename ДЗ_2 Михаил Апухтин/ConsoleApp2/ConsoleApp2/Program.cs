using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВЕДИТЕ ГОД: ");
            int got = Convert.ToInt32(Console.ReadLine());
            if (got % 4 == 0 && got % 100 != 0 || got % 400 == 0 && got % 100 != 0)
            {
                    Console.WriteLine("Yes");
                
            } else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
