

using System;

namespace Model
{
    /// <summary>
    /// Класс плавание 
    /// </summary>
    public class Swimming : ExerciseBase
    {
        /// <summary>
        /// Стиль плавания
        /// </summary>
        private SwimmingStyle _style;

        /// <summary>
        /// Стиль плавания
        /// </summary>
        private double _distance;

        /// <summary>
        /// Стиль плавания
        /// </summary>
        public SwimmingStyle Style
        {
            get => _style;
            set => _style = value;
        }

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
        /// Получает детальную информацию об упражнении.
        /// </summary>
        public override string ExerciseInfo => $"Плавание: {Name}, Стиль: {Style}, Дистанция: {Distance} м";

        /// <summary>
        /// Создание упражнения "Плавание"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="style"></param>
        /// <param name="distance"></param>
        public Swimming(string name, SwimmingStyle style, double distance):
                        base(name)
        {
            Style = style;
            Distance = distance;
        }

        /// <summary>
        /// Создание упражнения Плавание
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Swimming"/>.</returns>
        public static Swimming CreateSwimmingExercise()
        {
            //TODO: remove+

            Console.WriteLine("\n=== Создание упражнения 'Плавание' ===");

            string name = GetValidStringInput("Название: ", "Название не может" +
                                              " быть пустым");
            SwimmingStyle style = GetValidSwimmingStyleInput();
            double distance = GetValidDoubleInput("Дистанция (м): ", 1, 10000);

            Swimming swimming = new Swimming(name, style, distance);
            double calories = swimming.CalculateCalories();

            //TODO: remove+

            Console.WriteLine("Упражнение 'Плавание' успешно создано!");
            Console.WriteLine($"Затрачено калорий: {calories:F2}");

            return swimming;
        }

        /// <summary>
        /// Расчет затраты калорий на Плавание
        /// </summary>
        /// <returns></returns>
        public override double CalculateCalories()
        {
            double styleCoefficient;

            switch (Style)
            {
                case SwimmingStyle.Freestyle:
                    styleCoefficient = 8.0;
                    break;
                case SwimmingStyle.Breaststroke:
                    styleCoefficient = 10.0;
                    break;
                case SwimmingStyle.Backstroke:
                    styleCoefficient = 7.0;
                    break;
                case SwimmingStyle.Butterfly:
                    styleCoefficient = 12.0;
                    break;
                default:
                    styleCoefficient = 8.0;
                    break;
            }
            return Distance * styleCoefficient;
        }
    }
}