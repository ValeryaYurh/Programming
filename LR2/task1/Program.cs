using System;
using System.ComponentModel;
using System.Security.Principal;

namespace t1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вариант 14\nЗадание: Определить, какая из цифр трехзначного числа больше: вторая или последняя");


            while (true)
            {
                int number;
                Console.WriteLine("Введите трёхзначное число: ");
                string? input1 = Console.ReadLine();

                bool isNumber = int.TryParse(input1, out number);

                while (isNumber == false || input1.Length > 3 || input1.Length < 3)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново трёхзначное число: ");
                    input1 = Console.ReadLine();

                    isNumber = int.TryParse(input1, out number);
                }
                if (isNumber == true && input1.Length == 3)
                {
                    int mod = number % 100;
                    int second_number = mod/10;
                    int third_number = mod%10;

                    if (second_number > third_number) Console.WriteLine("Второе число больше последнего");
                    else if (second_number < third_number) Console.WriteLine("Последнее число больше второго");
                    else Console.WriteLine("Второе и последнее число одинаковы");
                }

                int answer;
                Console.WriteLine("Хотите ли продолжить?(1-да; 2-нет): ");
                string? input2 = Console.ReadLine();
                isNumber = int.TryParse(input2, out answer);

                while (isNumber == false || (answer != 1 && answer != 2))
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\nВведите заново ответ\nХотите ли продолжить?(1-да; 2-нет): ");
                    input2 = Console.ReadLine();

                    isNumber = int.TryParse(input2, out answer);
                }

                switch (answer)
                {
                    case 1:
                        continue;
                    case 2:
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
