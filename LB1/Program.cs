using Model;
using System;

namespace ConsoleApp_LAB2
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Class Main.
        /// </summary>
        public static void Main(string[] args)
        {
            const int peopleCount = 7;
            Console.WriteLine($"Create a list and add {peopleCount} people.");
            Console.WriteLine();
            Console.WriteLine("Please click any button");
            var listOfPeople = new PersonList();
            var rnd = new Random();


            for (int i = 0; i < peopleCount; i++)
            {
                PersonBase rndPerson = rnd.Next(2) == 0
                    ? (PersonBase)Adult.GetRandomPerson()
                    : (PersonBase)Child.GetRandomPerson();
                listOfPeople.AddPerson(rndPerson);
            }


            _ = Console.ReadKey();

            Console.WriteLine("Print all people from the list.");
            Console.WriteLine();
            PrintList(listOfPeople);

            _ = Console.ReadKey();

            Console.WriteLine
                ("Find out type of the forth person from the list.");
            Console.WriteLine();
            var person = listOfPeople.SearchPerson(3);

            switch (person)
            {
                case Adult personAdult:
                    Console.WriteLine(personAdult.GetAdultGame());
                    break;
                case Child personChild:
                    Console.WriteLine(personChild.GetGame());
                    break;
                default:
                    break;
            }

            _ = Console.ReadKey();
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

            if (personList.NumberOfPersons != 0)
            {
                for (int i = 0; i < personList.NumberOfPersons; i++)
                {
                    var tmpPerson = personList.SearchPerson(i);
                    Console.WriteLine(tmpPerson.GetInfo());
                }
            }
            else
            {
                Console.WriteLine("List is empty.");
            }
        }
    }
}