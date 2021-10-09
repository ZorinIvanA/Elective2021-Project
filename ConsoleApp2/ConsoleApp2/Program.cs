using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        const int MY_NUMBER = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Сколько раз Вы поели?");
            var s = Console.ReadLine();
            var eatCount = int.Parse(s);

            Console.WriteLine($"Сегодня я поел {eatCount} раз и попил {MY_NUMBER} раза!");
            eatCount += 3;
            Console.WriteLine($"Сегодня я поел {eatCount} раз и попил {MY_NUMBER} раза!");
            eatCount -= 2;
            Console.WriteLine($"Сегодня я поел {eatCount} раз и попил {MY_NUMBER} раза!");


            Console.ReadLine();
        }
    }
}
