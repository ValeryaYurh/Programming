using System;
using Information;
using Microsoft.VisualBasic;

namespace Lab4
{
    internal class Program
    {
        public static string InputFixString(string input)
        {
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Вы ничего не ввели, попробуйте снова: ");
                input = Console.ReadLine()!;
            }

            return input;

        }

        public static double InputFixDouble(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine()!;
                try
                {
                    double result = double.Parse(input);
                    if (result < 0) throw new Exception("значение не может быть отрицательным.");
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильный ввод, нужно ввести число");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неправильный ввод, " + ex.Message);
                }
            }
        }

        public static int InputFixInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine()!;
                try
                {
                    int result = int.Parse(input);
                    if (result < 0) throw new Exception("число должно быть строго положительным.");
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильный ввод, нужно ввести число");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неправильный ввод, " + ex.Message);
                }
            }
        }


        static void Main()
        {
            Console.WriteLine("Вариант 7\nФирма грузоперевозок");
            TransportCompany company = TransportCompany.GetInstance();

            while (true)
            {
                int answer = InputFixInt("\n---------Меню---------\n0-введение или изменение названия фирмы фирмы\n1-создание тарифов и автоматический подсчёт выручки за тариф\n2-подсчёт выручки фирмы\n3-увеличение тарифа\n4-уменьшение тарифа\n5-подсчёт выручки за выбранный тариф\n6-вывод данных о фирме\nлюбое другое-закончить выполнение");


                switch (answer)
                {
                    case 0:
                        {
                            company.CompanyName = InputFixString(Console.ReadLine());

                            continue;
                        }

                    case 1:
                        {
                            string? typeName;
                            Console.WriteLine("Введите название тарифа(что перевозим): ");
                            typeName = InputFixString(Console.ReadLine());

                            double tarifValue = InputFixDouble("Введите тариф за тонну: ");
                            while (tarifValue == 0)
                            {
                                Console.WriteLine("Неверное значение, число должно быть строго больше 0");
                                tarifValue = InputFixDouble("Введите тариф за тонну: ");
                            }
                            double overallWeight = InputFixDouble("Введите перевезённый вес(в тоннах): ");

                            Tarif tarif = new Tarif(typeName!, tarifValue, overallWeight);
                            company.AddNewTarif(tarif);

                            double revenue = tarif.CalculateRevenue();
                            Console.WriteLine($"Выручка за тариф: {revenue}");

                            continue;
                        }

                    case 2:
                        {
                            Console.WriteLine($"Выручка фирмы: {company.CalculateTotalRevenue()}");

                            continue;
                        }

                    case 3:
                        {
                            System.Console.WriteLine("Введите название тарифа: ");
                            string? nameTarif = InputFixString(Console.ReadLine());

                            Tarif? tarif = company.FindTarifByName(nameTarif);
                            if (tarif == null)
                            {
                                Console.WriteLine("Тариф не найден!");
                                continue;
                            }

                            Console.WriteLine("Поднять на процент или на фиксированную сумму(p(percentage)/a(amount)): ");
                            string? option = Console.ReadLine();
                            if (option == "p")
                            {
                                double percentage = InputFixDouble("Введите процент: ");
                                while (percentage < 0)
                                {
                                    Console.WriteLine("Неверно введено значение");
                                    percentage = InputFixDouble("Введите процент: ");
                                }
                                Console.WriteLine($"Итоговый тариф: {tarif.UpTarif(percentage, true)}");
                                continue;
                            }
                            else if (option == "a")
                            {
                                double amount = InputFixDouble("Введите число: ");
                                Console.WriteLine($"Итоговый тариф: {tarif.UpTarif(amount, false)}");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Введена неверная команда");
                                continue;
                            }

                        }
                    case 4:
                        {
                            System.Console.WriteLine("Введите название тарифа: ");
                            string? nameTarif = InputFixString(Console.ReadLine());

                            Tarif? tarif = company.FindTarifByName(nameTarif);
                            if (tarif == null)
                            {
                                Console.WriteLine("Тариф не найден!");
                                continue;
                            }

                            Console.WriteLine("Опустить на процент или на фиксированную сумму(p(percentage)/a(amount)): ");
                            string? option = Console.ReadLine();
                            if (option == "p")
                            {
                                double percentage = InputFixDouble("Введите процент: ");
                                while (percentage < 0 || percentage > 100)
                                {
                                    Console.WriteLine("Неверно введено значение");
                                    percentage = InputFixDouble("Введите процент: ");
                                }
                                Console.WriteLine($"Итоговый тариф: {tarif.DownTarif(percentage, true)}");
                                continue;
                            }
                            else if (option == "a")
                            {
                                double amount = InputFixDouble("Введите число: ");
                                if (amount <= tarif.TarifValue) Console.WriteLine($"Итоговый тариф: {tarif.DownTarif(amount, false)}");
                                else Console.WriteLine("Некорректое число. Число не может быть больше исходного тарифа");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Введена неверная команда");
                                continue;
                            }

                        }

                    case 5:
                        {
                            Console.WriteLine("Введите имя тарифа: ");
                            string? name = InputFixString(Console.ReadLine());
                            Tarif? tarif = company.FindTarifByName(name);
                            if (tarif == null)
                            {
                                Console.WriteLine("Тариф не найден!");
                                continue;
                            }

                            Console.WriteLine($"Тариф(за тонну): {tarif.TarifValue}\nМасса перевозки: {tarif.OverAllWeight}\nВыручка за тариф: {tarif.CalculateRevenue()}");
                            continue;
                        }

                    case 6:
                        {
                            Console.WriteLine($"Название фирмы: {company.CompanyName}");
                            company.PrintInfo();
                            Console.WriteLine($"Выручка фирмы: {company.CalculateTotalRevenue()}");

                            continue;
                        }

                    default:
                        return;

                }
            }
        }
    }
}