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
        public AddExerciseForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Заполнение ComboBox типами упражнений
            ComboBoxExercise.Items.AddRange(new string[] { "Бег", "Плавание", "Жим штанги" });
            ComboBoxExercise.SelectedIndex = 0;

            // Заполнение ComboBox стилями плавания
            ComboBoxStyle.Items.AddRange(new string[] { "Freestyle", "Breaststroke", "Backstroke", "Butterfly" });
            ComboBoxStyle.SelectedIndex = 0;

            // Установка единиц измерения
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
            // Скрыть все панели параметров
            PanelRunning.Visible = false;
            PanelSwimming.Visible = false;
            PanelBenchPress.Visible = false;

            // Показать нужную панель
            switch (ComboBoxExercise.SelectedItem.ToString())
            {
                case "Бег":
                    PanelRunning.Visible = true;
                    break;
                case "Плавание":
                    PanelSwimming.Visible = true;
                    break;
                case "Жим штанги":
                    PanelBenchPress.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Обработчик изменения типа упражнения
        /// </summary>
        private void ComboBoxExercise_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExerciseParameters();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Создать
        /// </summary>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    _mainForm.AddExercise(exercise);

                    MessageBox.Show(
                        "Упражнение успешно создано!",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Очистка полей для следующего ввода
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
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Создать случайное упражнение
        /// </summary>
        private void ButtonCreateRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var random = new Random();
                TextBoxName.Text = $"Упражнение {random.Next(1000)}";

                switch (ComboBoxExercise.SelectedItem.ToString())
                {
                    case "Бег":
                        NumericIntensity.Value = random.Next(5, 15);
                        NumericRunningDistance.Value = (decimal)(random.NextDouble() * 10 + 1);
                        break;
                    case "Плавание":
                        ComboBoxStyle.SelectedIndex = random.Next(ComboBoxStyle.Items.Count);
                        NumericSwimmingDistance.Value = random.Next(100, 2000);
                        break;
                    case "Жим штанги":
                        NumericWeight.Value = random.Next(20, 100);
                        NumericRepetitions.Value = random.Next(5, 20);
                        break;
                }

                // Автоматически создаем упражнение после заполнения случайными данными
                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    _mainForm.AddExercise(exercise);

                    MessageBox.Show(
                        "Случайное упражнение успешно создано!",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

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
        /// Валидация введенных данных
        /// </summary>
        private bool ValidateInput()
        {
            // Валидация названия
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

            // Валидация для конкретных типов упражнений
            switch (ComboBoxExercise.SelectedItem.ToString())
            {
                case "Бег":
                    return ValidateRunningInput();
                case "Плавание":
                    return ValidateSwimmingInput();
                case "Жим штанги":
                    return ValidateBenchPressInput();
                default:
                    return false;
            }
        }

        /// <summary>
        /// Валидация данных для бега
        /// </summary>
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

            if (NumericRunningDistance.Value < 0.1m || NumericRunningDistance.Value > 100)
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
        private bool ValidateSwimmingInput()
        {
            if (NumericSwimmingDistance.Value < 1 || NumericSwimmingDistance.Value > 10000)
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

            if (NumericRepetitions.Value < 1 || NumericRepetitions.Value > 100)
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

        //TODO у case нет {} и return првоерить
        /// <summary>
        /// Создание упражнения
        /// </summary>
        private IExercise CreateExercise()
        {
            string name = TextBoxName.Text.Trim();
            string exerciseType = ComboBoxExercise.SelectedItem.ToString();

            switch (exerciseType)
            {
                case "Бег":
                    return new Running(
                        name,
                        (double)NumericIntensity.Value,
                        (double)NumericRunningDistance.Value);

                case "Плавание":
                    SwimmingStyle style;
                    string styleString = ComboBoxStyle.SelectedItem.ToString();

                    switch (styleString)
                    {
                        case "Freestyle":
                            style = SwimmingStyle.Freestyle;
                            break;
                        case "Breaststroke":
                            style = SwimmingStyle.Breaststroke;
                            break;
                        case "Backstroke":
                            style = SwimmingStyle.Backstroke;
                            break;
                        case "Butterfly":
                            style = SwimmingStyle.Butterfly;
                            break;
                        default:
                            style = SwimmingStyle.Freestyle;
                            break;
                    }

                    return new Swimming(name, style, (double)NumericSwimmingDistance.Value);

                case "Жим штанги":
                    return new BenchPress(
                        name,
                        (double)NumericWeight.Value,
                        (int)NumericRepetitions.Value);

                default:
                    throw new InvalidOperationException("Неизвестный тип упражнения");
            }
        }
    }
}