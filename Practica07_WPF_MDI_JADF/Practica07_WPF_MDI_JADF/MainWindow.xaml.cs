using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica07_WPF_MDI_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Window> ventanas;
        
        public MainWindow()
        {
            InitializeComponent();
            ventanas = new ObservableCollection<Window>();
            ventanas_ListBox.ItemsSource = ventanas;
            DataContext = this;
        }

        private void mnuBusca_Palabras_Click(object sender, RoutedEventArgs e)
        {
            ventanas.Add(new BuscarPalabra_Window());
            ventanas[contarTodas() - 1].Show();
        }

        private void mnuEncripta_Gif_Click(object sender, RoutedEventArgs e)
        {
            ventanas.Add(new EncriptaGif_Window());
            ventanas[contarTodas() - 1].Show();
        }

        private void mnuOrganiza_Videos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New");
        }

        private void mnuSalir_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private int contarTodas()
        {
            return ventanas.Count();
        }
    }
}
