using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма фильтрации упражнений
    /// </summary>
    public partial class FilterForm : Form
    {
        private List<IExercise> _allExercises;

        /// <summary>
        /// Отфильтрованные упражнения
        /// </summary>
        public List<IExercise> FilteredExercises { get; private set; }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public FilterForm(List<IExercise> exercises)
        {
            InitializeComponent();
            _allExercises = exercises;
            FilteredExercises = new List<IExercise>(exercises);
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Заполнение CheckedListBox типами упражнений
            CheckedListBoxExercise.Items.AddRange(new string[] { "Бег", "Плавание", "Жим штанги" });

            // Выделить все элементы по умолчанию
            for (int i = 0; i < CheckedListBoxExercise.Items.Count; i++)
            {
                CheckedListBoxExercise.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Фильтр
        /// </summary>
        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            PerformFilter();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Закрыть
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Выполнение фильтрации
        /// </summary>
        private void PerformFilter()
        {
            var searchTerm = TextBoxFilter.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show(
                    "Введите текст для фильтрации. Можно вводить цифры и буквы для поиска по названию и параметрам упражнения.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxFilter.Focus();
                return;
            }

            // Получение выбранных типов упражнений
            var selectedTypes = new List<string>();
            foreach (var item in CheckedListBoxExercise.CheckedItems)
            {
                selectedTypes.Add(item.ToString());
            }

            // Если ничего не выбрано, использовать все типы
            if (selectedTypes.Count == 0)
            {
                selectedTypes.AddRange(new string[] { "Бег", "Плавание", "Жим штанги" });
            }

            // Фильтрация
            FilteredExercises = _allExercises
                .Where(ex => IsExerciseTypeSelected(ex, selectedTypes) &&
                            ContainsSearchTerm(ex, searchTerm))
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Проверка соответствия типа упражнения выбранным типам
        /// </summary>
        private bool IsExerciseTypeSelected(IExercise exercise, List<string> selectedTypes)
        {
            string exerciseType;

            if (exercise is Running)
            {
                exerciseType = "Бег";
            }
            else if (exercise is Swimming)
            {
                exerciseType = "Плавание";
            }
            else if (exercise is BenchPress)
            {
                exerciseType = "Жим штанги";
            }
            else
            {
                throw new InvalidOperationException("Неизвестный тип упражнения");
            }

            return selectedTypes.Contains(exerciseType);
        }

        /// <summary>
        /// Проверка содержания поискового запроса в данных упражнения
        /// </summary>
        private bool ContainsSearchTerm(IExercise exercise, string searchTerm)
        {
            var searchLower = searchTerm.ToLower();

            // Поиск в названии
            if (exercise.Name.ToLower().Contains(searchLower))
                return true;

            // Поиск в детальной информации
            if (exercise.ExerciseInfo.ToLower().Contains(searchLower))
                return true;

            // Поиск в специфических параметрах
            if (exercise is Running running)
            {
                if (running.Intensity.ToString().Contains(searchTerm) ||
                    running.Distance.ToString().Contains(searchTerm))
                    return true;
            }
            else if (exercise is Swimming swimming)
            {
                if (swimming.Distance.ToString().Contains(searchTerm) ||
                    swimming.Style.ToString().ToLower().Contains(searchLower))
                    return true;
            }
            else if (exercise is BenchPress benchPress)
            {
                if (benchPress.Weight.ToString().Contains(searchTerm) ||
                    benchPress.Repetitions.ToString().Contains(searchTerm))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Обработчик нажатия клавиш в поле фильтра
        /// </summary>
        private void TextBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformFilter();
                e.Handled = true;
            }
        }
    }
}