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
        /// <summary>
        /// Коллекция упражнений для отображения в DataGridView
        /// </summary>
        private BindingList<IExercise> _exercises;

        /// <summary>
        /// Исходная коллекция упражнений для восстановления после фильтрации
        /// </summary>
        private List<IExercise> _originalExercises;

        /// <summary>
        /// Ссылка на открытую форму добавления упражнения
        /// </summary>
        private AddForm _addForm;

        /// <summary>
        /// Ссылка на открытую форму фильтрации
        /// </summary>
        private FilterForm _filterForm;

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
        /// Внутренний метод для добавления упражнения
        /// </summary>
        /// <param name="Упражнение для добавления"></param>
        private void AddExerciseInternal(IExercise exercise)
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
            if (_addForm != null && !_addForm.IsDisposed)
            {
                _addForm.Activate();
                _addForm.Focus();
                return;
            }

            _addForm = new AddForm();

            _addForm.ExerciseCreated += (exercise) =>
            {
                AddExerciseInternal(exercise);
            };

            _addForm.FormClosed += (s, args) =>
            {
                _addForm = null;
            };

            _addForm.Show();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить
        /// </summary>
        /// <param name="Удалить"></param>
        /// <param name="Аргумент"></param>
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (ExerciseDataGridView.SelectedRows.Count > 0)
            {
                var selectedExercise = 
                    ExerciseDataGridView.SelectedRows[0].DataBoundItem as IExercise;
                if (selectedExercise != null)
                {
                    var result = MessageBox.Show(
                        $"Вы уверены, что хотите удалить упражнение '{selectedExercise.Name}'?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

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
                    var exercisesToRemove = _exercises.ToList();

                    foreach (var exercise in exercisesToRemove)
                    {
                        _exercises.Remove(exercise);
                        _originalExercises.Remove(exercise);
                    }

                    UpdateButtonsState();
                }
            }
        }

        /// <summary>
        /// Обновление отображаемых упражнений для фильтрации
        /// </summary>
        /// <param name="Новый список упражнений для отображения"></param>
        /// <summary>
        /// Внутренний метод для обновления отображаемых упражнений
        /// </summary>
        /// <param name="Новый список упражнений для отображения"></param>
        private void UpdateExercisesInternal(List<IExercise> exercises)
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
            if (_filterForm != null && !_filterForm.IsDisposed)
            {
                _filterForm.Activate();
                _filterForm.Focus();
                return;
            }

            _filterForm = new FilterForm(_originalExercises);

            _filterForm.FilterApplied += (filteredExercises) =>
            {
                UpdateExercisesInternal(filteredExercises);
            };

            _filterForm.FilterCanceled += () =>
            {
                UpdateExercisesInternal(_originalExercises);
            };

            _filterForm.FormClosed += (s, args) =>
            {
                _filterForm = null;
            };

            _filterForm.Show();
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
        }

        /// <summary>
        /// Обработчик нажатия кнопки Открыть
        /// </summary>
        /// <param name="Открыть"></param>
        /// <param name="Аргумент"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        }

        /// <summary>
        /// Создает обертку для упражнения
        /// </summary>
        /// <param name="Упражнение для обертывания"></param>
        /// <returns>Обертка упражнения</returns>
        private ExerciseWrapper CreateWrapper(IExercise exercise)
        {
            if (exercise is Running running)
            {
                return new ExerciseWrapper(running);
            }
            else if (exercise is Swimming swimming)
            {
                return new ExerciseWrapper(swimming);
            }
            else if (exercise is BenchPress benchPress)
            {
                return new ExerciseWrapper(benchPress);
            }
            else
            {
                throw new InvalidOperationException("Неизвестный тип упражнения");
            }
        }

        /// <summary>
        /// Сохраняет список упражнений в файл в формате XML
        /// </summary>
        /// <param name="fileName">Имя файла для сохранения</param>
        private void SaveExercises(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<ExerciseWrapper>));
            var wrappedExercises = _originalExercises.Select(ex => CreateWrapper(ex)).ToList();

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(stream, wrappedExercises);
            }
        }

        /// <summary>
        /// Загружает список упражнений из файла в формате XML
        /// </summary>
        /// <param name="fileName">Имя файла для загрузки</param>
        private void LoadExercises(string fileName)
        {
            string xmlContent = File.ReadAllText(fileName);

            if (xmlContent.Contains(">NaN<") || xmlContent.Contains(">nan<"))
            {
                throw new InvalidDataException(
                    "Файл поврежден: содержит некорректные числовые значения (NaN).");
            }

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
        /// <param name="Выбранная строка"></param>
        /// <param name="Аргумент"></param>
        private void ExerciseDataGridView_SelectionChanged(object sender, 
                                                           EventArgs e)
        {
            UpdateButtonsState();
        }
    }
}