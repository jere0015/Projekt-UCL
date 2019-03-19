using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_UCL
{
    public class Person
    {
        private static List<Person> people;

        public static List<Person> GetPeople
        {
            get
            {
                if (people == null)
                {
                    people = new List<Person>();
                }
                return people;
            }
            set
            {
                people = value;
            }
        }

        public string Fornavn { get; set; }
        public string Køn { get; set; }
    }
}
