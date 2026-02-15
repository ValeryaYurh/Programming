using System;

namespace Project
{
    class Program
    {
        static void Main()
        {
            double first_number;
            double second_number;

            Console.WriteLine("Введите делимое: ");
            string? input1 = Console.ReadLine();

            bool isNumber = double.TryParse(input1, out first_number);

            while (isNumber == false)
            {
                Console.WriteLine("Ошибка! Введено некорректное значение.");
                Console.WriteLine("Введите заново делимое: ");
                input1 = Console.ReadLine();

                isNumber = double.TryParse(input1, out first_number);
            }

            Console.WriteLine($"Делимое = {first_number}");

            Console.WriteLine("Введите делитель: ");
            string? input2 = Console.ReadLine();

            isNumber = double.TryParse(input2, out second_number);

            while (isNumber == false || Convert.ToDouble(input2) == 0)
            {
                Console.WriteLine("Ошибка! Введено некорректное значение.");
                Console.WriteLine("Введите заново делитель: ");
                input2 = Console.ReadLine();

                isNumber = double.TryParse(input2, out second_number);
            }

            Console.WriteLine($"Делитель = {first_number}");

            double result = first_number / second_number;
            Console.WriteLine($"Результат деление равен {result}.");

            Console.ReadKey();
        }
    }
}
