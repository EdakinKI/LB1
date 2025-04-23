using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class which describes a certain child.
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// A child's farther.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// A child's mother.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// A child's place pf study.
        /// </summary>
        private string _school;

        /// <summary>
        /// Minimum age value.
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Maximum age of a child.
        /// </summary>
        private const int MaxAge = 18;

        /// <summary>
        /// Enter the information about child's father.
        /// </summary>
        public Adult Father
        {
            get => _father;
            set
            {
                CheckParentGender(value, Gender.Female);
                _father = value;
            }
        }

        /// <summary>
        /// Enter the information about child's mother.
        /// </summary>
        public Adult Mother
        {
            get => _mother;
            set
            {
                CheckParentGender(value, Gender.Male);
                _mother = value;
            }
        }

        /// <summary>
        /// Enter the information about child's school.
        /// </summary>
        public string School
        {
            get => _school;
            set
            {
                _school = value;
            }
        }

        /// <summary>
        /// Create an instance of class Child.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="age">Age of the person.</param>
        /// <param name="gender">Gender of the person.</param>
        /// <param name="father">Child's father.</param>
        /// <param name="mother">Child's mother.</param>
        /// <param name="school">Child's school.</param>
        public Child(string name, string surname, int age,
            Gender gender, Adult father, Adult mother,
            string school) : base(name, surname, age, gender)
        {
            Father = father;
            Mother = mother;
            School = school;
        }

        /// <summary>
        /// Create an instance of class Child without parameters.
        /// </summary>
        public Child() : this("Unknown", "Unknown", 8,
            Gender.Male, null, null, null)
        { }

        /// <summary>
        /// Converts class field values to string format.
        /// </summary>
        /// <returns>Information about child.</returns>
        public override string GetInfo()
        {
            var fatherStatus = "Father: absence";
            var motherStatus = "Mother: absence";

            if (Father != null)
            {
                fatherStatus = $"Father: {Father.GetPersonNameSurname()}";
            }

            if (Mother != null)
            {
                motherStatus = $"Mother: {Mother.GetPersonNameSurname()}";
            }

            var schoolStatus = "Not studying";
            if (!string.IsNullOrEmpty(School))
            {
                schoolStatus = $"Studying at: {School}";
            }

            return $"{GetPersonInfo()};\n {fatherStatus}; {motherStatus};" +
                $" {schoolStatus}\n";
        }

        /// <summary>
        /// Check child's age.
        /// </summary>
        /// <param name="age">Child's age.</param>
        /// <exception cref="IndexOutOfRangeException">Age must be in a
        /// certain range.</exception>
        protected override void CheckAge(int age)
        {
            if (age <= MinAge || age >= MaxAge)
            {
                throw new IndexOutOfRangeException($"Child's age must be" +
                    $" in range [{MinAge};{MaxAge}].");
            }
        }

        /// <summary>
        /// Check parent's gender's.
        /// </summary>
        /// <param name="parent">A certain adult parent.</param>
        /// <param name="gender">Gender of the parent.</param>
        /// <exception cref="ArgumentException">Parent's gender's must
        /// differ from each other.</exception>
        private static void CheckParentGender
            (Adult parent, Gender gender)
        {
            if (parent != null && parent.Gender == gender)
            {
                throw new ArgumentException
                    ("Parent gender must be another");
            }
        }

        /// <summary>
        /// Get random parent for child.
        /// </summary>
        /// <param name="gender">Gender of random person.</param>
        /// <returns>A certain parent or nobody.</returns>
        /// <exception cref="ArgumentException">Only input 1 or 2.</exception>
        public static Adult GetRandomParent(Gender gender)
        {
            var random = new Random();
            var parentStatus = random.Next(1, 3);
            if (parentStatus == 1)
            {
                return null;
            }
            else
            {
                return Adult.GetRandomPerson(gender);
            }
        }

        /// <summary>
        /// Method which allows to enter a random child.
        /// </summary>
        /// <returns>Information about a child.</returns>
        public static Child GetRandomPerson()
        {
            string[] maleNames =
            {
                "Saske", "Frodo", "CJ", "Zuko", "Shiro",
                "Ivan", "Kirill", "Nikolai", "Vader", "Yoda"
            };

            string[] femaleNames =
            {
                "Tosaka", "Sailor", "Padme", "", "Tracey",
                "Charlotte", "Katie", "Mia", "Sophia", "Alicia"
            };

            string[] surnames =
            {
                "Extinguished", "Silver", "Wolf", "Hanks", "Dovakin",
                "Esposito", "Snow", "Joker", "Kafka", "Samurai",
                "Smith", "Englishman"
            };

            string[] schools =
            {
                "Hogwarts", "Bikini Bottom Elementary School",
                "South Park Elementary", "Blackwell High School",
                "Collsville High School", "Twin Peaks High School",
                "Homurahara High School"
            };

            var random = new Random();
            var tmpNumber = random.Next(1, 3);

            Gender tmpGender = tmpNumber == 1
                ? Gender.Male
                : Gender.Female;

            string tmpName = tmpGender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            var tmpSurname = surnames[random.Next(surnames.Length)];

            var tmpAge = random.Next(MinAge, MaxAge);

            Adult tmpFather = GetRandomParent(Gender.Male);

            Adult tmpMother = GetRandomParent(Gender.Female);

            var schoolStatus = random.Next(1, 3);
            string tmpSchool = schoolStatus == 1
                ? schools[random.Next(schools.Length)]
                : null;

            return new Child(tmpName, tmpSurname, tmpAge, tmpGender,
                tmpFather, tmpMother, tmpSchool);
        }
    }
}
