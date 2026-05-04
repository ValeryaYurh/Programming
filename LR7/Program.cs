using System;
using System.Collections.Generic;

namespace LR7
{
    internal class Program
    {
        private static List<Matrix> matrices = new List<Matrix>();

        public static int InputFixInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? input = Console.ReadLine();
                try
                {
                    int result = int.Parse(input);
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

        private static Matrix InputMatrix()
        {
            Console.WriteLine("\n--- Ввод матрицы 2x2 ---");
            Console.WriteLine("Введите элементы матрицы построчно:");
            
            int a00 = InputFixInt("Элемент [0,0]: ");
            int a01 = InputFixInt("Элемент [0,1]: ");
            int a10 = InputFixInt("Элемент [1,0]: ");
            int a11 = InputFixInt("Элемент [1,1]: ");
            
            return new Matrix(a00, a01, a10, a11);
        }

        private static Matrix? GetMatrixByIndex(string operation)
        {
            if (matrices.Count == 0)
            {
                Console.WriteLine("Нет созданных матриц!");
                return null;
            }

            Console.WriteLine($"\n--- {operation} ---");
            Console.WriteLine("\nСписок матриц:");
            for (int i = 0; i < matrices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Матрица {i + 1}:\n{matrices[i]}\nОпределитель: {matrices[i].Determinant}");
            }

            int index = InputFixIntRange("Выберите номер матрицы: ", 1, matrices.Count);
            return matrices[index - 1];
        }

        static void Main()
        {
            Console.WriteLine("LR7\n");
            Console.WriteLine("Вариант 7: Класс квадратная матрица 2x2 типа int\n");

            while (true)
            {
                int answer = InputFixInt(
                    "\n========= МЕНЮ =========\n0 - Создать новую матрицу\n1 - Показать все матрицы\n2 - Сложение матриц (+)\n3 - Вычитание матриц (-)\n4 - Умножение матриц (*)\n5 - Умножение матрицы на число\n6 - Деление матрицы на число\n7 - Инкремент матрицы (++)\n8 - Декремент матрицы (--)\n9 - Сравнение матриц (==, !=)\n10 - Проверка на истинность (true/false)\n11 - Преобразование в число (определитель)\n12 - Преобразование из числа в матрицу\n13 - Доступ к элементам через индексатор\n14 - Вычислить определитель\nлюбое другое - закончить выполнение");

                try
                {
                    switch (answer)
                    {
                        case 0:
                            {
                                Matrix matrix = InputMatrix();
                                matrices.Add(matrix);
                                Console.WriteLine($"\nМатрица успешно создана и добавлена в список (всего матриц: {matrices.Count})");
                                break;
                            }

                        case 1:
                            {
                                if (matrices.Count == 0)
                                {
                                    Console.WriteLine("Нет созданных матриц!");
                                    break;
                                }

                                Console.WriteLine("\n--- Список всех матриц ---");
                                for (int i = 0; i < matrices.Count; i++)
                                {
                                    Console.WriteLine($"\nМатрица {i + 1}:");
                                    Console.WriteLine(matrices[i]);
                                    Console.WriteLine($"Определитель: {matrices[i].Determinant}");
                                }
                                break;
                            }

                        case 2:
                            {
                                Matrix? m1 = GetMatrixByIndex("Сложение матриц");
                                if (m1 == null) break;

                                Matrix? m2 = GetMatrixByIndex("Выберите вторую матрицу для сложения");
                                if (m2 == null) break;

                                Matrix result = m1 + m2;
                                Console.WriteLine($"\nРезультат сложения:\n{result}");
                                Console.WriteLine($"Определитель результата: {result.Determinant}");
                                break;
                            }

                        case 3:
                            {
                                Matrix? m1 = GetMatrixByIndex("Вычитание матриц");
                                if (m1 == null) break;

                                Matrix? m2 = GetMatrixByIndex("Выберите вторую матрицу для вычитания");
                                if (m2 == null) break;

                                Matrix result = m1 - m2;
                                Console.WriteLine($"\nРезультат вычитания:\n{result}");
                                Console.WriteLine($"Определитель результата: {result.Determinant}");
                                break;
                            }

                        case 4:
                            {
                                Matrix? m1 = GetMatrixByIndex("Умножение матриц");
                                if (m1 == null) break;

                                Matrix? m2 = GetMatrixByIndex("Выберите вторую матрицу для умножения");
                                if (m2 == null) break;

                                Matrix result = m1 * m2;
                                Console.WriteLine($"\nРезультат умножения:\n{result}");
                                Console.WriteLine($"Определитель результата: {result.Determinant}");
                                break;
                            }

                        case 5:
                            {
                                Matrix? m = GetMatrixByIndex("Умножение матрицы на число");
                                if (m == null) break;

                                int number = InputFixInt("Введите число для умножения: ");
                                Matrix result = m * number;
                                Console.WriteLine($"\nРезультат умножения на {number}:\n{result}");
                                break;
                            }

                        case 6:
                            {
                                Matrix? m = GetMatrixByIndex("Деление матрицы на число");
                                if (m == null) break;

                                int number = InputFixInt("Введите число для деления: ");
                                try
                                {
                                    Matrix result = m / number;
                                    Console.WriteLine($"\nРезультат деления на {number}:\n{result}");
                                }
                                catch (DivideByZeroException ex)
                                {
                                    Console.WriteLine($"Ошибка: {ex.Message}");
                                }
                                break;
                            }

                        case 7:
                            {
                                Matrix? m = GetMatrixByIndex("Инкремент матрицы (++)");
                                if (m == null) break;

                                Console.WriteLine($"\nМатрица до инкремента:\n{m}");
                                m++;
                                Console.WriteLine($"\nМатрица после инкремента:\n{m}");
                                break;
                            }

                        case 8:
                            {
                                Matrix? m = GetMatrixByIndex("Декремент матрицы (--)");
                                if (m == null) break;

                                Console.WriteLine($"\nМатрица до декремента:\n{m}");
                                m--;
                                Console.WriteLine($"\nМатрица после декремента:\n{m}");
                                break;
                            }

                        case 9:
                            {
                                Matrix? m1 = GetMatrixByIndex("Сравнение матриц");
                                if (m1 == null) break;

                                Matrix? m2 = GetMatrixByIndex("Выберите вторую матрицу для сравнения");
                                if (m2 == null) break;

                                bool equal = (m1 == m2);
                                bool notEqual = (m1 != m2);

                                Console.WriteLine($"\nРезультаты сравнения:");
                                Console.WriteLine($"m1 == m2: {equal}");
                                Console.WriteLine($"m1 != m2: {notEqual}");
                                break;
                            }

                        case 10:
                            {
                                Matrix? m = GetMatrixByIndex("Проверка на истинность (true/false)");
                                if (m == null) break;

                                Console.WriteLine($"\nМатрица:\n{m}");
                                Console.WriteLine($"Определитель: {m.Determinant}");

                                if (m)
                                    Console.WriteLine("Матрица TRUE (определитель != 0)");
                                else
                                    Console.WriteLine("Матрица FALSE (определитель = 0)");
                                break;
                            }

                        case 11:
                            {
                                Matrix? m = GetMatrixByIndex("Преобразование в число (определитель)");
                                if (m == null) break;

                                Console.WriteLine($"\nМатрица:\n{m}");
                                int determinant = (int)m;
                                Console.WriteLine($"\nПреобразование в число (явное):\nОпределитель = {determinant}");
                                break;
                            }

                        case 12:
                            {
                                int value = InputFixInt("Введите число для преобразования в матрицу: ");
                                Matrix result = (Matrix)value;
                                
                                Console.WriteLine($"\nПреобразование из числа {value} в матрицу (явное):");
                                Console.WriteLine($"Результат (диагональная матрица):\n{result}");
                                matrices.Add(result);
                                Console.WriteLine($"\nМатрица добавлена в список");
                                break;
                            }

                        case 13:
                            {
                                Matrix? m = GetMatrixByIndex("Доступ к элементам через индексатор");
                                if (m == null) break;

                                Console.WriteLine($"\nТекущая матрица:\n{m}");
                                
                                Console.WriteLine("\n--- Чтение элементов ---");
                                for (int i = 0; i < 2; i++)
                                    for (int j = 0; j < 2; j++)
                                        Console.WriteLine($"m[{i},{j}] = {m[i, j]}");

                                Console.WriteLine("\n--- Изменение элементов ---");
                                int row = InputFixIntRange("Введите номер строки (0-1): ", 0, 1);
                                int col = InputFixIntRange("Введите номер столбца (0-1): ", 0, 1);
                                int newValue = InputFixInt($"Введите новое значение для m[{row},{col}]: ");
                                
                                m[row, col] = newValue;
                                Console.WriteLine($"\nМатрица после изменения:\n{m}");
                                break;
                            }

                        case 14:
                            {
                                Matrix? m = GetMatrixByIndex("Вычислить определитель");
                                if (m == null) break;

                                Console.WriteLine($"\nМатрица:\n{m}");
                                Console.WriteLine($"\nОпределитель = {m.Determinant}");
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