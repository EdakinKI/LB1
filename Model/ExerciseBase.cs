using System;

namespace Model
{
    //TODO: RSDN+
    /// <summary>
    /// Тип плавательного стиля
    /// </summary>
    public enum SwimmingStyle
    {
        /// <summary>
        /// Вольный стиль
        /// </summary>
        Freestyle,

        /// <summary>
        /// Брасс
        /// </summary>
        Breaststroke,

        /// <summary>
        /// Плавание на спине
        /// </summary>
        Backstroke,

        /// <summary>
        /// Баттерфляй
        /// </summary>
        Butterfly
    }

    //TODO: RSDN+
    /// <summary>
    /// Интерфейс расчета калорий
    /// </summary>
    public interface IExercise
    {
        /// <summary>
        /// Название упражнения
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Рассчет количества затраченных калорий
        /// </summary>
        /// <returns>Количество калорий.</returns>
        double CalculateCalories();

        /// <summary>
        /// Информация об упражнении
        /// </summary>
        /// <returns>Строка с информацией.</returns>
        string ExerciseInfo { get; }
    }


    /// <summary>
    /// Базовый класс для всех упражнений
    /// </summary>
    public abstract class ExerciseBase : IExercise
    {
        private string _name;

        //TODO: property+
        /// <summary>
        /// Детальная информация об упражнении
        /// </summary>
        public abstract string ExerciseInfo { get; }

        /// <summary>
        /// Название упражнения
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название упражнения не может" +
                                                " быть пустым", nameof(Name));
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Название упражнения слишком" +
                                                " длинное", nameof(Name));
                }

                _name = value;
            }
        }

        /// <summary>
        /// Инициализация нового экземпляра класса <see cref="ExerciseBase"/>
        /// </summary>
        /// <param name="name">Название упражнения.</param>
        protected ExerciseBase(string name)
        {
            Name = name;
        }

        //TODO: remove+

        //TODO: remove+

        //TODO: remove+

        //TODO: remove+

        /// <summary>
        /// Проверка положительности значения
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="parameterName">Имя параметра.</param>
        protected void ValidatePositiveValue(double value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Значение" +
                    "                                должно быть положительным");
            }
        }

        /// <summary>
        /// Проверка диапазона значения
        /// </summary>
        /// <param name="value">Проверяемое значение.</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <param name="parameterName">Имя параметра.</param>
        protected void ValidateRange(double value, double min, double max,
                                     string parameterName)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(parameterName,
                    $"Значение должно быть в диапазоне от {min} до {max}");
            }
        }

        /// <summary>
        /// Валидный строковый ввод от пользователя
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <returns>Валидная строка.</returns>
        public static string GetValidStringInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Название не может быть" +
                            "                        пустым");
                    }

                    if (input.Length > 50)
                    {
                        throw new ArgumentException("Название слишком длинное" +
                                                    "(макс. 50 символов)");
                    }

                    return input;
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException($"Ошибка ввода: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Валидный числовой ввод с плавающей точкой от пользователя
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <returns>Валидное число с плавающей точкой.</returns>
        public static double GetValidDoubleInput(string prompt, double min,
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
                        throw new ArgumentOutOfRangeException($"Значение должно" +
                                                        $" быть от {min} до {max}");
                    }

                    return value;
                }
                catch (Exception ex) when (ex is FormatException || ex is
                                           ArgumentOutOfRangeException)
                {
                    throw new Exception($"Ошибка ввода: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Валидный целочисленный ввод от пользователя
        /// </summary>
        /// <param name="prompt">Приглашение для ввода.</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <returns>Валидное целое число.</returns>
        public static int GetValidIntInput(string prompt, int min, int max)
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
                        throw new ArgumentOutOfRangeException($"Значение должно" +
                                                      $" быть от {min} до {max}");
                    }

                    return value;
                }
                catch (Exception ex) when (ex is FormatException || ex is
                                           ArgumentOutOfRangeException)
                {
                    throw new Exception($"Ошибка ввода: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Валидный ввод стиля Плавания от пользователя
        /// </summary>
        /// <returns>Валидный стиль плавания.</returns>
        public static SwimmingStyle GetValidSwimmingStyleInput()
        {
            while (true)
            {
                try
                {
                    Console.Write("Выберите стиль (0-3): ");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int styleValue))
                    {
                        throw new FormatException("Неверный формат числа");
                    }

                    if (!Enum.IsDefined(typeof(SwimmingStyle), styleValue))
                    {
                        throw new ArgumentOutOfRangeException("Неверное значение" +
                                                " стиля. Введите число от 0 до 3.");
                    }

                    return (SwimmingStyle)styleValue;
                }
                catch (Exception ex) when (ex is FormatException || ex is
                                           ArgumentOutOfRangeException)
                {
                    throw new Exception($"Ошибка ввода: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Подсчет калорий
        /// </summary>
        /// <returns></returns>
        public abstract double CalculateCalories();
    }
}