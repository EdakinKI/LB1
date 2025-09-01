using System;
using System.Collections.Generic;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс для тестирования библиотеки классов Model
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор затраченных калорий");
            Console.WriteLine("================================\n");

            List<IExercise> exercises = new List<IExercise>();
            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("\n=== МЕНЮ ВЫБОРА УПРАЖНЕНИЙ ===");
                Console.WriteLine("1. Добавить упражнение 'Бег'");
                Console.WriteLine("2. Добавить упражнение 'Плавание'");
                Console.WriteLine("3. Добавить упражнение 'Жим штанги'");
                Console.WriteLine("4. Завершить ввод и показать результаты");
                Console.WriteLine("==================================");

                int choice = GetValidIntInput("Выберите действие (1-4): ", 1, 4);

                switch (choice)
                {
                    case 1:
                        exercises.Add(CreateRunningExercise());
                        break;
                    case 2:
                        exercises.Add(CreateSwimmingExercise());
                        break;
                    case 3:
                        exercises.Add(CreateBenchPressExercise());
                        break;
                    case 4:
                        continueAdding = false;
                        break;
                }

                if (continueAdding)
                {
                    Console.WriteLine($"\nУпражнений добавлено: {exercises.Count}");
                }
            }

            if (exercises.Count > 0)
            {
                ShowResults(exercises);
            }
            else
            {
                Console.WriteLine("\nНе добавлено ни одного упражнения.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static void ShowResults(List<IExercise> exercises)
        {
            Console.WriteLine("\n\nРезультаты расчета калорий:");
            Console.WriteLine("============================");

            double totalCalories = 0;

            for (int i = 0; i < exercises.Count; i++)
            {
                double calories = exercises[i].CalculateCalories();
                totalCalories += calories;

                Console.WriteLine($"\nУпражнение #{i + 1}:");
                Console.WriteLine(exercises[i].GetExerciseInfo());
                Console.WriteLine($"Затрачено калорий: {calories:F2}");
            }

            Console.WriteLine($"\nОбщее количество затраченных калорий: {totalCalories:F2}");
            Console.WriteLine($"Количество упражнений: {exercises.Count}");
        }

        private static Running CreateRunningExercise()
        {
            Console.WriteLine("\n=== Создание упражнения 'Бег' ===");

            string name = GetValidStringInput("Название: ", "Название не может быть пустым");
            double intensity = GetValidDoubleInput("Интенсивность (км/ч): ", 1, 30);
            double distance = GetValidDoubleInput("Дистанция (км): ", 0.1, 100);

            var running = new Running(name, intensity, distance);
            Console.WriteLine("Упражнение 'Бег' успешно создано!");
            return running;
        }

        private static Swimming CreateSwimmingExercise()
        {
            Console.WriteLine("\n=== Создание упражнения 'Плавание' ===");

            string name = GetValidStringInput("Название: ", "Название не может быть пустым");
            SwimmingStyle style = GetValidSwimmingStyleInput();
            double distance = GetValidDoubleInput("Дистанция (м): ", 1, 10000);

            var swimming = new Swimming(name, style, distance);
            Console.WriteLine("Упражнение 'Плавание' успешно создано!");
            return swimming;
        }

        private static BenchPress CreateBenchPressExercise()
        {
            Console.WriteLine("\n=== Создание упражнения 'Жим штанги' ===");

            string name = GetValidStringInput("Название: ", "Название не может быть пустым");
            double weight = GetValidDoubleInput("Вес (кг): ", 1, 300);
            int repetitions = GetValidIntInput("Повторения: ", 1, 100);

            var benchPress = new BenchPress(name, weight, repetitions);
            Console.WriteLine("Упражнение 'Жим штанги' успешно создано!");
            return benchPress;
        }

        private static string GetValidStringInput(string prompt, string errorMessage)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException(errorMessage);
                    }

                    if (input.Length > 50)
                    {
                        throw new ArgumentException("Название слишком длинное (макс. 50 символов)");
                    }

                    return input;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, попробуйте снова...");
                }
            }
        }

        private static double GetValidDoubleInput(string prompt, double min, double max)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (!double.TryParse(input, out double value))
                    {
                        throw new FormatException("Неверный формат числа");
                    }

                    if (value < min || value > max)
                    {
                        throw new ArgumentOutOfRangeException($"Значение должно быть от {min} до {max}");
                    }

                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите корректное число");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine("Пожалуйста, попробуйте снова...");
            }
        }

        private static int GetValidIntInput(string prompt, int min, int max)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int value))
                    {
                        throw new FormatException("Неверный формат числа");
                    }

                    if (value < min || value > max)
                    {
                        throw new ArgumentOutOfRangeException($"Значение должно быть от {min} до {max}");
                    }

                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите целое число");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine("Пожалуйста, попробуйте снова...");
            }
        }

        private static SwimmingStyle GetValidSwimmingStyleInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Доступные стили плавания:");
                    Console.WriteLine("0 - Freestyle (Вольный стиль)");
                    Console.WriteLine("1 - Breaststroke (Брасс)");
                    Console.WriteLine("2 - Backstroke (На спине)");
                    Console.WriteLine("3 - Butterfly (Баттерфляй)");

                    Console.Write("Выберите стиль (0-3): ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int styleValue))
                    {
                        throw new FormatException("Неверный формат числа");
                    }

                    if (!Enum.IsDefined(typeof(SwimmingStyle), styleValue))
                    {
                        throw new ArgumentOutOfRangeException("Неверное значение стиля. Введите число от 0 до 3.");
                    }

                    return (SwimmingStyle)styleValue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите число от 0 до 3");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                Console.WriteLine("Пожалуйста, попробуйте снова...");
            }
        }
    }
}