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
        private MainForm _mainForm;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="Главная форма приложения"></param>
        public AddExerciseForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            InitializeForm();

#if !DEBUG
        ButtonCreateRandom.Visible = false;
#endif
        }

        /// <summary>
        /// Первоначальная настройка элементов управления формы
        /// </summary>
        private void InitializeForm()
        {
            ComboBoxExercise.Items.AddRange(new string[] { "Бег", "Плавание",
                                                           "Жим штанги" });
            ComboBoxExercise.SelectedIndex = 0;

            ComboBoxStyle.Items.AddRange(new string[] { "Freestyle", 
                        "Breaststroke", "Backstroke", "Butterfly" });
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
                case "Бег":
                {
                    PanelRunning.Visible = true;
                    break;
                }
                case "Плавание":
                {
                    PanelSwimming.Visible = true;
                    break;
                }
                case "Жим штанги":
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
                    _mainForm.AddExercise(exercise);

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
                    case "Бег":
                    {
                        NumericIntensity.Value = random.Next(5, 15);
                        NumericRunningDistance.Value = (decimal)(Math.Round
                                         (random.NextDouble() * 10 + 1, 2));
                        break;
                    }
                    case "Плавание":
                    {
                        ComboBoxStyle.SelectedIndex = random.Next(ComboBoxStyle.
                                                                    Items.Count);
                        NumericSwimmingDistance.Value = random.Next(100, 2000);
                        break;
                    }
                    case "Жим штанги":
                    {
                        NumericWeight.Value = random.Next(20, 100);
                        NumericRepetitions.Value = random.Next(5, 20);
                        break;
                    }
                }

                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    _mainForm.AddExercise(exercise);

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
                case "Бег":
                {
                    return ValidateRunningInput();
                }
                case "Плавание":
                {
                    return ValidateSwimmingInput();
                }
                case "Жим штанги":
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
            if (NumericIntensity.Value < 1 || NumericIntensity.Value > 30)
            {
                MessageBox.Show(
                    "Интенсивность должна быть от 1 до 30 км/ч",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericIntensity.Focus();
                return false;
            }

            if (NumericRunningDistance.Value < 0.1m || 
                NumericRunningDistance.Value > 100)
            {
                MessageBox.Show(
                    "Дистанция должна быть от 0.1 до 100 км",
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
        /// <exception cref="Исключение при неизвестном упражнении"></exception>
        private IExercise CreateExercise()
        {
            string name = TextBoxName.Text.Trim();
            string exerciseType = ComboBoxExercise.SelectedItem.ToString();

            switch (exerciseType)
            {
                case "Бег":
                {
                    return new Running(
                    name,
                    (double)NumericIntensity.Value,
                    (double)NumericRunningDistance.Value);
                }

                case "Плавание":
                {
                    SwimmingStyle style;
                    string styleString = ComboBoxStyle.SelectedItem.ToString();

                    switch (styleString)
                    {
                        case "Freestyle":
                        {
                            style = SwimmingStyle.Freestyle;
                            break;
                        }
                        case "Breaststroke":
                        {
                            style = SwimmingStyle.Breaststroke;
                            break;
                        }
                        case "Backstroke":
                        {
                            style = SwimmingStyle.Backstroke;
                            break;
                        }
                        case "Butterfly":
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

                case "Жим штанги":
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