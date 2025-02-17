namespace Model
{
    /// <summary>
    /// Class which describes list of persons (as an array).
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Array of persons.
        /// </summary>
        private Person[] _arrayOfPersons = new Person[0];

        /// <summary>
        /// Function for add a person at the end of the array.
        /// </summary>
        /// <param name="person">The person being added.</param>
        public void AddPerson(Person person)
        {
            var indexOfNewPerson = _arrayOfPersons.Length;
            Array.Resize(ref _arrayOfPersons, indexOfNewPerson + 1);
            _arrayOfPersons[indexOfNewPerson] = person;
        }

        /// <summary>
        /// Method that checks input index for valid.
        /// </summary>
        /// <param name="index">Input index.</param>
        /// <exception cref="IndexOutOfRangeException">Index is out
        /// of the bounds.</exception>
        private void IsIndexInArray(int index)
        {
            if (index < 0 || index >= _arrayOfPersons.Length)
            {
                throw new IndexOutOfRangeException
                    ("Index is out of the bounds.");
            }
        }

        /// <summary>
        /// Method that deletes person by input index.
        /// </summary>
        /// <param name="index">Input index.</param>
        public void DeletePersonByIndex(int index)
        {
            IsIndexInArray(index);

            for (int i = index; i < _arrayOfPersons.Length - 1; i++)
            {
                _arrayOfPersons[i] = _arrayOfPersons[i + 1];
            }

            Array.Resize(ref _arrayOfPersons, _arrayOfPersons.Length - 1);
        }

        /// <summary>
        /// Method that deletes person.
        /// </summary>
        /// <param name="person">The person being deleted.</param>
        public void DeletePerson(Person person)
        {
            int index = Array.IndexOf(_arrayOfPersons, person);
            DeletePersonByIndex(index);
        }

        /// <summary>
        /// Method that finds person in array by index.
        /// </summary>
        /// <param name="index">Index of the person in array.</param>
        /// <returns>Person from the array.</returns>
        public Person SearchPerson(int index)
        {
            IsIndexInArray(index);
            return _arrayOfPersons[index];
        }

        /// <summary>
        /// Method that finds index of person in array.
        /// </summary>
        /// <param name="person">Person in array.</param>
        /// <returns>Index of person in array.
        /// If it returns -1 person doesn't exist.</returns>
        public int SearchIndexOfPerson(Person person)
        {
            int index = -1;
            for (int i = 0; i < _arrayOfPersons.Length; i++)
            {
                if (_arrayOfPersons[i] == person)
                {
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Method than allows to clear the list (as an array).
        /// </summary>
        public void ClearList()
        {
            Array.Resize(ref _arrayOfPersons, 0);
        }

        /// <summary>
        /// Method that shows the number of persons.
        /// </summary>
        /// <returns>Number of persons in list.</returns>
        public int NumberOfPersons() => _arrayOfPersons.Length;
    }
}
