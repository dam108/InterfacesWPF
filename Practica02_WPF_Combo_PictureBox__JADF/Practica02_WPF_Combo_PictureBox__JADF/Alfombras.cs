using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica02_WPF_Combo_PictureBox__JADF
{

    public class Alfombras
    {
        private List<Alfombra> alf;

        public Alfombras()
        {
            Alf = new List<Alfombra>();
            Alf.Add(new Alfombra("Persa", "Azul", 130, 90));
            Alf.Add(new Alfombra("Marroqui", "Verde", 130, 90));
        }

        public List<Alfombra> Alf {get => alf; set => alf = value; }


        public void vaciarLista()
        {
            Alf.Clear();
        }

        public void añadirAlfombra(Alfombra a) {
            Alf.Add(a);
        }
        
        public void borrarAlfombra(int n)
        {
            Alf.RemoveAt(n);
        }
    }
}
