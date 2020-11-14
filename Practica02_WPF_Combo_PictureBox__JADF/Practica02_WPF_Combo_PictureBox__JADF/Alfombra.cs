using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02_WPF_Combo_PictureBox__JADF
{
    public class Alfombra
    {
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public string nombreMostrar { get; set; }

        public Alfombra(string modelo, string color, int ancho, int alto)
        {
            Modelo = modelo;
            Color = color;
            Ancho = ancho;
            Alto = alto;
            nombreMostrar = "Modelo: " + Modelo + " - Color: " + Color;
        }

        //public override bool Equals(object obj)
        //{
        //    return obj is Alfombra alfombra &&
        //           Modelo == alfombra.Modelo;
        //}

    }
}
