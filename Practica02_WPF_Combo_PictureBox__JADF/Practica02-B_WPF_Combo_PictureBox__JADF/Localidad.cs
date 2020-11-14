using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02_B_WPF_Combo_PictureBox__JADF
{
    public class Localidad
    {
        private string nombre;

        public Localidad(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
    }
}
