using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_UCL
{
    public class Gruppe
    {
        private List<Person> people = new List<Person>();

        public List<Person> People
        {
            get
            {
                return people;
            }
        }
    }
}
