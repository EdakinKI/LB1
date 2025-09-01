

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

        public BenchPress(string name, double weight, int repetitions) : base(name)
        {
            Weight = weight;
            Repetitions = repetitions;
        }

        public override double CalculateCalories()
        {
            // Формула: калории = вес * повторения * коэффициент 0.5
            return Weight * Repetitions * 0.5;
        }

        public override string GetExerciseInfo()
        {
            return $"Жим штанги: {Name}, Вес: {Weight} кг, Повторения: {Repetitions}";
        }
    }
}
