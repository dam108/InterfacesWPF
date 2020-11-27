using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica06_WPF_SDI_JADF
{
    /// <summary>
    /// Lógica de interacción para HijaA.xaml
    /// </summary>
    public partial class HijaA : Window
    {
        public bool Ocultar { get; set; }
        public string titulo { get; set; }
        public int NTitulo { get; set; }
        public string TituloCompleto { get; set; }

        public HijaA(int nTitulo)
        {
            InitializeComponent();
            this.titulo = "VENTANA";
            this.NTitulo = nTitulo;
            this.Ocultar = false;
            this.Title = "A - " + NTitulo;
            this.TituloCompleto = titulo + " : " + this.Title;
       
        }

        public override string ToString()
        {
            if (!Ocultar) return TituloCompleto;
            else return TituloCompleto + " (oculta)";
        }

        // Quitamos los botones de Maximizar , Minimizar, Cerrar
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
