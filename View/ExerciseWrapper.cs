using Model;
using System;

namespace View
{
    //TODO: remove+
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
        /// Инициализация новго экземпляра класса
        /// </summary>
        /// <param name="Исходное упражнение для обертывания"></param>
        public ExerciseWrapper(IExercise exercise)
        {
            Name = exercise.Name;

            if (exercise is Running running)
            {
                //TOOD: refactor+
                Type = nameof(Running);
                Distance = running.Distance;
                Intensity = running.Intensity;
            }
            else if (exercise is Swimming swimming)
            {
                Type = nameof(Swimming);
                Distance = swimming.Distance;
                Style = swimming.Style;
            }
            else if (exercise is BenchPress benchPress)
            {
                Type = nameof(BenchPress);
                Weight = benchPress.Weight;
                Repetitions = benchPress.Repetitions;
            }
        }

        /// <summary>
        /// Восстановление объекта упражнения из обертки
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Исключение при неизвестном типе упражнения">
        /// </exception>
        public IExercise GetExercise()
        {
            switch (Type)
            {
                //TODO: duplication+
                case nameof(Running):
                {
                    return new Running(Name, Intensity, Distance);
                }
                case nameof(Swimming):
                {
                    return new Swimming(Name, Style, Distance);
                }
                case nameof(BenchPress):
                {
                    return new BenchPress(Name, Weight, Repetitions);
                }
                default:
                {
                    throw new InvalidOperationException("Неизвестный тип " +
                                                        "упражнения");
                }
            }
        }
    }
}
