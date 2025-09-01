using System;

namespace Model
{
    /// <summary>
    /// Представляет тип плавательного стиля
    /// </summary>
    public enum SwimmingStyle
    {
        Freestyle,
        Breaststroke,
        Backstroke,
        Butterfly
    }

    /// <summary>
    /// Интерфейс для расчета калорий при физических упражнениях
    /// </summary>
    public interface IExercise
    {
        /// <summary>
        /// Название упражнения
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Рассчитывает количество затраченных калорий
        /// </summary>
        /// <returns>Количество калорий</returns>
        double CalculateCalories();

        /// <summary>
        /// Возвращает детальную информацию об упражнении
        /// </summary>
        /// <returns>Строка с информацией</returns>
        string GetExerciseInfo();
    }

    /// <summary>
    /// Базовый класс 
    /// для всех фигур
    /// </summary>
    public abstract class ExerciseBase : IExercise
    {
        private string _name;

        /// <summary>
        /// Название упражнения
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название упражнения не может быть пустым", nameof(Name));

                if (value.Length > 50)
                    throw new ArgumentException("Название упражнения слишком длинное", nameof(Name));

                _name = value;
            }
        }

        protected ExerciseBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Проверяет, что значение положительное
        /// </summary>
        protected void ValidatePositiveValue(double value, string parameterName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(parameterName, "Значение должно быть положительным");
        }

        /// <summary>
        /// Проверяет, что значение в допустимом диапазоне
        /// </summary>
        protected void ValidateRange(double value, double min, double max, string parameterName)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(parameterName,
                    $"Значение должно быть в диапазоне от {min} до {max}");
        }

        public abstract double CalculateCalories();
        public abstract string GetExerciseInfo();
    }
}
