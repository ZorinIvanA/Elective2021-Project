using OOP.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lesson lesson = new Lesson();
            //lesson.Finish(DateTime.Now);
            //lesson.Start();
            //var tempDate = lesson.GetFinishDate();
            //Console.WriteLine(tempDate);

            //var animal = new Bird();
            //animal.Diagnose();

            var lesson = new Lesson();
            lesson.ClassNumber = 1;

            Console.ReadLine();
        }
    }
}
