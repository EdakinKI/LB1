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
        /// <summary>
        /// Исходный список всех упражнений для фильтрации
        /// </summary>
        private List<IExercise> _allExercises;

        /// <summary>
        /// Ссылка на главную форму приложения
        /// </summary>
        private MainForm _mainForm;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="Список всех упражнений для фильтрации"></param>
        /// <param name=Главная форма приложения"></param>
        public FilterForm(List<IExercise> exercises, MainForm mainForm)
        {
            InitializeComponent();
            _allExercises = exercises;
            _mainForm = mainForm;
            InitializeForm();
        }

        /// <summary>
        /// Первоначальная настройка элементов управления формы фильтрации
        /// </summary>
        private void InitializeForm()
        {
            CheckedListBoxExercise.Items.AddRange(new string[] { "Бег",
                                              "Плавание", "Жим штанги" });

            for (int i = 0; i < CheckedListBoxExercise.Items.Count; i++)
            {
                CheckedListBoxExercise.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Фильтр
        /// </summary>
        /// <param name="Фильтр"></param>
        /// <param name="Аргумент></param>
        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            PerformFilter();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Отменить
        /// </summary>
        /// <param name="Отменить"></param>
        /// <param name="Аргумент"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
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
        /// <param name="Закрыть"></param>
        /// <param name="Аргумент"></param>
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
                    "Введите текст для фильтрации. Можно вводить цифры и" +
                    " буквы для поиска по названию и параметрам упражнения.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxFilter.Focus();
                return;
            }

            var selectedTypes = new List<string>();
            foreach (var item in CheckedListBoxExercise.CheckedItems)
            {
                selectedTypes.Add(item.ToString());
            }

            if (selectedTypes.Count == 0)
            {
                selectedTypes.AddRange(new string[] { "Бег", 
                                   "Плавание", "Жим штанги" });
            }

            var filteredExercises = _allExercises
                .Where(ex => IsExerciseTypeSelected(ex, selectedTypes) &&
                            ContainsSearchTerm(ex, searchTerm)).ToList();

            _mainForm.UpdateExercises(filteredExercises);

            MessageBox.Show(
                $"Найдено упражнений: {filteredExercises.Count}",
                "Результаты фильтрации",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Проверка соответствия типа упражнения выбранным типам
        /// </summary>
        /// <param name="Проверяемое упражнение"></param>
        /// <param name="Список выбранных типов упражнений"></param>
        /// <returns>Выбранный тип</returns>
        /// <exception cref="Исключение если неизвестный тип упражнения"
        /// ></exception>
        private bool IsExerciseTypeSelected(IExercise exercise, List<string>
                                                              selectedTypes)
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
                throw new InvalidOperationException("Неизвестный тип" +
                                                    " упражнения");
            }

            return selectedTypes.Contains(exerciseType);
        }

        /// <summary>
        /// Проверка содержания поискового запроса в данных упражнения
        /// </summary>
        /// <param name="Проверяемое упражнение"></param>
        /// <param name="Поисковый запрос"></param>
        /// <returns></returns>
        private bool ContainsSearchTerm(IExercise exercise, string searchTerm)
        {
            var searchLower = searchTerm.ToLower();

            if (exercise.Name.ToLower().Contains(searchLower))
            {
                return true;
            }

            if (exercise.ExerciseInfo.ToLower().Contains(searchLower))
            {
                return true;
            }

            if (exercise.Calories.ToString("F2").Contains(searchTerm) ||
                exercise.Calories.ToString("F0").Contains(searchTerm))
            {
                return true;
            }

            return false;
        }
    }
}