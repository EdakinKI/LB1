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
                        var running = CreateRunningExercise();
                        if (running != null)
                            exercises.Add(running);
                        break;
                    case 2:
                        var swimming = CreateSwimmingExercise();
                        if (swimming != null)
                            exercises.Add(swimming);
                        break;
                    case 3:
                        var benchPress = CreateBenchPressExercise();
                        if (benchPress != null)
                            exercises.Add(benchPress);
                        break;
                    case 4:
                        continueAdding = false;
                        break;
                }

                if (continueAdding && exercises.Count > 0)
                {
                    Console.WriteLine($"\nУпражнений добавлено: " +
                                      $"{exercises.Count}");
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
        /// Создание упражнения Бег
        /// </summary>
        /// <returns></returns>
        private static Running CreateRunningExercise()
        {
            string name = "";
            double intensity = 0;
            double distance = 0;

            try
            {
                Console.WriteLine("\nСоздание упражнения 'Бег'");

                name = GetValidStringInput("Название: ");

                intensity = GetValidDoubleInput("Интенсивность (км/ч): ", 1, 30);

                distance = GetValidDoubleInput("Дистанция (км): ", 0.1, 100);

                Running running = new Running(name, intensity, distance);
                double calories = running.CalculateCalories();

                Console.WriteLine("Упражнение 'Бег' успешно создано!");
                Console.WriteLine($"Затрачено калорий: {calories:F2}");

                return running;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка при создании упражнения:" +
                                  $" {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Создание упражнения Плавание
        /// </summary>
        /// <returns></returns>
        private static Swimming CreateSwimmingExercise()
        {
            string name = "";
            SwimmingStyle style = SwimmingStyle.Freestyle;
            double distance = 0;

            try
            {
                Console.WriteLine("\nСоздание упражнения 'Плавание'");

                name = GetValidStringInput("Название: ");

                Console.WriteLine("Доступные стили плавания:");
                Console.WriteLine("0 - Freestyle (Вольный стиль)");
                Console.WriteLine("1 - Breaststroke (Брасс)");
                Console.WriteLine("2 - Backstroke (На спине)");
                Console.WriteLine("3 - Butterfly (Баттерфляй)");

                style = GetValidSwimmingStyleInput();
                distance = GetValidDoubleInput("Дистанция (м): ", 1, 10000);

                Swimming swimming = new Swimming(name, style, distance);
                double calories = swimming.CalculateCalories();

                Console.WriteLine("Упражнение 'Плавание' успешно создано!");
                Console.WriteLine($"Затрачено калорий: {calories:F2}");

                return swimming;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка при создании упражнения:" +
                                  $" {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Создание упражнения Жим штанги
        /// </summary>
        /// <returns></returns>
        private static BenchPress CreateBenchPressExercise()
        {
            string name = "";
            double weight = 0;
            int repetitions = 0;

            try
            {
                Console.WriteLine("\nСоздание упражнения 'Жим штанги'");

                name = GetValidStringInput("Название: ");
                weight = GetValidDoubleInput("Вес (кг): ", 1, 300);
                repetitions = GetValidIntInput("Повторения: ", 1, 100);

                BenchPress benchPress = new BenchPress(name, weight, repetitions);
                double calories = benchPress.CalculateCalories();

                Console.WriteLine("Упражнение 'Жим штанги' успешно создано!");
                Console.WriteLine($"Затрачено калорий: {calories:F2}");

                return benchPress;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка при создании упражнения: {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Валидный строковый ввод
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static string GetValidStringInput(string prompt)
        {
            while (true)
            {
                try
                {
                    return ExerciseBase.GetValidStringInput(prompt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите значение снова:");
                }
            }
        }

        /// <summary>
        /// Валидный числовой ввод с плавающей точкой
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
                    return ExerciseBase.GetValidDoubleInput(prompt, min, max);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите значение снова:");
                }
            }
        }

        /// <summary>
        /// Валидный целочисленный ввод
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
                    return ExerciseBase.GetValidIntInput(prompt, min, max);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите значение снова:");
                }
            }
        }

        /// <summary>
        /// Валидный ввод стиля плавания
        /// </summary>
        /// <returns></returns>
        private static SwimmingStyle GetValidSwimmingStyleInput()
        {
            while (true)
            {
                try
                {
                    return ExerciseBase.GetValidSwimmingStyleInput();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите значение снова:");
                }
            }
        }

        //TODO: duplication+

        //TODO: duplications+

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
                Console.WriteLine(exercises[i].ExerciseInfo);
                Console.WriteLine($"Затрачено калорий: {calories:F2}");
            }

            Console.WriteLine($"\nОбщее количество затраченных калорий:" +
                              $" {totalCalories:F2}");
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

            double maxCaloriesForVisualization = GetValidDoubleInput(
                "Введите максимальное значение затраты калорий в день (от 1" +
                " до 10000): ", 1, 10000);

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
            Console.WriteLine($"] {totalCalories:F0} /" +
                 $" {maxCaloriesForVisualization} ккал");

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

        //TODO: RSDN+
        /// <summary>
        /// Задание цветовой гаммы
        /// </summary>
        /// <param name="calories"></param>
        /// <returns></returns>
        private static ConsoleColor GetCaloriesColor(double calories)
        {
            if (calories < 1000)
                return ConsoleColor.Green;
            if (calories < 2800)
                return ConsoleColor.Yellow;
            if (calories < 3500)
                return ConsoleColor.DarkYellow;
            return ConsoleColor.Red;
        }
    }
}