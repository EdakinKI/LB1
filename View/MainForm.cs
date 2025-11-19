using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

namespace View
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        private BindingList<IExercise> _exercises;
        private List<IExercise> _originalExercises;

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        /// <summary>
        /// Инициализация данных
        /// </summary>
        private void InitializeData()
        {
            _exercises = new BindingList<IExercise>();
            _originalExercises = new List<IExercise>();
            ExerciseDataGridView.DataSource = _exercises;

            ConfigureDataGridView();
            UpdateButtonsState();
        }

        /// <summary>
        /// Настройка DataGridView
        /// </summary>
        private void ConfigureDataGridView()
        {
            ExerciseDataGridView.AutoGenerateColumns = false;
            ExerciseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ExerciseDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExerciseDataGridView.ReadOnly = true;
            ExerciseDataGridView.RowHeadersVisible = false;

            // Очищаем существующие колонки
            ExerciseDataGridView.Columns.Clear();

            // Создаем и настраиваем колонки
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Название";
            nameColumn.Name = "nameColumn";
            nameColumn.ReadOnly = true;
            nameColumn.Width = 150;

            DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn();
            typeColumn.DataPropertyName = "Type";
            typeColumn.HeaderText = "Тип";
            typeColumn.Name = "typeColumn";
            typeColumn.ReadOnly = true;
            typeColumn.Width = 120;

            DataGridViewTextBoxColumn detailsColumn = new DataGridViewTextBoxColumn();
            detailsColumn.DataPropertyName = "ExerciseInfo";
            detailsColumn.HeaderText = "Детали";
            detailsColumn.Name = "detailsColumn";
            detailsColumn.ReadOnly = true;
            detailsColumn.Width = 200;

            DataGridViewTextBoxColumn caloriesColumn = new DataGridViewTextBoxColumn();
            caloriesColumn.DataPropertyName = "Calories";
            caloriesColumn.HeaderText = "Калории";
            caloriesColumn.Name = "caloriesColumn";
            caloriesColumn.ReadOnly = true;
            caloriesColumn.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Format = "F2"
            };
            caloriesColumn.Width = 80;

            // Добавляем колонки в DataGridView
            ExerciseDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
        nameColumn,
        typeColumn,
        detailsColumn,
        caloriesColumn
            });
        }

        /// <summary>
        /// Обновление состояния кнопок
        /// </summary>
        private void UpdateButtonsState()
        {
            ButtonRemove.Enabled = ExerciseDataGridView.SelectedRows.Count > 0;
            ButtonClear.Enabled = _exercises.Count > 0;
        }

        /// <summary>
        /// Блокировка кнопок
        /// </summary>
        private void LockButtons()
        {
            ButtonAdd.Enabled = false;
            ButtonRemove.Enabled = false;
            ButtonClear.Enabled = false;
            ButtonFilter.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Разблокировка кнопок
        /// </summary>
        private void UnlockButtons()
        {
            ButtonAdd.Enabled = true;
            ButtonFilter.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = true;
            UpdateButtonsState();
        }

        /// <summary>
        /// Добавление упражнения в список
        /// </summary>
        public void AddExercise(IExercise exercise)
        {
            if (exercise != null)
            {
                _exercises.Add(exercise);
                _originalExercises.Add(exercise);
                UpdateButtonsState();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить
        /// </summary>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            LockButtons();
            using (var addForm = new AddExerciseForm(this))
            {
                addForm.ShowDialog();
            }
            UnlockButtons();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить
        /// </summary>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (ExerciseDataGridView.SelectedRows.Count > 0)
            {
                var selectedExercise = ExerciseDataGridView.SelectedRows[0].DataBoundItem as IExercise;
                if (selectedExercise != null)
                {
                    var result = MessageBox.Show(
                        $"Вы уверены, что хотите удалить упражнение '{selectedExercise.Name}'?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _exercises.Remove(selectedExercise);
                        _originalExercises.Remove(selectedExercise);
                        UpdateButtonsState();
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить всё
        /// </summary>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (_exercises.Count > 0)
            {
                var result = MessageBox.Show(
                    "Вы уверены, что хотите удалить все упражнения?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _exercises.Clear();
                    _originalExercises.Clear();
                    UpdateButtonsState();
                }
            }
        }

        /// <summary>
        /// Обновление отображаемых упражнений (для фильтрации)
        /// </summary>
        public void UpdateExercises(List<IExercise> exercises)
        {
            _exercises.Clear();
            foreach (var exercise in exercises)
            {
                _exercises.Add(exercise);
            }
            UpdateButtonsState();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Фильтр
        /// </summary>
        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            LockButtons();
            using (var filterForm = new FilterForm(_originalExercises, this))
            {
                filterForm.ShowDialog();
            }
            UnlockButtons();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Сохранить
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_exercises.Count == 0)
            {
                MessageBox.Show(
                    "Нет упражнений для сохранения",
                    "Сохранение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            LockButtons();
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Файлы упражнений (*.exs)|*.exs";
                saveDialog.DefaultExt = "exs";
                saveDialog.Title = "Сохранить упражнения";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveExercises(saveDialog.FileName);
                        MessageBox.Show(
                            "Данные успешно сохранены",
                            "Сохранение завершено",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Ошибка при сохранении: {ex.Message}",
                            "Ошибка сохранения",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            UnlockButtons();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Открыть
        /// </summary>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockButtons();
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Файлы упражнений (*.exs)|*.exs";
                openDialog.DefaultExt = "exs";
                openDialog.Title = "Открыть упражнения";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadExercises(openDialog.FileName);
                        MessageBox.Show(
                            "Данные успешно загружены",
                            "Загрузка завершена",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Ошибка при загрузке: {ex.Message}",
                            "Ошибка загрузки",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            UnlockButtons();
        }

        /// <summary>
        /// Сохранение упражнений в файл
        /// </summary>
        private void SaveExercises(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<ExerciseWrapper>));
            var wrappedExercises = _originalExercises.Select(ex => new ExerciseWrapper(ex)).ToList();

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, wrappedExercises);
            }
        }

        /// <summary>
        /// Загрузка упражнений из файла
        /// </summary>
        private void LoadExercises(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<ExerciseWrapper>));

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var wrappedExercises = (List<ExerciseWrapper>)serializer.Deserialize(stream);
                _exercises.Clear();
                _originalExercises.Clear();

                foreach (var wrapped in wrappedExercises)
                {
                    var exercise = wrapped.GetExercise();
                    _exercises.Add(exercise);
                    _originalExercises.Add(exercise);
                }
            }
            UpdateButtonsState();
        }

        /// <summary>
        /// Обработчик изменения выбранной строки
        /// </summary>
        private void ExerciseDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }
    }

    /// <summary>
    /// Класс-обертка для сериализации упражнений
    /// </summary>
    [Serializable]
    public class ExerciseWrapper
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Intensity { get; set; }
        public double Weight { get; set; }
        public int Repetitions { get; set; }
        public SwimmingStyle Style { get; set; }

        public ExerciseWrapper() { }

        public ExerciseWrapper(IExercise exercise)
        {
            Name = exercise.Name;

            if (exercise is Running running)
            {
                Type = "Running";
                Distance = running.Distance;
                Intensity = running.Intensity;
            }
            else if (exercise is Swimming swimming)
            {
                Type = "Swimming";
                Distance = swimming.Distance;
                Style = swimming.Style;
            }
            else if (exercise is BenchPress benchPress)
            {
                Type = "BenchPress";
                Weight = benchPress.Weight;
                Repetitions = benchPress.Repetitions;
            }
        }

        public IExercise GetExercise()
        {
            switch (Type)
            {
                case "Running":
                    return new Running(Name, Intensity, Distance);
                case "Swimming":
                    return new Swimming(Name, Style, Distance);
                case "BenchPress":
                    return new BenchPress(Name, Weight, Repetitions);
                default:
                    throw new InvalidOperationException("Неизвестный тип упражнения");
            }
        }
    }
}