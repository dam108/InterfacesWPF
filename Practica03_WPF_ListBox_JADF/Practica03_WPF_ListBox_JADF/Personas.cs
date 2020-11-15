using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica03_WPF_ListBox_JADF
{
    public class Personas
    {
        private List<Persona> persons;

        public Personas()
        {
            persons = new List<Persona>();
            persons.Add(new Persona("Pepe", "981772231", "pepe@gmail.com", "Pepe.png"));
        }

        public List<Persona> Persons { get => persons; set => persons = value; }
    }
}
