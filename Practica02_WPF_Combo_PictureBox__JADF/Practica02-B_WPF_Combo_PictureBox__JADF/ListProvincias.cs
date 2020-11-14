using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02_B_WPF_Combo_PictureBox__JADF
{
    public class ListProvincias
    {
        private List<Provincia> provincias;

        public ListProvincias()
        {
            provincias = new List<Provincia>();
            provincias.Add(new Provincia("A Coruña"));
            provincias[0].añadirLocalidades("Betanzos");
            provincias[0].añadirLocalidades("Sada");
            provincias.Add(new Provincia("Lugo"));
            provincias[1].añadirLocalidades("Burela");
            provincias[1].añadirLocalidades("Foz");
            provincias.Add(new Provincia("Orense"));
            provincias[2].añadirLocalidades("Allariz");
            provincias[2].añadirLocalidades("Baltar");
            provincias.Add(new Provincia("Pontevedra"));
            provincias[3].añadirLocalidades("El Grove");
            provincias[3].añadirLocalidades("Bueu");
        }

        public List<Provincia> Provincias { get => provincias; set => provincias = value; }
    }
}
