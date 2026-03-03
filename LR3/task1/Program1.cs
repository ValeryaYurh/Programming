using System;
using System.ComponentModel;
using System.Security.Principal;
using Changing.Method;

namespace t1
{
    class Program1
    {
        static void Main()
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("Вариант 7\nЗадание: Разработать метод, который нечетное число заменяет на 0, а четное число уменьшает в два раза.");


            while (true)
            {
                int number;
                Console.WriteLine("Введите число: ");
                string? input1 = Console.ReadLine();

                bool isNumber = int.TryParse(input1, out number);

                while (isNumber == false)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново число: ");
                    input1 = Console.ReadLine();

                    isNumber = int.TryParse(input1, out number);
                }

                int result = Function.Changes(number);
                Console.WriteLine($"Результат преобразования: {number} преобразовалось в {result}");


                int answer;
                Console.WriteLine("\n-------Меню-------");
                Console.WriteLine("1-Продолжить\n2-Закончить\n------------------\n\nВведите команду:");
                string? input2 = Console.ReadLine();
                isNumber = int.TryParse(input2, out answer);

                while (isNumber == false || (answer != 1 && answer != 2))
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\n");
                    Console.WriteLine("\n-------Меню-------");
                    Console.WriteLine("1-Продолжить\n2-Закончить\n------------------\n\nВведите команду:");
                    input2 = Console.ReadLine();

                    isNumber = int.TryParse(input2, out answer);
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
