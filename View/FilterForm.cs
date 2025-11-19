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
        private MainForm _mainForm;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public FilterForm(List<IExercise> exercises, MainForm mainForm)
        {
            InitializeComponent();
            _allExercises = exercises;
            _mainForm = mainForm;
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
        /// Обработчик нажатия кнопки Отменить
        /// </summary>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Возвращаем все упражнения в главную форму
            _mainForm.UpdateExercises(_allExercises);

            MessageBox.Show(
                "Фильтр отменен. Показаны все упражнения.",
                "Отмена фильтра",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обработчик нажатия кнопки Закрыть
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            // Фильтрация ВСЕГДА из исходного списка
            var filteredExercises = _allExercises
                .Where(ex => IsExerciseTypeSelected(ex, selectedTypes) &&
                            ContainsSearchTerm(ex, searchTerm))
                .ToList();

            // Обновляем данные в главной форме
            _mainForm.UpdateExercises(filteredExercises);

            // Показываем количество найденных результатов
            MessageBox.Show(
                $"Найдено упражнений: {filteredExercises.Count}",
                "Результаты фильтрации",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

            // 1. Поиск в НАЗВАНИИ упражнения
            if (exercise.Name.ToLower().Contains(searchLower))
                return true;

            // 2. Поиск в ДЕТАЛЬНОЙ ИНФОРМАЦИИ (параметрах)
            if (exercise.ExerciseInfo.ToLower().Contains(searchLower))
                return true;

            // 3. Поиск по КАЛОРИЯМ (целые числа и с двумя знаками)
            if (exercise.Calories.ToString("F2").Contains(searchTerm) ||
                exercise.Calories.ToString("F0").Contains(searchTerm))
                return true;

            return false;
        }

        /// <summary>
        /// Обработчик нажатия клавиши Enter в поле фильтра
        /// </summary>
        private void TextBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformFilter();
                e.Handled = true;
            }
        }
    }
}