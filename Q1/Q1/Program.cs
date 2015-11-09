using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1
{
    class Program
    {
        /// <summary>
        /// Basic structure to store data
        /// </summary>
        struct Person
        {
            public int id;
            public int birthYear;
            public int deathYear;

        }

        /// <summary>
        /// Simple simulated data
        /// </summary>
        /// <returns></returns>
        static List<Person> GetAllPersons()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { id = 1,  birthYear = 1912, deathYear = 1916 });
            persons.Add(new Person() { id = 2,  birthYear = 1916, deathYear = 1970 });
            persons.Add(new Person() { id = 3,  birthYear = 1920, deathYear = 1936 });
            persons.Add(new Person() { id = 4,  birthYear = 1921, deathYear = 1966 });
            persons.Add(new Person() { id = 5,  birthYear = 1924, deathYear = 1965 });
            persons.Add(new Person() { id = 6,  birthYear = 1932, deathYear = 1964 });
            persons.Add(new Person() { id = 7,  birthYear = 1936, deathYear = 1967 });
            persons.Add(new Person() { id = 8,  birthYear = 1950, deathYear = 1988 });
            persons.Add(new Person() { id = 9,  birthYear = 1960, deathYear = 1970 });
            persons.Add(new Person() { id = 10, birthYear = 1967, deathYear = 1990 });
            persons.Add(new Person() { id = 11, birthYear = 1970, deathYear = 1990 });
            persons.Add(new Person() { id = 12, birthYear = 1975, deathYear = 1990 });
            return persons;
        }
        //static Boolean IsAlive(Person person, int iyear)
        //{
        //    return person.birthYear < iyear && person.deathYear > iyear;
        //}


        /// <summary>
        /// Uses Linq query
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="iYear"></param>
        /// <returns>Returns count of persons alive in a particular year</returns>
        static int PersonsAliveInYear(List<Person> persons, int iYear)
        {
            var result = persons.Where(person => person.birthYear < iYear && person.deathYear > iYear);
            return result.Count();
        }

        static void Main(string[] args)
        {
            List<Person> persons = GetAllPersons();
            int mostAlive = 0;
            int t = 0;
            List<int> years = new List<int>();
            for(int i=1900; i<=2000; i++)
            {
                t = PersonsAliveInYear(persons, i);
                Console.WriteLine(string.Format("Persons Alive in {0} are {1}", i, t));
                if(t> mostAlive)
                {
                    //resetting the list of years
                    //when mostAliveInYear exceeds the previous value
                    years = new List<int>();
                    mostAlive = t;
                }
                if(t== mostAlive)
                {
                    //Multiple years can have most alive persons
                    years.Add(i);
                }
            }
            string strYears = string.Join(", ", years.ToArray()); //simple formatting for output
            Console.WriteLine(string.Format("*** Most Persons Alive in {0} are {1} ***", strYears, mostAlive));
            Console.ReadLine();
        }
    }
}
