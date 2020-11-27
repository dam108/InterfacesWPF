using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica06_WPF_SDI_JADF
{
    /// <summary>
    /// Lógica de interacción para HijaC.xaml
    /// </summary>
    public partial class HijaC : Window
    {
        public bool Ocultar { get; set; }
        public string titulo { get; set; }
        public int NTitulo { get; set; }
        public string TituloCompleto { get; set; }

        public HijaC(int nTitulo)
        {
            InitializeComponent();
            this.titulo = "VENTANA";
            this.NTitulo = nTitulo;
            this.Ocultar = false;
            this.Title = "C - " + NTitulo;
            this.TituloCompleto = titulo + " : " + this.Title;

        }

        public override string ToString()
        {
            if (!Ocultar) return TituloCompleto;
            else return TituloCompleto + " (oculta)";
        }
    }
}
