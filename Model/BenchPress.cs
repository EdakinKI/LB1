namespace Model
{
    /// <summary>
    /// Класс жим штанги 
    /// </summary>
    public class BenchPress : ExerciseBase
    {
        /// <summary>
        /// Вес штанги
        /// </summary>
        private double _weight;

        /// <summary>
        /// Количество повторений
        /// </summary>
        private int _repetitions;

        /// <summary>
        /// Тип упражнения
        /// </summary>
        public override string Type => "Жим штанги";

        /// <summary>
        /// Вес штанги
        /// </summary>
        public double Weight
        {
            get => _weight;
            set
            {
                ValidateRange(value, 1, 300, nameof(Weight));
                _weight = value;
            }
        }

        /// <summary>
        /// Количество повторений
        /// </summary>
        public int Repetitions
        {
            get => _repetitions;
            set
            {
                ValidateRange(value, 1, 100, nameof(Repetitions));
                _repetitions = value;
            }
        }

        /// <summary>
        /// Детальная информация об упражнении
        /// </summary>
        public override string ExerciseInfo => $"Жим штанги: {Name}," +
                        $" Вес: {Weight} кг, Повторения: {Repetitions}";

        /// <summary>
        /// Создание упражнения Жим штанги
        /// </summary>
        /// <param name="название упражнения"></param>
        /// <param name="вес штанги"></param>
        /// <param name="количество повторений"></param>
        public BenchPress(string name, double weight, int repetitions):
                          base(name)
        {
            Weight = weight;
            Repetitions = repetitions;
        }

        /// <summary>
        /// Расчет затраты калорий на Жим штанги
        /// </summary>
        /// <returns>Рассчитанное значений калорий для Жима штанги</returns>
        public override double CalculateCalories()
        {
            return Weight * Repetitions * 0.5;
        }
    }
}
