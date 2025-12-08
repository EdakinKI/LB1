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
        /// Тип упражнения
        /// </summary>
        public override string Type => "Бег";

        /// <summary>
        /// Пройденное расстояние
        /// </summary>
        public double Distance
        {
            get => _distance;
            set
            {
                ValidateRange(value, 1, 250, nameof(Distance));
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
                ValidateRange(value, 1, 40, nameof(Intensity));
                _intensity = value;
            }
        }

        /// <summary>
        /// Детальная информация об упражнении
        /// </summary>
        public override string ExerciseInfo => $"Интенсивность:" +
                                $" {Intensity} км/ч, Дистанция: {Distance} км";

        /// <summary>
        /// Создание упражнения Бег
        /// </summary>
        /// <param name="название упражнения"></param>
        /// <param name="интенсивность бега"></param>
        /// <param name="дистанция бега"></param>
        public Running(string name, double intensity, double distance):
                       base(name)
        {
            Intensity = intensity;
            Distance = distance;
        }

        /// <summary>
        /// Расчет затраты калорий на Бег
        /// </summary>
        /// <returns>Рассчитанное значений калорий для Бега</returns>
        public override double CalculateCalories()
        {
            return Distance * Intensity * 60;
        }
    }
}