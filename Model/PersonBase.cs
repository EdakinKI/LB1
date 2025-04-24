using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Model
{
    /// <summary>
    /// Class which describe persons.
    /// </summary>
    public abstract class PersonBase
    {
        /// <summary>
        /// Minimum age value.
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Maximum age value.
        /// </summary>
        private const int MaxAge = 122;

        /// <summary>
        /// Name of person.
        /// </summary>
        private string _name;

        /// <summary>
        /// Surname of person.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Age of person.
        /// </summary>
        private int _age;

        /// <summary>
        /// Enter the name of person.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                _name = CheckNameSurname(value, _surname);
            }
        }

        /// <summary>
        /// Enter the surname of person.
        /// </summary>
        public string Surname
        {
            get => _surname;

            set
            {
                _surname = CheckNameSurname(value, _name);
            }
        }

        /// <summary>
        /// Enter the age of person.
        /// </summary>
        public int Age
        {
            get => _age;

            set
            {
                CheckAge(value);
                _age = value;
            }
        }

        /// <summary>
        /// Enter the gender of person.
        /// </summary>
        public Gender Gender
        {
            get; set;
        }

        /// <summary>
        /// PersonBase's constructor.
        /// </summary>
        /// <param name="name">Name of person.</param>
        /// <param name="surname">Surname of person.</param>
        /// <param name="age">Age of person.</param>
        /// <param name="gender">Gender of person.</param>
        protected PersonBase
            (string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBase"/> class.
        /// </summary>
        protected PersonBase()
        { }

        /// <summary>
        /// Converts class field value to string format.
        /// </summary>
        /// <returns>Information about person.</returns>
        public string GetPersonInfo()
        {
            return $"{Name} {Surname}; Age - {Age}; Gender - {Gender}";
        }

        /// <summary>
        /// Converts certain class field values to string format.
        /// </summary>
        /// <returns>Person's name or surname.</returns>
        public string GetPersonNameSurname()
        {
            return $"{Name} {Surname}";
        }

        /// <summary>
        /// Check language of the string.
        /// </summary>
        /// <param name="name">String.</param>
        private static Language CheckStringLanguage(string name)
        {
            var latinSymbols = new Regex
                (@"^[A-z]+(-[A-z])?[A-z]*$");
            var cyrillicSymbols = new Regex
                (@"^[А-я]+(-[А-я])?[А-я]*$");

            if (!string.IsNullOrEmpty(name))
            {
                if (latinSymbols.IsMatch(name))
                {
                    return Language.English;
                }
                else if (cyrillicSymbols.IsMatch(name))
                {
                    return Language.Russian;
                }
                else
                {
                    throw new ArgumentException("Incorrect input." +
                        " Please, try again!");
                }
            }

            return Language.Unknown;
        }

        /// <summary>
        /// Method which check string language.
        /// </summary>
        /// <param name="tmpStr">Input string.</param>
        /// <exception cref="ArgumentException">Exception.</exception>
        private void CheckUnknownLanguage(string tmpStr)
        {
            if (CheckStringLanguage(tmpStr) == Language.Unknown)
            {
                throw new ArgumentException("Incorrect input." +
                    " Please use only characters of the same language");
            }
        }

        /// <summary>
        /// Compare languages of the person's name and surname.
        /// </summary>
        /// <param name="word1">Name of Person.</param>
        /// <param name="word2">Surname of Person.</param>
        /// <exception cref="FormatException">Only one
        /// language.</exception>
        private void CheckSameLanguage(string word1, string word2)
        {
            if ((!string.IsNullOrEmpty(word1))
                && (!string.IsNullOrEmpty(word2)))
            {
                var word1Language = CheckStringLanguage(word1);
                var word2Language = CheckStringLanguage(word2);

                if (word1Language != word2Language)
                {
                    throw new ArgumentException("Incorrect input." +
                    " Please use only characters of the same language");
                }
            }
        }

        /// <summary>
        /// Case conversion: first letter capital, other capitals.
        /// </summary>
        /// <param name="word">Name or surname of the person.</param>
        /// <returns>Edited Name or surname of the person.</returns>
        private static string Capitalazation(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }

        /// <summary>
        /// Method for complex check names and surnames.
        /// </summary>
        /// <param name="word1">Name or surname of the person.</param>
        /// <param name="word2">Name or surname of the person.</param>
        /// <returns>Edited and checked name or surname
        /// of the person.</returns>
        private string CheckNameSurname(string word1, string word2)
        {
            CheckUnknownLanguage(word1);
            var tmpString = Capitalazation(word1);
            CheckSameLanguage(word1, word2);
            return tmpString;
        }

        /// <summary>
        /// Get the information about a person.
        /// </summary>
        /// <returns>Info about person.</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Check person's age.
        /// </summary>
        /// <param name="age">Person's age.</param>
        private void CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new IndexOutOfRangeException($"Person's age must be" +
                    $" in range.");
            }
        }

    }
}
