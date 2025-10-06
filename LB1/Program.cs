using System;
using System.Collections.Generic;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Класс Main
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        public static void Main(string[] args)
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
                        exercises.Add(ExerciseBase.CreateRunningExercise());
                        break;
                    case 2:
                        exercises.Add(ExerciseBase.CreateSwimmingExercise());
                        break;
                    case 3:
                        exercises.Add(ExerciseBase.CreateBenchPressExercise());
                        break;
                    case 4:
                        continueAdding = false;
                        break;
                }

                if (continueAdding)
                {
                    Console.WriteLine($"\nУпражнений добавлено:" +
                                      $" {exercises.Count}");
                }
            }

            if (exercises.Count > 0)
            {
                ShowResults(exercises);
                ShowCaloriesVisualization(exercises);
            }
            else
            {
                Console.WriteLine("\nНе добавлено ни одного упражнения.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод данных каждого упражнения
        /// </summary>
        /// <param name="exercises"></param>
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

            Console.WriteLine($"\nОбщее количество затраченных калорий: " +
                              $"{totalCalories:F2}");
            Console.WriteLine($"Количество упражнений: {exercises.Count}");
        }

        /// <summary>
        /// Визуализация затраты калорий всех упражнений
        /// </summary>
        /// <param name="exercises"></param>
        private static void ShowCaloriesVisualization(List<IExercise> exercises)
        {
            double totalCalories = 0;
            foreach (var exercise in exercises)
            {
                totalCalories += exercise.CalculateCalories();
            }

            Console.WriteLine("\n\n╔═════════════════════════════════════════╗");
            Console.WriteLine("║          ВИЗУАЛИЗАЦИЯ КАЛОРИЙ           ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");

            double maxCaloriesForVisualization = GetValidDoubleInput
            ("Введите максимальное значение затраты калорий в день " +
             "(от 1 до 10000): ", 1, 10000);

            int maxBarWidth = 50;
            int barLength = (int)(totalCalories / maxCaloriesForVisualization * 
                                  maxBarWidth);
            barLength = Math.Min(barLength, maxBarWidth);

            Console.Write("\nПрогресс: [");
            Console.ForegroundColor = GetCaloriesColor(totalCalories);
            for (int i = 0; i < barLength; i++)
            {
                Console.Write("█");
            }
            for (int i = barLength; i < maxBarWidth; i++)
            {
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.WriteLine($"] {totalCalories:F0} / " +
                              $"{maxCaloriesForVisualization} ккал");

            Console.WriteLine("\nДетализация по упражнениям:");
            Console.WriteLine("───────────────────────────");

            foreach (var exercise in exercises)
            {
                double calories = exercise.CalculateCalories();
                double percentage = (calories / totalCalories) * 100;

                Console.Write($"{exercise.Name,-20} ");
                Console.ForegroundColor = GetCaloriesColor(calories);
                Console.Write($"{calories,6:F0} ккал");
                Console.ResetColor();
                Console.WriteLine($" ({percentage,5:F1}%)");
            }
        }

        /// <summary>
        /// Задание цветовой гаммы
        /// </summary>
        /// <param name="calories"></param>
        /// <returns></returns>
        private static ConsoleColor GetCaloriesColor(double calories)
        {
            //TODO: RSDN
            if (calories < 100) return ConsoleColor.Green;
            if (calories < 300) return ConsoleColor.Yellow;
            if (calories < 500) return ConsoleColor.DarkYellow;
            return ConsoleColor.Red;
        }

        //TODO: duplication
        /// <summary>
        /// Проверка задания пользователем затраты калорий в день
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static double GetValidDoubleInput(string prompt, double min,
                                                  double max)
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
                        throw new ArgumentOutOfRangeException($"Значение" +
                                        $" должно быть от {min} до {max}");
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

        //TODO: duplication

        /// <summary>
        /// Проверка выбора упражнения
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
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
                        throw new ArgumentOutOfRangeException($"Значение" +
                                         $" должно быть от {min} до {max}");
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
    }
}