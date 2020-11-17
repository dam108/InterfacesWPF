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
        public int Id_padre { get; set; }

        public Trabajador(string nombre, string apellido, string localidad, string cargo, int ip)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Localidad = localidad;
            this.Cargo = cargo;
            this.Id_padre = ip;
        }

        public override string ToString()
        {
            return Nombre + ", " + Apellido + ", " + Localidad + ", " + Cargo + ", " + Id_padre.ToString();
        }
    }
}
