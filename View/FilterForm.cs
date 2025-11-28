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
        /// Событие, возникающее при применении фильтра
        /// </summary>
        public event Action<List<IExercise>> FilterApplied;

        /// <summary>
        /// Событие, возникающее при отмене фильтра
        /// </summary>
        public event Action FilterCanceled;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="Список всех упражнений для фильтрации"></param>
        public FilterForm(List<IExercise> exercises)
        {
            InitializeComponent();
            _allExercises = exercises;
            InitializeForm();

            this.FormClosing += FilterForm_FormClosing;
        }

        /// <summary>
        /// Обрабатывает событие закрытия формы
        /// </summary>
        private void FilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FilterCanceled?.Invoke();

                MessageBox.Show(
                "Фильтр отменен. Показаны все упражнения.",
                "Отмена фильтра",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Первоначальная настройка элементов управления формы фильтрации
        /// </summary>
        private void InitializeForm()
        {
            //TODO: duplication+
            CheckedListBoxExercise.Items.AddRange(new string[]
            { Constants.Running, Constants.Swimming, Constants.BenchPress });

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
            FilterCanceled?.Invoke();

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

            var selectedTypes = new List<string>();
            foreach (var item in CheckedListBoxExercise.CheckedItems)
            {
                selectedTypes.Add(item.ToString());
            }

            if (selectedTypes.Count == 0)
            {
                //TODO: duplication+
                selectedTypes.AddRange(new string[]
                { Constants.Running, Constants.Swimming, Constants.BenchPress });
            }

            var filteredExercises = _allExercises
                .Where(ex => IsExerciseTypeSelected(ex, selectedTypes) &&
                            ContainsSearchTerm(ex, searchTerm)).ToList();

            FilterApplied?.Invoke(filteredExercises);

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

            //TODO: duplication+
            if (exercise is Running)
            {
                exerciseType = Constants.Running;
            }
            else if (exercise is Swimming)
            {
                exerciseType = Constants.Swimming;
            }
            else if (exercise is BenchPress)
            {
                exerciseType = Constants.BenchPress;
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