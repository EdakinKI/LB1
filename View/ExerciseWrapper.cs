using Model;
using System;

namespace View
{
    /// <summary>
    /// Класс-обертка для сериализации упражнений
    /// </summary>
    [Serializable]
    public class ExerciseWrapper
    {
        /// <summary>
        /// Тип упражнения
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название упражнения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дистанция упражнения Бег и Плавание
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Интенсивность упражнения Бег
        /// </summary>
        public double Intensity { get; set; }

        /// <summary>
        /// Вес упражнения Жим штанги
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Количество повторений упражнения Жим штанги
        /// </summary>
        public int Repetitions { get; set; }

        /// <summary>
        /// Стиль плавания упражнения Плавание
        /// </summary>
        public SwimmingStyle Style { get; set; }

        /// <summary>
        /// Пустой конструктор для XML сериализации
        /// </summary>
        private ExerciseWrapper() { }

        /// <summary>
        /// Инициализация нового экземпляра класса
        /// </summary>
        /// <param name="Исходное упражнение для обертывания"></param>
        public ExerciseWrapper(IExercise exercise)
        {
            Name = exercise.Name;

            if (exercise is Running running)
            {
                Type = Constants.Running;
                Distance = running.Distance;
                Intensity = running.Intensity;
            }
            else if (exercise is Swimming swimming)
            {
                Type = Constants.Swimming;
                Distance = swimming.Distance;
                Style = swimming.Style;
            }
            else if (exercise is BenchPress benchPress)
            {
                Type = Constants.BenchPress;
                Weight = benchPress.Weight;
                Repetitions = benchPress.Repetitions;
            }
        }

        /// <summary>
        /// Отображение Дистанции при сериализации
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeDistance() => Type == Constants.Running ||
                                                 Type == Constants.Swimming;
        /// <summary>
        /// Отображение Интенсивность при сериализации
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeIntensity() => Type == Constants.Running;
        /// <summary>
        /// Отображение Веса штанги при сериализации
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeWeight() => Type == Constants.BenchPress;
        /// <summary>
        /// Отображение Количества повторений при сериализации
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeRepetitions() => Type == Constants.BenchPress;
        /// <summary>
        /// Отображение Стиля плавания при сериализации
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeStyle() => Type == Constants.Swimming;

        /// <summary>
        /// Восстановление объекта упражнения из обертки
        /// </summary>
        /// <returns>Восстановленный объект упражнения</returns>
        /// <exception cref="Исключение при неизвестном типе упражнения"
        /// ></exception>
        public IExercise GetExercise()
        {
            switch (Type)
            {
                case Constants.Running:
                { 
                    return new Running(Name, Intensity, Distance);
                }
                case Constants.Swimming:
                {
                    return new Swimming(Name, Style, Distance);
                }
                case Constants.BenchPress:
                {
                    return new BenchPress(Name, Weight, Repetitions);
                }
                default:
                {
                    throw new InvalidOperationException("Неизвестный тип упражнения");
                }
            }
        }
    }
}