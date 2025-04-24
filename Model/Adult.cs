using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class which describes a certain adult.
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Number of adult's passport.
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Adult's employer.
        /// </summary>
        private string _employer;

        /// <summary>
        /// Husband or wife.
        /// </summary>
        private Adult _spouse;

        /// <summary>
        /// Minimum age of an adult.
        /// </summary>
        private const int MinAge = 17;

        /// <summary>
        /// Maximum age value.
        /// </summary>
        protected const int MaxAge = 122;

        /// <summary>
        /// Low bound of passport number range.
        /// </summary>
        private const int PassportLowBound = 000101;

        /// <summary>
        /// High bound of passport number range.
        /// </summary>
        private const int PassportHighBound = 999999;

        /// <summary>
        /// Enter the adult's passport number.
        /// </summary>
        public int PassportNumber
        {
            get => _passportNumber;
            set
            {
                CheckPassportNumber(value);
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Enter the adult's employer.
        /// </summary>
        public string Employer
        {
            get => _employer;
            set
            {
                _employer = value;
            }
        }

        /// <summary>
        /// Enter the adult's spouse.
        /// </summary>
        public Adult Spouse
        {
            get => _spouse;
            set
            {
                _spouse = value;
            }
        }

        /// <summary>
        /// Create an instance of class Adult.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="age">Age of the person.</param>
        /// <param name="gender">Gender of the person.</param>
        /// <param name="passportNumber">Adult's passport number.</param>
        /// <param name="spouse">Adult's spouse.</param>
        /// <param name="employer">Adult's employer.</param>
        public Adult(string name, string surname, int age,
            Gender gender, int passportNumber, Adult spouse,
            string employer) : base(name, surname, age, gender)
        {
            PassportNumber = passportNumber;
            Employer = employer;
            Spouse = spouse;
        }

        /// <summary>
        /// Create an instance of class Adult without parameters.
        /// </summary>
        public Adult() : this("Unknown", "Unknown", 19,
            Gender.Male, 100000, null, null)
        { }

        /// <summary>
        /// Converts class field values to string format.
        /// </summary>
        /// <returns>Information about adult.</returns>
        public override string GetInfo()
        {
            var marrigaeStatus = "Not married";
            if (Spouse != null)
            {
                marrigaeStatus = $"Married to:" +
                    $" {Spouse.GetPersonNameSurname()}";
            }

            var employerStatus = "Unemployed";
            if (!string.IsNullOrEmpty(Employer))
            {
                employerStatus = $"Current job: {Employer}";
            }

            return $"{GetPersonInfo()};\n " +
                $"Passport number: {PassportNumber};" +
                $" {marrigaeStatus}; {employerStatus}\n ";
        }

        //TODO: redo
        /// <summary>
        /// Check adult's age.
        /// </summary>
        /// <param name="age">Adult's age.</param>
        /// <exception cref="IndexOutOfRangeException">Age must be in a
        /// certain range.</exception>
        protected override void CheckAge(int age)
        {
            if (age < MinAge || age > MaxAge)
            {
                throw new IndexOutOfRangeException($"Adult age value must" +
                    $" be in range [{MinAge};{MaxAge}].");
            }
        }

        /// <summary>
        /// Check adult's passport number.
        /// </summary>
        /// <param name="passportNumber">Adult's passport number.</param>
        /// <exception cref="IndexOutOfRangeException">Passport number must
        /// be in a certain range.</exception>
        private static void CheckPassportNumber(int passportNumber)
        {
            if (passportNumber < PassportLowBound || passportNumber > PassportHighBound)
            {
                throw new IndexOutOfRangeException($"Passport number must" +
                    $" be in range [{PassportLowBound}:" +
                    $" {PassportHighBound}]");
            }
        }

        //TODO: RSDN
        /// <summary>
        /// Copy of the random number generator
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Method which allows to enter a random adult.
        /// </summary>
        /// <returns>Information about an adult.</returns>
        /// <param name="gender">Start gender.</param>
        public static Adult GetRandomPerson(Gender gender = Gender.Unknown)
        {
            string[] maleNames =
            {
                "Sergay", "Vladimir", "Xo", "Jack", "John",
                "Sijoun", "Benjamin", "Archer", "Grimbold", "San"
            };

            string[] femaleNames =
            {
                "Dolores", "Saber", "Maximila", "Lora", "Chloe",
                "Sanka", "Katie", "Tosaka", "Mila", "Alicia"
            };

            string[] surnames =
            {
                "Sparrow", "Jones", "Miyamura", "Xan", "Shine",
                "Xaxa", "Colin", "Xander", "Piu", "Yovovuch"
            };

            string[] employers =
            {
                "Galactic empire", "Fellowship of the Ring",
                "Sunlight", "Emperium of man",
                "Chaos", "Pearl",
                "Avengers",
                "Team of TANOS",
                "Wall Strit", "I don't know"
            };

            if (gender == Gender.Unknown)
            {
                var tmpNumber = random.Next(1, 3);
                gender = tmpNumber == 1
                    ? Gender.Male
                    : Gender.Female;
            }

            string tmpName = gender == Gender.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            var tmpSurname = surnames[random.Next(surnames.Length)];

            var tmpAge = random.Next(MinAge, MaxAge);

            var tmpPassportNumber = random.Next
                (PassportLowBound, PassportHighBound);

            Adult tmpSpouse = null;
            var spouseStatus = random.Next(1, 3);
            if (spouseStatus == 1)
            {
                tmpSpouse = new Adult();

                tmpSpouse.Gender = gender == Gender.Male
                    ? Gender.Female
                    : Gender.Male;

                tmpSpouse.Name = gender == Gender.Female
                    ? maleNames[random.Next(maleNames.Length)]
                    : femaleNames[random.Next(femaleNames.Length)];

                tmpSpouse.Surname = surnames[random.Next(surnames.Length)];
            }

            var employerStatus = random.Next(1, 3);
            string tmpEmployer = employerStatus == 1
                ? employers[random.Next(employers.Length)]
                : null;

            return new Adult(tmpName, tmpSurname, tmpAge, gender,
                tmpPassportNumber, tmpSpouse, tmpEmployer);
        }

        /// <summary>
        /// Method which shows the countries for recreation.
        /// </summary>
        /// <returns>The country.</returns>
        public string GetAdultGame()
        {
            var rnd = new Random();

            string[] adult =
            {
                "69", "BDSM", "The code doesn't work again"
            };

            var chosenCountry = adult[rnd.Next(adult.Length)];

            return $"This person prefer to play in: {chosenCountry}";
        }
    }
}