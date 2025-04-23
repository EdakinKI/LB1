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
    public class Adult : PersonList
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
        private Adult _partner;

        /// <summary>
        /// Minimum age of an adult.
        /// </summary>
        private const int MinAge = 19;

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
        /// Enter the adult's partner.
        /// </summary>
        public Adult Partner
        {
            get => _partner;
            set
            {
                _partner = value;
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
        /// <param name="partner">Adult's spouse.</param>
        /// <param name="employer">Adult's employer.</param>
        public Adult(string name, string surname, int age,
            Gender gender, int passportNumber, Adult partner,
            string employer) : base(name, surname, age, gender)
        {
            PassportNumber = passportNumber;
            Employer = employer;
            Partner = partner;
        }

        /// <summary>
        /// Create an instance of class Adult without parameters.
        /// </summary>
        public Adult() : this("Unknown", "Unknown", 19,
            Gender.Male, 000101, null, null)
        { }

        /// <summary>
        /// Converts class field values to string format.
        /// </summary>
        /// <returns>Information about adult.</returns>
        public override string GetInfo()
        {
            var marriageStatus = "Not married";
            if (Partner != null)
            {
                marriageStatus = $"Married to:" +
                    $" {Partner.GetPersonNameSurname()}";
            }

            var employerStatus = "Unemployed";
            if (!string.IsNullOrEmpty(Employer))
            {
                employerStatus = $"Current job: {Employer}";
            }

            return $"{GetPersonInfo()};\n " +
                $"Passport number: {PassportNumber};" +
                $" {marriageStatus}; {employerStatus}\n ";
        }

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

        /// <summary>
        /// Method which allows to enter a random adult.
        /// </summary>
        /// <returns>Information about an adult.</returns>
        /// <param name="gender">Start gender.</param>
        public static Adult GetRandomPerson
            (Gender gender = Gender.Unknown)
        {
            string[] maleNames =
            {
                "Johan", "Tomas", "Sergay", "Ko", "Xun",
                "Gomer", "John", "Vladimir", "Jack", "Konnor"
            };

            string[] femaleNames =
            {
                "Alice", "Cloe", "Maxine", "Sakura", "Marge",
                "Lisa", "Robin", "Ximeko", "Alma", "Tamamo"
            };

            string[] surnames =
            {
                "Extinguished", "Silver", "Wolf", "Hanks", "Dovakin",
                "Esposito", "Snow", "Joker", "Kafka", "Samurai"
            };

            string[] employers =
            {
                "The night Watch", "Fellowship of the Ring",
                "Galactic Empire", "Emperium of man",
                "Sunlight", "Cookie Corporation",
                "Avengers",
                "Officio Assassinorum",
                "Devil may cry", "Men in Black"
            };

            var random = new Random();

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

            Adult tmpPartner = null;
            var partnerStatus = random.Next(1, 3);
            if (partnerStatus == 1)
            {
                tmpPartner = new Adult();

                tmpPartner.Gender = gender == Gender.Male
                    ? Gender.Female
                    : Gender.Male;

                tmpPartner.Name = gender == Gender.Female
                    ? maleNames[random.Next(maleNames.Length)]
                    : femaleNames[random.Next(femaleNames.Length)];

                tmpPartner.Surname = surnames[random.Next(surnames.Length)];
            }

            var employerStatus = random.Next(1, 3);
            string tmpEmployer = employerStatus == 1
                ? employers[random.Next(employers.Length)]
                : null;

            return new Adult(tmpName, tmpSurname, tmpAge, gender,
                tmpPassportNumber, tmpPartner, tmpEmployer);
        }

        /// <summary>
        /// Method which shows the countries for recreation.
        /// </summary>
        /// <returns>The country.</returns>
        public string GetCountry()
        {
            var rnd = new Random();

            string[] countries =
            {
                "Russia", "USA", "Japan"
            };

            var chosenCountry = countries[rnd.Next(countries.Length)];

            return $"This man prefer to recreate in {chosenCountry}";
        }
    }
}