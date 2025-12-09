using System;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма добавления упражнения
    /// </summary>
    public partial class AddExerciseForm : Form
    {
        /// <summary>
        /// Событие, возникающее при создании нового упражнения
        /// </summary>
        public event Action<IExercise> ExerciseCreated;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AddExerciseForm()
        {
            InitializeComponent();
            InitializeForm();
        }

#if !DEBUG
        ButtonCreateRandom.Visible = false;
#endif

        /// <summary>
        /// Первоначальная настройка элементов управления формы
        /// </summary>
        private void InitializeForm()
        {
            //TODO: to const+
            ComboBoxExercise.Items.AddRange(Constants.AllExerciseTypes);
            ComboBoxExercise.SelectedIndex = 0;

            //TODO: to const+
            ComboBoxStyle.Items.AddRange(Constants.AllSwimmingStyles);
            ComboBoxStyle.SelectedIndex = 0;

            LabelIntensityUnit.Text = "км/ч";
            LabelRunningDistanceUnit.Text = "км";
            LabelSwimmingDistanceUnit.Text = "м";
            LabelWeightUnit.Text = "кг";

            UpdateExerciseParameters();
        }

        /// <summary>
        /// Обновление параметров упражнения
        /// </summary>
        private void UpdateExerciseParameters()
        {
            PanelRunning.Visible = false;
            PanelSwimming.Visible = false;
            PanelBenchPress.Visible = false;

            switch (ComboBoxExercise.SelectedItem.ToString())
            {
                case Constants.Running:
                {
                    PanelRunning.Visible = true;
                    break;
                }
                case Constants.Swimming:
                {
                    PanelSwimming.Visible = true;
                    break;
                }
                case Constants.BenchPress:
                {
                    PanelBenchPress.Visible = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Обработчик изменения типа упражнения
        /// </summary>
        /// <param name="Список упражнений"></param>
        /// <param name="Аргумент"></param>
        private void ComboBoxExercise_SelectedIndexChanged(object sender,
                                                           EventArgs e)
        {
            UpdateExerciseParameters();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Создать
        /// </summary>
        /// <param name="Создать"></param>
        /// <param name="Аргумент"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    ExerciseCreated?.Invoke(exercise);

                    TextBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании упражнения: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Закрыть
        /// </summary>
        /// <param name="Закрыть"></param>
        /// <param name="Аргумент"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Создать случайное упражнение
        /// </summary>
        /// <param name="Создать случайное"></param>
        /// <param name="Аргумент"></param>
        private void ButtonCreateRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var random = new Random();
                TextBoxName.Text = $"Упражнение {random.Next(1000)}";

                switch (ComboBoxExercise.SelectedItem.ToString())
                {
                    case Constants.Running:
                    {
                        NumericIntensity.Value = (decimal)(Math.Round(random.
                                                  NextDouble() * 38 + 1, 2));
                        NumericRunningDistance.Value = (decimal)(Math.Round
                                        (random.NextDouble() * 248 + 1, 2));
                        break;
                    }
                    case Constants.Swimming:
                    {
                        ComboBoxStyle.SelectedIndex = random.Next(ComboBoxStyle
                                                                  .Items.Count);
                        NumericSwimmingDistance.Value = (decimal)(Math.Round
                                        (random.NextDouble() * 9998 + 1, 2));
                        break;
                    }
                    case Constants.BenchPress:
                    {
                        NumericWeight.Value = (decimal)(Math.Round(random.
                                                NextDouble() * 298 + 1, 2));
                        NumericRepetitions.Value = random.Next(1, 101);
                        break;
                    }
                }

                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    ExerciseCreated?.Invoke(exercise);

                    TextBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании случайного упражнения: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Валидация введенных данных имени и параметров
        /// </summary>
        /// <returns>Сообщение о неверных данных</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                MessageBox.Show(
                    "Название упражнения не может быть пустым",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }

            if (TextBoxName.Text.Length > 50)
            {
                MessageBox.Show(
                    "Название упражнения слишком длинное (максимум 50 символов)",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }

            switch (ComboBoxExercise.SelectedItem.ToString())
            {
                case Constants.Running:
                {
                    return ValidateRunningInput();
                }
                case Constants.Swimming:
                {
                    return ValidateSwimmingInput();
                }
                case Constants.BenchPress:
                {
                    return ValidateBenchPressInput();
                }
                default:
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Валидация данных для бега
        /// </summary>
        /// <returns>Сообщение о неверных данных</returns>
        private bool ValidateRunningInput()
        {
            if (NumericIntensity.Value < 0.01m || NumericIntensity.Value > 40)
            {
                MessageBox.Show(
                    "Интенсивность должна быть от 0,01 до 40 км/ч",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericIntensity.Focus();
                return false;
            }

            if (NumericRunningDistance.Value < 0.01m || 
                NumericRunningDistance.Value > 250)
            {
                MessageBox.Show(
                    "Дистанция должна быть от 0,01 до 250 км",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericRunningDistance.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Валидация данных для плавания
        /// </summary>
        /// <returns>Сообщение о неверных данных</returns>
        private bool ValidateSwimmingInput()
        {
            if (NumericSwimmingDistance.Value < 1 ||
                NumericSwimmingDistance.Value > 10000)
            {
                MessageBox.Show(
                    "Дистанция должна быть от 1 до 10000 метров",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericSwimmingDistance.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Валидация данных для жима штанги
        /// </summary>
        /// <returns>Сообщение о неверных данных</returns>
        private bool ValidateBenchPressInput()
        {
            if (NumericWeight.Value < 1 || NumericWeight.Value > 300)
            {
                MessageBox.Show(
                    "Вес должен быть от 1 до 300 кг",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericWeight.Focus();
                return false;
            }

            if (NumericRepetitions.Value < 1 ||
                NumericRepetitions.Value > 100)
            {
                MessageBox.Show(
                    "Количество повторений должно быть от 1 до 100",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericRepetitions.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Создание упражнения
        /// </summary>
        /// <returns>Упражнение</returns>
        /// <exception cref="Исключение при неизвестном упражнении">
        /// </exception>
        private IExercise CreateExercise()
        {
            string name = TextBoxName.Text.Trim();
            string exerciseType = ComboBoxExercise.SelectedItem.ToString();

            switch (exerciseType)
            {
                case Constants.Running:
                {
                    return new Running(
                        name,
                        (double)NumericIntensity.Value,
                        (double)NumericRunningDistance.Value);
                }

                case Constants.Swimming:
                {
                    SwimmingStyle style;
                    string styleString = ComboBoxStyle.SelectedItem.ToString();

                    switch (styleString)
                    {
                        case Constants.Freestyle:
                        {
                            style = SwimmingStyle.Freestyle;
                            break;
                        }
                        case Constants.Breaststroke:
                        {
                            style = SwimmingStyle.Breaststroke;
                            break;
                        }
                        case Constants.Backstroke:
                        {
                            style = SwimmingStyle.Backstroke;
                            break;
                        }
                        case Constants.Butterfly:
                        {
                            style = SwimmingStyle.Butterfly;
                            break;
                        }
                        default:
                        {
                            style = SwimmingStyle.Freestyle;
                            break;
                        }
                    }

                    return new Swimming(
                        name, 
                        style,
                        (double)NumericSwimmingDistance.Value);
                }

                case Constants.BenchPress:
                {
                    return new BenchPress(
                        name,
                        (double)NumericWeight.Value,
                        (int)NumericRepetitions.Value);
                }

                default:
                {
                    throw new InvalidOperationException
                            ("Неизвестный тип упражнения");
                }
            }
        }
    }
}