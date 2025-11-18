namespace Model
{
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
        /// Тип упражнения
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Рассчитанные калории
        /// </summary>
        double Calories { get; }

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
}