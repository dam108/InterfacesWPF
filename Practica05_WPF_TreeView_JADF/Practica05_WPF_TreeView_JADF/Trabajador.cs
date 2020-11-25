using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica05_WPF_TreeView_JADF
{
    public class Trabajador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Localidad { get; set; }
        public string Cargo { get; set; }

        public Trabajador(string nombre, string apellido, string localidad, string cargo)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Localidad = localidad;
            this.Cargo = cargo;
        }

        public override string ToString()
        {
            return Nombre + ", " + Apellido + ", " + Localidad + ", " + Cargo;
        }
    }
}
