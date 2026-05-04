using System;
using System.Collections.Generic;
using TarifInformation;
using ClientsInformation;
using TransportCompanyInformation;

namespace LR8
{
    internal class Program
    {
        private static TransportCompany company = TransportCompany.GetInstance();

        public static string InputFixString(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Вы ничего не ввели, попробуйте снова:");
                input = Console.ReadLine();
            }
            return input;
        }

        public static double InputFixDouble(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                try
                {
                    double result = double.Parse(input);
                    if (result < 0)
                        throw new Exception("Значение не может быть отрицательным");
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильный ввод, нужно ввести число");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неправильный ввод: " + ex.Message);
                }
            }
        }

        public static int InputFixInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                try
                {
                    int result = int.Parse(input);
                    if (result < 0)
                        throw new Exception("Число должно быть неотрицательным");
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильный ввод, нужно ввести целое число");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неправильный ввод: " + ex.Message);
                }
            }
        }

        public static int InputFixIntRange(string message, int min, int max)
        {
            while (true)
            {
                int result = InputFixInt(message);
                if (result >= min && result <= max)
                    return result;
                Console.WriteLine($"Число должно быть в диапазоне от {min} до {max}");
            }
        }

        static void Main()
        {
            Console.WriteLine("Лабораторная работа №8: Полиморфизм\n");
            Console.WriteLine("Вариант: Фирма грузоперевозок\n");

            company.CompanyName = InputFixString("Введите название транспортной компании:");

            while (true)
            {
                int answer = InputFixInt(
                    "\n========= МЕНЮ =========\n" +
                    "0 - Добавить новый тариф\n" +
                    "1 - Добавить нового клиента\n" +
                    "2 - Создать заказ\n" +
                    "3 - Показать все тарифы\n" +
                    "4 - Показать всех клиентов\n" +
                    "5 - Найти тариф по названию\n" +
                    "6 - Найти клиента по имени\n" +
                    "7 - Найти тариф с минимальной стоимостью\n" +
                    "8 - Показать общую выручку\n" +
                    "9 - Демонстрация интерфейса (Strategy)\n" +
                    "10 - Применить стратегию скидки к тарифу\n" +
                    "11 - Показать полную информацию\n" +
                    "любое другое - закончить выполнение");

                try
                {
                    switch (answer)
                    {
                        case 0:
                            {
                                Console.WriteLine("\n--- Добавление нового тарифа ---");
                                string typeName = InputFixString("Введите название тарифа:");
                                double tarifValue = InputFixDouble("Введите базовую стоимость тарифа:");

                                Console.WriteLine("Применить скидку? (да/нет):");
                                string applyDiscount = Console.ReadLine()?.ToLower();

                                IDiscountStrategy strategy;
                                if (applyDiscount == "да")
                                {
                                    double discountPercent = InputFixIntRange("Введите процент скидки (0-100):", 0, 100);
                                    strategy = new PercentageDiscount(discountPercent);
                                }
                                else
                                {
                                    strategy = new NoDiscount();
                                }

                                Tarif newTarif = new Tarif(typeName, tarifValue, strategy);
                                company.AddNewTarif(newTarif);
                                break;
                            }

                        case 1:
                            {
                                Console.WriteLine("\n--- Добавление нового клиента ---");
                                string clientName = InputFixString("Введите имя клиента:");

                                Console.WriteLine("Выберите тип клиента:");
                                Console.WriteLine("1 - Regular");
                                Console.WriteLine("2 - VIP");
                                int typeChoice = InputFixIntRange("Ваш выбор: ", 1, 2);

                                ClientType type = (typeChoice == 1) ? ClientType.Regular : ClientType.VIP;
                                Client newClient = new Client(clientName, type);
                                company.AddNewClient(newClient);
                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("\n--- Создание заказа ---");

                                if (TransportCompany.GetInstance().GetType().GetField("_tarifs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance) != null)
                                {
                                    var tarifsField = company.GetType().GetField("_tarifs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                    var tarifs = (List<Tarif>)tarifsField.GetValue(company);

                                    var clientsField = company.GetType().GetField("_clients", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                    var clients = (List<Client>)clientsField.GetValue(company);

                                    if (tarifs.Count == 0)
                                    {
                                        Console.WriteLine("Нет добавленных тарифов! Сначала добавьте тарифы.");
                                        break;
                                    }

                                    if (clients.Count == 0)
                                    {
                                        Console.WriteLine("Нет добавленных клиентов! Сначала добавьте клиентов.");
                                        break;
                                    }

                                    Console.WriteLine("Выберите тариф:");
                                    for (int i = 0; i < tarifs.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {tarifs[i].TypeName} ({tarifs[i].FinalPrice:F2} руб/кг)");
                                    }
                                    int tarifIndex = InputFixIntRange("Ваш выбор: ", 1, tarifs.Count);

                                    Console.WriteLine("Выберите клиента:");
                                    for (int i = 0; i < clients.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {clients[i].ClientName}");
                                    }
                                    int clientIndex = InputFixIntRange("Ваш выбор: ", 1, clients.Count);

                                    double weight = InputFixDouble("Введите вес груза (кг):");

                                    company.MakeOrder(clients[clientIndex - 1], tarifs[tarifIndex - 1], weight);
                                }
                                break;
                            }

                        case 3:
                            {
                                company.PrintAllTarifs();
                                break;
                            }

                        case 4:
                            {
                                company.PrintAllClients();
                                break;
                            }

                        case 5:
                            {
                                string tarifName = InputFixString("Введите название тарифа для поиска:");
                                Tarif? foundTarif = company.FindTarifByName(tarifName);

                                if (foundTarif != null)
                                    Console.WriteLine($"\nНайден тариф: {foundTarif.ToString()}");
                                else
                                    Console.WriteLine("\nТариф не найден!");
                                break;
                            }

                        case 6:
                            {
                                string clientName = InputFixString("Введите имя клиента для поиска:");
                                Client? foundClient = company.FindClientByName(clientName);

                                if (foundClient != null)
                                {
                                    Console.WriteLine($"\nНайден клиент: {foundClient.ClientName}");
                                    Console.WriteLine($"Тип: {(foundClient.Type == ClientType.VIP ? "VIP" : "Regular")}");
                                    Console.WriteLine($"Общая сумма заказов: {foundClient.GetTotalSum():F2}");
                                }
                                else
                                    Console.WriteLine("\nКлиент не найден!");
                                break;
                            }

                        case 7:
                            {
                                Tarif? minTarif = company.FindMinCostTarif();

                                if (minTarif != null)
                                {
                                    Console.WriteLine($"\n=== Тариф с минимальной стоимостью ===");
                                    Console.WriteLine(minTarif.ToString());
                                }
                                else
                                    Console.WriteLine("\nНет добавленных тарифов!");
                                break;
                            }

                        case 8:
                            {
                                double revenue = company.TotalRevenue();
                                Console.WriteLine($"\nОбщая выручка компании: {revenue:F2} руб");
                                break;
                            }

                        case 9:
                            {
                                company.ShowTarifViaInterface();
                                break;
                            }

                        case 10:
                            {
                                Console.WriteLine("\n--- Применение стратегии скидки ---");

                                var tarifsField = company.GetType().GetField("_tarifs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                var tarifs = (List<Tarif>)tarifsField.GetValue(company);

                                if (tarifs.Count == 0)
                                {
                                    Console.WriteLine("Нет добавленных тарифов!");
                                    break;
                                }

                                Console.WriteLine("Выберите тариф:");
                                for (int i = 0; i < tarifs.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {tarifs[i].TypeName}");
                                }
                                int index = InputFixIntRange("Ваш выбор: ", 1, tarifs.Count);

                                Console.WriteLine("Выберите новую стратегию:");
                                Console.WriteLine("1 - Без скидки");
                                Console.WriteLine("2 - Процентная скидка");
                                int strategyChoice = InputFixIntRange("Ваш выбор: ", 1, 2);

                                IDiscountStrategy newStrategy;
                                if (strategyChoice == 1)
                                {
                                    newStrategy = new NoDiscount();
                                }
                                else
                                {
                                    double discountPercent = InputFixIntRange("Введите процент скидки (0-100):", 0, 100);
                                    newStrategy = new PercentageDiscount(discountPercent);
                                }

                                tarifs[index - 1].ApplyDiscountStrategy(newStrategy);
                                Console.WriteLine($"Стратегия успешно применена к тарифу '{tarifs[index - 1].TypeName}'");
                                Console.WriteLine($"Новая цена: {tarifs[index - 1].FinalPrice:F2}");
                                break;
                            }

                        case 11:
                            {
                                company.PrintInfo();
                                break;
                            }

                        default:
                            Console.WriteLine("\nЗавершение программы...");
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nОшибка: {ex.Message}");
                    Console.WriteLine("Попробуйте снова.");
                }
            }
        }
    }
}