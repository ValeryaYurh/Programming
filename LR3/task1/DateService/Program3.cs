using System;
using System.ComponentModel;
using System.Security.Principal;
using Services.Task3;

namespace t3
{
    class Program3
    {
        static void Main()
        {
            Console.WriteLine("Задание 3");

            while (true)
            {
                int answer;
                Console.WriteLine("\n-------Меню-------");
                Console.WriteLine("1-Определить день недели\n2-Определить сколько дней пройдёт от текущей даты\n------------------\n\nВведите команду:");
                string? input1 = Console.ReadLine();
                bool isNumber = int.TryParse(input1, out answer);

                while (isNumber == false || (answer != 1 && answer != 2))
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение.\n");
                    Console.WriteLine("\n-------Меню-------");
                    Console.WriteLine("1-Определить день недели\n2-Определить сколько дней пройдёт от текущей даты\n------------------\n\nВведите команду:");
                    input1 = Console.ReadLine();

                    isNumber = int.TryParse(input1, out answer);
                }

                switch (answer)
                {
                    case 1:
                        Console.Write("Дата(дд.мм.гггг): ");
                        string? date = Console.ReadLine();

                        string[] parts = date!.Split('.');

                        while (parts.Length != 3 || parts[0].Length != 2 || parts[1].Length != 2 || parts[2].Length != 4 || Convert.ToInt32(parts[0]) > 31 || Convert.ToInt32(parts[0]) <= 0 || Convert.ToInt32(parts[1]) > 12 || Convert.ToInt32(parts[1]) <= 0 || Convert.ToInt32(parts[2]) < 0 || (!((Convert.ToInt32(parts[2]) % 4 ==0 && Convert.ToInt32(parts[2]) % 100 !=0) || Convert.ToInt32(parts[2]) % 400 ==0 ) && Convert.ToInt32(parts[0])>=29 && parts[1]=="02"))
                        {
                            Console.WriteLine("Ошибка! Введено некорректное значение.\n\nВведите дату(дд.мм.гггг): ");

                            date = Console.ReadLine();
                            parts = date!.Split('.');
                        }

                        Console.WriteLine($"День недели: {DateService.GetDay(date!)}");
                        break;
                    case 2:
                        int day, month, year;
                        Console.Write("День: ");
                        string? input = Console.ReadLine();
                        isNumber = int.TryParse(input, out day);

                        while (isNumber == false || input!.Length > 2 || input.Length < 2 || Convert.ToInt32(input) > 31 || Convert.ToInt32(input) <= 0)
                        {
                            Console.WriteLine("Ошибка! Введено некорректное значение.\n\nВведите день: ");

                            input = Console.ReadLine();

                            isNumber = int.TryParse(input, out day);
                        }

                        Console.Write("Месяц: ");
                        input = Console.ReadLine();
                        isNumber = int.TryParse(input, out month);

                        while (isNumber == false || input!.Length > 2 || input.Length < 2 || Convert.ToInt32(input) > 12 || Convert.ToInt32(input) <= 0)
                        {
                            Console.WriteLine("Ошибка! Введено некорректное значение.\n\nВведите месяц: ");

                            input = Console.ReadLine();

                            isNumber = int.TryParse(input, out month);
                        }

                        Console.Write("Год: ");
                        input = Console.ReadLine();
                        isNumber = int.TryParse(input, out year);

                        while (isNumber == false || input!.Length > 4 || input.Length < 4 || Convert.ToInt32(input) <= 0 || (!((year % 4 ==0 && year % 100 !=0) || year % 400 ==0 ) && day>=29 && month== 02))
                        {
                            Console.WriteLine("Ошибка! Введено некорректное значение.\n\nВведите год: ");

                            input = Console.ReadLine();

                            isNumber = int.TryParse(input, out year);
                        }

                        Console.WriteLine($"Разница между текущим днём: {DateService.GetDaysSpan(day, month, year)}");
                        break;
                }


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

