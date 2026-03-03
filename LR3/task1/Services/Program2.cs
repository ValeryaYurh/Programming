using System;
using System.ComponentModel;
using System.Security.Principal;
using Services.Task2;

namespace t2
{
    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Задание 2");
            Console.WriteLine("Вариант 3\nЗадание: Вывести в консоль результат выполнения и номер ветки, по которой производилось вычисление по заданному варианту.");


            while (true)
            {
                double z;
                Console.WriteLine("Введите число z: ");
                string? input1 = Console.ReadLine();

                bool isNumber = double.TryParse(input1, out z);

                while (isNumber == false)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново число: ");
                    input1 = Console.ReadLine();

                    isNumber = double.TryParse(input1, out z);
                }

                double b;
                Console.WriteLine("Введите число b(стого больше 0): ");
                string? input2 = Console.ReadLine();

                isNumber = double.TryParse(input2, out b);

                while (isNumber == false || b <= 0)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново число b: ");
                    input2 = Console.ReadLine();

                    isNumber = double.TryParse(input2, out b);
                }

                double y = FunctionalCalc.Calculation(z, b);
                Console.WriteLine($"Результат выволнения = {y}");
                if (z < 1) Console.WriteLine("Номер ветки 1(z<1)\n");
                else Console.WriteLine("Номер ветки 2(z>=1)\n");

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
