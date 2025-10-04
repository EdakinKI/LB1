using System;

namespace Model
{
    /// <summary>
    /// Представляет тип плавательного стиля.
    /// </summary>
    public enum SwimmingStyle
    {
        /// <summary>
        /// Вольный стиль.
        /// </summary>
        Freestyle,

        /// <summary>
        /// Брасс.
        /// </summary>
        Breaststroke,

        /// <summary>
        /// Плавание на спине.
        /// </summary>
        Backstroke,

        /// <summary>
        /// Баттерфляй.
        /// </summary>
        Butterfly
    }

    /// <summary>
    /// Интерфейс для расчета калорий при физических упражнениях.
    /// </summary>
    public interface IExercise
    {
        /// <summary>
        /// Получает название упражнения.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Рассчитывает количество затраченных калорий.
        /// </summary>
        /// <returns>Количество калорий.</returns>
        double CalculateCalories();

        /// <summary>
        /// Возвращает детальную информацию об упражнении.
        /// </summary>
        /// <returns>Строка с информацией.</returns>
        string GetExerciseInfo();
    }

    /// <summary>
    /// Базовый класс для всех упражнений.
    /// </summary>
    public abstract class ExerciseBase : IExercise
    {
        private string _name;

        /// <summary>
        /// Получает или задает название упражнения.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название упражнения не может быть пустым", nameof(Name));
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Название упражнения слишком длинное", nameof(Name));
                }

                _name = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ExerciseBase"/>.
        /// </summary>
        /// <param name="name">Название упражнения.</param>
        protected ExerciseBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Проверяет, что значение положительное.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="parameterName">Имя параметра.</param>
        protected void ValidatePositiveValue(double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Значение должно быть положительным");
            }
        }

        /// <summary>
        /// Проверяет, что значение в допустимом диапазоне.
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <param name="parameterName">Имя параметра.</param>
        protected void ValidateRange(double value, double min, double max, string parameterName)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(parameterName, $"Значение должно быть в диапазоне от {min} до {max}");
            }
        }

        /// <summary>
        /// Создает упражнение "Бег".
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Running"/>.</returns>
        public static Running CreateRunningExercise()
        {
            Console.WriteLine("\n=== Создание упражнения 'Бег' ===");

            string name = GetValidStringInput("Название: ", "Название не может быть пустым");
            double intensity = GetValidDoubleInput("Интенсивность (км/ч): ", 1, 30);
            double distance = GetValidDoubleInput("Дистанция (км): ", 0.1, 100);

            Running running = new Running(name, intensity, distance);
            double calories = running.CalculateCalories();

            Console.WriteLine("Упражнение 'Бег' успешно создано!");
            Console.WriteLine($"Затрачено калорий: {calories:F2}");

            return running;
        }

        /// <summary>
        /// Создает упражнение "Плавание".
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Swimming"/>.</returns>
        public static Swimming CreateSwimmingExercise()
        {
            Console.WriteLine("\n=== Создание упражнения 'Плавание' ===");

            string name = GetValidStringInput("Название: ", "Название не может быть пустым");
            SwimmingStyle style = GetValidSwimmingStyleInput();
            double distance = GetValidDoubleInput("Дистанция (м): ", 1, 10000);

            Swimming swimming = new Swimming(name, style, distance);
            double calories = swimming.CalculateCalories();

            Console.WriteLine("Упражнение 'Плавание' успешно создано!");
            Console.WriteLine($"Затрачено калорий: {calories:F2}");

            return swimming;
        }

        /// <summary>
        /// Создает упражнение "Жим штанги".
        /// </summary>
        /// <returns>Экземпляр класса <see cref="BenchPress"/>.</returns>
        public static BenchPress CreateBenchPressExercise()
        {
            Console.WriteLine("\n=== Создание упражнения 'Жим штанги' ===");

            string name = GetValidStringInput("Название: ", "Название не может быть пустым");
            double weight = GetValidDoubleInput("Вес (кг): ", 1, 300);
            int repetitions = GetValidIntInput("Повторения: ", 1, 100);

            BenchPress benchPress = new BenchPress(name, weight, repetitions);
            double calories = benchPress.CalculateCalories();

            Console.WriteLine("Упражнение 'Жим штанги' успешно создано!");
            Console.WriteLine($"Затрачено калорий: {calories:F2}");

            return benchPress;
        }

        /// <summary>
        /// Получает валидный строковый ввод от пользователя.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        /// <returns>Валидная строка.</returns>
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

        /// <summary>
        /// Получает валидный числовой ввод с плавающей точкой от пользователя.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <returns>Валидное число с плавающей точкой.</returns>
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

        /// <summary>
        /// Получает валидный целочисленный ввод от пользователя.
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <returns>Валидное целое число.</returns>
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

        /// <summary>
        /// Получает валидный ввод стиля плавания от пользователя.
        /// </summary>
        /// <returns>Валидный стиль плавания.</returns>
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

        /// <inheritdoc/>
        public abstract double CalculateCalories();

        /// <inheritdoc/>
        public abstract string GetExerciseInfo();
    }
}