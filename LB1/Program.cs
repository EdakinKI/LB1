using Model;
using System;
using System.Collections.Generic;

namespace Lab1
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Class Main.
        /// </summary>
        private static void Main(string[] args)
        {
            // Create two lists
            var olds = new PersonList();
            var youth = new PersonList();

            // Create 6 people to fill the lists
            var emperror = new Person
                ("God", "Emperror", 122, Gender.Male);
            var chorus = new Person
                ("Chorus", "Traitor", 70, Gender.Male);
            var sanguinius = new Person
                ("Sangiunius", "Primarch", 66, Gender.Male);

            var roboute = new Person
                ("Roboute", "Crybaby", 19, Gender.Male);
            var abaddon = new Person
                ("Abaddon", "Vredina", 14, Gender.Male);
            var celestina = new Person
                ("Celestina", "Holy", 7, Gender.Female);

            // Add people to the lists
            olds.AddPerson(emperror);
            olds.AddPerson(chorus);
            olds.AddPerson(sanguinius);

            youth.AddPerson(roboute);
            youth.AddPerson(abaddon);
            youth.AddPerson(celestina);

            // Print the lists
            Console.WriteLine("To continue, press ENTER");
            _ = Console.ReadKey();
            Console.WriteLine("List of olds:");
            PrintList(olds);

            Console.WriteLine("List of youth:");
            PrintList(youth);

            // Add a new person to the 1st list
            _ = Console.ReadKey();
            var magnus = new Person
                ("Magnus", "Nottraitor", 48, Gender.Male);
            olds.AddPerson(magnus);
            Console.WriteLine("New person has been added to the 1st list");

            // Copy the second person from the 1st list to the end of
            // the 2nd list
            _ = Console.ReadKey();
            youth.AddPerson(olds.SearchPerson(1));
            Console.WriteLine("Second person from the 1st list has been" +
                " added to the 2nd list");

            // Print edited lists
            _ = Console.ReadKey();
            Console.WriteLine("List of olds:");
            PrintList(olds);

            Console.WriteLine("List of youth:");
            PrintList(youth);

            // Delete the second person from the 1st list
            _ = Console.ReadKey();
            olds.DeletePersonByIndex(1);
            Console.WriteLine("Second person from the 1st list has been" +
                " removed");

            // Print edited lists
            _ = Console.ReadKey();
            Console.WriteLine("List of olds:");
            PrintList(olds);

            Console.WriteLine("List of youth:");
            PrintList(youth);

            // Clear the second list
            _ = Console.ReadKey();
            youth.ClearList();
            Console.WriteLine("2nd list (youth) has been cleared");

            // Print the list
            Console.WriteLine("List of youth:");
            PrintList(youth);
            Console.WriteLine();

            // Check input person
            _ = Console.ReadKey();

            var inputPerson = InputPersonByConsole();
            Console.WriteLine(inputPerson.ToString());

            // Check random person
            _ = Console.ReadKey();

            Console.Write("Random person is: ");
            
            var randomPerson = Person.GetRandomPerson();
            Console.WriteLine(randomPerson.ToString());
        }

        /// <summary>
        /// Function which allows to print a certain list of people.
        /// </summary>
        /// <param name="personList">An instance of class PersonList.</param>
        private static void PrintList(PersonList personList)
        {
            if (personList == null)
            {
                throw new NullReferenceException("Null reference list.");
            }

            if (personList.NumberOfPersons() != 0)
            {
                for (int i = 0; i < personList.NumberOfPersons(); i++)
                {
                    var tmpPerson = personList.SearchPerson(i);
                    Console.WriteLine(tmpPerson.ToString());
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }

        /// <summary>
        /// Method which allows to enter information by console..
        /// </summary>
        /// <returns>An instance of class Person.</returns>
        /// <exception cref="ArgumentException">Only numbers.</exception>
        public static Person InputPersonByConsole()
        {
            var person = new Person();

            var actionList = new List<(Action<string>, string)>
            {
                (
                new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    person.Name = Console.ReadLine();
                    if (person.Name == "")
                    {
                        throw new IndexOutOfRangeException("");
                    }
                }), "name"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    person.Surname = Console.ReadLine();
                    if (person.Surname == "")
                    {
                        throw new IndexOutOfRangeException("");
                    }
                }), "surname"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    if (!int.TryParse(Console.ReadLine(), out int tmpAge))
                    {
                        //TODO: remake
                        throw new FormatException
                           ($"Age value must " +
                           $"be in range [{Person.MinAge}:{Person.MaxAge}].");
                    }
                    person.Age = tmpAge;
                }), "age"),

                (new Action<string>((string property) =>
                {
                    Console.Write
                        ($"Enter student {property} (1 - Male or 2 - Female): ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpGender);
                    if (tmpGender < 1 || tmpGender > 2)
                    {
                        throw new IndexOutOfRangeException
                            ("Number must be in range [1; 2].");
                    }

                    var realGender = tmpGender == 1
                        ? Gender.Male
                        : Gender.Female;
                    person.Gender = realGender;
                }), "gender")
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return person;
        }

        /// <summary>
        /// Method which is used for doing actions from the list.
        /// </summary>
        /// <param name="action">A certain action.</param>
        /// <param name="propertyName">Additional parameter
        /// for exception.</param>
        private static void ActionHandler(Action<string> action, string propertyName)
        {
            while (true)
            {
                try
                {
                    action.Invoke(propertyName);
                    break;
                }
                catch (Exception exception)
                {
                    if (exception.GetType()
                        == typeof(IndexOutOfRangeException)
                        || exception.GetType() == typeof(FormatException)
                        || exception.GetType() == typeof(ArgumentException))
                    {
                        Console.WriteLine($"Incorrect {propertyName}." +
                        $" Error: {exception.Message}" +
                        $"Please, enter the {propertyName} again.");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }
}
