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
        //TODO: XML
        private BindingList<IExercise> _exercises;

        //TODO: XML
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
        /// Настройка таблицы упражнений
        /// </summary>
        private void ConfigureDataGridView()
        {
            ExerciseDataGridView.AutoGenerateColumns = false;
            ExerciseDataGridView.AutoSizeColumnsMode = 
                        DataGridViewAutoSizeColumnsMode.Fill;
            ExerciseDataGridView.SelectionMode = 
                     DataGridViewSelectionMode.FullRowSelect;
            ExerciseDataGridView.ReadOnly = true;
            ExerciseDataGridView.RowHeadersVisible = false;
            ExerciseDataGridView.Columns.Clear();

            DataGridViewTextBoxColumn nameColumn = new 
                                 DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Название";
            nameColumn.Name = "nameColumn";
            nameColumn.ReadOnly = true;
            nameColumn.Width = 150;

            DataGridViewTextBoxColumn typeColumn = new 
                                 DataGridViewTextBoxColumn();
            typeColumn.DataPropertyName = "Type";
            typeColumn.HeaderText = "Тип";
            typeColumn.Name = "typeColumn";
            typeColumn.ReadOnly = true;
            typeColumn.Width = 120;

            DataGridViewTextBoxColumn detailsColumn = new 
                                 DataGridViewTextBoxColumn();
            detailsColumn.DataPropertyName = "ExerciseInfo";
            detailsColumn.HeaderText = "Детали";
            detailsColumn.Name = "detailsColumn";
            detailsColumn.ReadOnly = true;
            detailsColumn.Width = 200;

            DataGridViewTextBoxColumn caloriesColumn = new 
                                 DataGridViewTextBoxColumn();
            caloriesColumn.DataPropertyName = "Calories";
            caloriesColumn.HeaderText = "Калории";
            caloriesColumn.Name = "caloriesColumn";
            caloriesColumn.ReadOnly = true;
            caloriesColumn.DefaultCellStyle = new DataGridViewCellStyle()
            {
                Format = "F2"
            };
            caloriesColumn.Width = 80;

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

        //TODO: incapsulation
        /// <summary>
        /// Добавление упражнения в список
        /// </summary>
        /// <param name="Упражнение для добавления"></param>
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
        /// <param name="Добавить"></param>
        /// <param name="Аргумент"></param>
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
        /// <param name="Удалить"></param>
        /// <param name="Аргумент"></param>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            var selectedExercise = ExerciseDataGridView.SelectedRows[0].
                                   DataBoundItem as IExercise;
            if (ExerciseDataGridView.SelectedRows.Count > 0)
            { 
                if (selectedExercise != null)
                {
                    var result = MessageBox.Show(
                        $"Вы уверены, что хотите удалить упражнение '" +
                        $"{selectedExercise.Name}'?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

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
        /// <param name="Удалить всё"></param>
        /// <param name="Аргумент"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (_exercises.Count > 0)
            {
                var result = MessageBox.Show(
                    "Вы уверены, что хотите удалить все упражнения?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    _exercises.Clear();
                    _originalExercises.Clear();
                    UpdateButtonsState();
                }
            }
        }

        //TODO: incapsulation
        /// <summary>
        /// Обновление отображаемых упражнений для фильтрации
        /// </summary>
        /// <param name="Новый список упражнений для отображения"></param>
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
        /// <param name="Фильтр"></param>
        /// <param name="Аргумент"></param>
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
        /// <param name="Сохранить"></param>
        /// <param name="Аргумент"></param>
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
        /// <param name="Открыть"></param>
        /// <param name="Аргумент"></param>
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
        /// <param name="Имя файла для сохранения"></param>
        private void SaveExercises(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<ExerciseWrapper>));
            var wrappedExercises = _originalExercises.Select(ex => new 
                                   ExerciseWrapper(ex)).ToList();

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, wrappedExercises);
            }
        }

        /// <summary>
        /// Загрузка упражнений из файла
        /// </summary>
        /// <param name="Имя файла для загрузки"></param>
        private void LoadExercises(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<ExerciseWrapper>));

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var wrappedExercises = (List<ExerciseWrapper>)serializer.
                                        Deserialize(stream);
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
        /// <param name="Выбранная строка"></param>
        /// <param name="Аргумент"></param>
        private void ExerciseDataGridView_SelectionChanged(object sender, 
                                                           EventArgs e)
        {
            UpdateButtonsState();
        }
    }

    //TODO: remove
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
                //TOOD: refactor
                Type = nameof(Running);
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
                //TODO: duplication
                case "Running":
                {
                    return new Running(Name, Intensity, Distance);
                }
                case "Swimming":
                {
                    return new Swimming(Name, Style, Distance);
                }
                case "BenchPress":
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