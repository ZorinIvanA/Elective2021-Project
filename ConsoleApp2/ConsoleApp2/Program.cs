using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        const int MAX_EAT_NUMBER_IN_DAY = 3;

        static void Main(string[] args)
        {
            #region Оператор if
            //Console.WriteLine("Сколько раз Вы поели?");
            //var s = Console.ReadLine();
            //var eatCount = int.Parse(s);

            //if (eatCount > MAX_EAT_NUMBER_IN_DAY)
            //{
            //    //Блок "Правда"
            //    Console.WriteLine("Вы слишком много едите!");
            //}
            //else
            //{
            //    //Блок "Ложь"
            //    Console.WriteLine("Всё хорошо!");
            //}
            #endregion

            #region Оператор switch
            //Console.WriteLine("Введите день недели");
            //var day = int.Parse(Console.ReadLine());

            //switch (day)
            //{
            //    case 1:
            //    case 2:
            //    case 3:
            //    case 4:
            //    case 5:
            //        Console.WriteLine("Вы идёте в школу");
            //        break;

            //    case 6:
            //    case 7:
            //        Console.WriteLine("Вы НЕ идёте в школу");
            //        break;

            //    default:
            //        Console.WriteLine("Такого дня нет");
            //        break;
            //}
            #endregion

            #region Оператор for
            //Console.WriteLine("Введите количество чисел");
            //var numbersCount = int.Parse(Console.ReadLine());

            //var sum = 0;
            //for (int i = 1; i <= numbersCount; i++)
            //{
            //    Console.WriteLine($"Введите число №{i}");
            //    var nextNumber = int.Parse(Console.ReadLine());

            //    sum += nextNumber;
            //    Console.WriteLine($"Вы ввели число {nextNumber}. Общая сумма {sum}");
            //}

            #endregion

            #region массив
            Console.WriteLine("Введите количество камер");
            var camerasCount = int.Parse(Console.ReadLine());
            var camerasArray = new int[camerasCount];
            //Заполняем массив значениями
            for (int i = 0; i < camerasCount; i++)
            {
                Console.WriteLine($"Введите скорость на камере №{i + 1}");
                camerasArray[i] = int.Parse(Console.ReadLine());
            }

            //Вычисляем среднюю скорость
            var sum = 0;
            foreach (var cameraSpeed in camerasArray)
            {
                sum += cameraSpeed;
            }
            Console.WriteLine($"Средняя скорость: {sum / camerasArray.Length}");            

            #endregion

            Console.ReadLine();

        }
    }
}
