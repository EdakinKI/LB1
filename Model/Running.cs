using System;

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
        /// Получает детальную информацию об упражнении.
        /// </summary>
        public override string ExerciseInfo => $"Бег: {Name}, Интенсивность: {Intensity} км/ч, Дистанция: {Distance} км";

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
        /// Создание упражнения Бег
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Running"/>.</returns>
        public static Running CreateRunningExercise()
        {
            //TODO: remove+
            Console.WriteLine("\n=== Создание упражнения 'Бег' ===");

            string name = GetValidStringInput("Название: ", "Название не может" +
                                              " быть пустым");
            double intensity = GetValidDoubleInput("Интенсивность (км/ч): ",
                                                   1, 30);
            double distance = GetValidDoubleInput("Дистанция (км): ",
                                                   0.1, 100);

            Running running = new Running(name, intensity, distance);
            double calories = running.CalculateCalories();

            //TODO: remove+

            Console.WriteLine("Упражнение 'Бег' успешно создано!");
            Console.WriteLine($"Затрачено калорий: {calories:F2}");

            return running;
        }

        /// <summary>
        /// Расчет затраты калорий на Бег
        /// </summary>
        /// <returns></returns>
        public override double CalculateCalories()
        {
            return Distance * Intensity * 60;
        }
    }
}