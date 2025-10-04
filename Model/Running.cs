namespace Model
{
    /// <summary>
    /// Класс бег 
    /// </summary>
    public class Running : ExerciseBase
    {
        /// <summary>
        /// Пройденное расстояние
        /// </summary>
        private double _distance;

        /// <summary>
        /// Интенсивность бега
        /// </summary>
        private double _intensity;

        /// <summary>
        /// Пройденное расстояние
        /// </summary>
        public double Distance
        {
            get => _distance;
            set
            {
                ValidatePositiveValue(value, nameof(Distance));
                _distance = value;
            }
        }

        /// <summary>
        /// Интенсивность бега
        /// </summary>
        public double Intensity
        {
            get => _intensity;
            set
            {
                ValidateRange(value, 1, 30, nameof(Intensity));
                _intensity = value;
            }
        }

        /// <summary>
        /// Создание упражнения Бег
        /// </summary>
        /// <param name="name"></param>
        /// <param name="intensity"></param>
        /// <param name="distance"></param>
        public Running(string name, double intensity, double distance):
                       base(name)
        {
            Intensity = intensity;
            Distance = distance;
        }

        /// <summary>
        /// Расчет затраты калорий на Бег
        /// </summary>
        /// <returns></returns>
        public override double CalculateCalories()
        {
            return Distance * Intensity * 60;
        }

        public override string GetExerciseInfo()
        {
            return $"Бег: {Name}, Интенсивность: {Intensity} км/ч, Дистанция:" +
                   $" {Distance} км";
        }
    }
}