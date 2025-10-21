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

                int choice = GetValidIntInputWithHandling("Выберите действие (1-4): ", 1, 4);

                switch (choice)
                {
                    case 1:
                        var running = CreateRunningExerciseWithHandling();
                        if (running != null)
                            exercises.Add(running);
                        break;
                    case 2:
                        var swimming = CreateSwimmingExerciseWithHandling();
                        if (swimming != null)
                            exercises.Add(swimming);
                        break;
                    case 3:
                        var benchPress = CreateBenchPressExerciseWithHandling();
                        if (benchPress != null)
                            exercises.Add(benchPress);
                        break;
                    case 4:
                        continueAdding = false;
                        break;
                }

                if (continueAdding && exercises.Count > 0)
                {
                    Console.WriteLine($"\nУпражнений добавлено: {exercises.Count}");
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
        /// Создание упражнения Бег с обработкой ошибок по полям
        /// </summary>
        private static Running CreateRunningExerciseWithHandling()
        {
            string name = "";
            double intensity = 0;
            double distance = 0;

            try
            {
                Console.WriteLine("\n=== Создание упражнения 'Бег' ===");

                // Ввод названия с повторением при ошибке
                name = GetValidStringInputWithRetry("Название: ");

                // Ввод интенсивности с повторением при ошибке
                intensity = GetValidDoubleInputWithRetry("Интенсивность (км/ч): ", 1, 30);

                // Ввод дистанции с повторением при ошибке
                distance = GetValidDoubleInputWithRetry("Дистанция (км): ", 0.1, 100);

                Running running = new Running(name, intensity, distance);
                double calories = running.CalculateCalories();

                Console.WriteLine("Упражнение 'Бег' успешно создано!");
                Console.WriteLine($"Затрачено калорий: {calories:F2}");

                return running;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка при создании упражнения: {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Создание упражнения Плавание с обработкой ошибок по полям
        /// </summary>
        private static Swimming CreateSwimmingExerciseWithHandling()
        {
            string name = "";
            SwimmingStyle style = SwimmingStyle.Freestyle;
            double distance = 0;

            try
            {
                Console.WriteLine("\n=== Создание упражнения 'Плавание' ===");

                name = GetValidStringInputWithRetry("Название: ");

                Console.WriteLine("Доступные стили плавания:");
                Console.WriteLine("0 - Freestyle (Вольный стиль)");
                Console.WriteLine("1 - Breaststroke (Брасс)");
                Console.WriteLine("2 - Backstroke (На спине)");
                Console.WriteLine("3 - Butterfly (Баттерфляй)");

                style = GetValidSwimmingStyleInputWithRetry();
                distance = GetValidDoubleInputWithRetry("Дистанция (м): ", 1, 10000);

                Swimming swimming = new Swimming(name, style, distance);
                double calories = swimming.CalculateCalories();

                Console.WriteLine("Упражнение 'Плавание' успешно создано!");
                Console.WriteLine($"Затрачено калорий: {calories:F2}");

                return swimming;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка при создании упражнения: {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Создание упражнения Жим штанги с обработкой ошибок по полям
        /// </summary>
        private static BenchPress CreateBenchPressExerciseWithHandling()
        {
            string name = "";
            double weight = 0;
            int repetitions = 0;

            try
            {
                Console.WriteLine("\n=== Создание упражнения 'Жим штанги' ===");

                name = GetValidStringInputWithRetry("Название: ");
                weight = GetValidDoubleInputWithRetry("Вес (кг): ", 1, 300);
                repetitions = GetValidIntInputWithRetry("Повторения: ", 1, 100);

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
        /// Валидный строковый ввод с повторением при ошибке
        /// </summary>
        private static string GetValidStringInputWithRetry(string prompt)
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
        /// Валидный числовой ввод с плавающей точкой с повторением при ошибке
        /// </summary>
        private static double GetValidDoubleInputWithRetry(string prompt, double min, double max)
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
        /// Валидный целочисленный ввод с повторением при ошибке
        /// </summary>
        private static int GetValidIntInputWithRetry(string prompt, int min, int max)
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
        /// Валидный ввод стиля плавания с повторением при ошибке
        /// </summary>
        private static SwimmingStyle GetValidSwimmingStyleInputWithRetry()
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

        /// <summary>
        /// Валидный целочисленный ввод для меню
        /// </summary>
        private static int GetValidIntInputWithHandling(string prompt, int min, int max)
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
                    Console.WriteLine("Пожалуйста, попробуйте снова...");
                }
            }
        }

        // Остальные методы (ShowResults, ShowCaloriesVisualization, GetCaloriesColor) остаются без изменений
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

            Console.WriteLine($"\nОбщее количество затраченных калорий: {totalCalories:F2}");
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

            double maxCaloriesForVisualization = GetValidDoubleInputWithRetry(
                "Введите максимальное значение затраты калорий в день (от 1 до 10000): ", 1, 10000);

            int maxBarWidth = 50;
            int barLength = (int)(totalCalories / maxCaloriesForVisualization * maxBarWidth);
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
            Console.WriteLine($"] {totalCalories:F0} / {maxCaloriesForVisualization} ккал");

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