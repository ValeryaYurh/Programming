using System;
using System.ComponentModel;
using System.Security.Principal;

namespace t1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вариант 12\nЗадание: Определить, лежит ли точка внутри заштрихованной области, вне заштрихованной области или на ее границе");


            while (true)
            {
                int x;
                int y;

                Console.WriteLine("Введите координату x: ");
                string? input1 = Console.ReadLine();

                bool isNumber = int.TryParse(input1, out x);

                while (isNumber == false)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново координату x: ");
                    input1 = Console.ReadLine();

                    isNumber = int.TryParse(input1, out x);
                }

                Console.WriteLine("Введите координату y: ");
                string? input2 = Console.ReadLine();

                isNumber = int.TryParse(input2, out y);

                while (isNumber == false)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново координату y: ");
                    input2 = Console.ReadLine();

                    isNumber = int.TryParse(input2, out y);
                }

                Console.WriteLine("\nЛежит ли точка внутри заштрихованной области?");
                if (x>-50 && x<50 && y>-25 && y<25) Console.WriteLine("Да");
                else if ((x>=-50 && x<=50 && y==25)||(x>=-50 && x<=50 && y==-25)||(x==50 && y>=-25 && y<=25)||(x==-50 && y>=-25 && y<=25)) Console.WriteLine("На границе");
                else Console.WriteLine("Нет");


                int answer;
                Console.WriteLine("\n-------Меню-------");
                Console.WriteLine("1-Продолжить\n2-Закончить\n------------------\n\nВведите команду:");
                string? input3 = Console.ReadLine();
                isNumber = int.TryParse(input3, out answer);

                while (isNumber == false || (answer != 1 && answer != 2))
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\n");
                    Console.WriteLine("\n-------Меню-------");
                    Console.WriteLine("1-Продолжить\n2-Закончить\n------------------\n\nВведите команду:");
                    input3 = Console.ReadLine();

                    isNumber = int.TryParse(input3, out answer);
                }

                switch (answer)
                {
                    case 1:
                        continue;
                    case 2:
                        return;
                }
            }
        }
    }
}

