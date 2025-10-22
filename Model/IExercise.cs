namespace Model
{
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
}
