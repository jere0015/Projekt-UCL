using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_UCL
{
   public class Controller
    {
        DatabaseController DBC = new DatabaseController();

        public void InsertPerson (string fornavn, object køn)
        {
            Person person = new Person { Fornavn = fornavn, Køn = køn };
            DBC.InsertPerson(person);
                
        }
    }
}
