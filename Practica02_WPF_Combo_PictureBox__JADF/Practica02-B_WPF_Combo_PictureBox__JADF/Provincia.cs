using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02_B_WPF_Combo_PictureBox__JADF
{
    public class Provincia
    {
        private string nombre;
        private ObservableCollection<Localidad> localidades;

        public Provincia(string nombre)
        {
            this.nombre = nombre;
            localidades = new ObservableCollection<Localidad>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        internal ObservableCollection<Localidad> Localidades { get => localidades; set => localidades = value; }

        public void añadirLocalidades(string localidad)
        {
            localidades.Add(new Localidad(localidad));
        }

        public void eliminarLocalidad(int pos)
        {
            localidades.RemoveAt(pos);
        }
    }
}
