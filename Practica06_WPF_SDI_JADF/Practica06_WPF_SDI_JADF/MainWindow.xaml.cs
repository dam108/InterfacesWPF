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

namespace Practica06_WPF_SDI_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Window> ventanas;

        public static RoutedCommand lanzarHijaACommand = new RoutedCommand();
        public static RoutedCommand lanzarHijaBCommand = new RoutedCommand();
        public static RoutedCommand lanzarHijaCCommand = new RoutedCommand();
        public static RoutedCommand MostrarCommand = new RoutedCommand();
        public static RoutedCommand OcultarCommand = new RoutedCommand();
        public static RoutedCommand CerrarCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            ventanas = new ObservableCollection<Window>();

            ventanas_ListBox.ItemsSource = ventanas;
            this.DataContext = this;

            numeroVentanas_Lbl.Content = "Numero de ventanas: " + ventanas.Count.ToString();

            CommandBinding lanzarHijaACommandBinding = new CommandBinding(
                lanzarHijaACommand, ExecutelanzarHijaACommand, CanExecutelanzarHijaACommand);
            CommandBinding lanzarHijaBCommandBinding = new CommandBinding(
                lanzarHijaBCommand, ExecutelanzarHijaBCommand, CanExecutelanzarHijaBCommand);
            CommandBinding lanzarHijaCCommandBinding = new CommandBinding(
                lanzarHijaCCommand, ExecutelanzarHijaCCommand, CanExecutelanzarHijaCCommand);
            CommandBinding MostrarCommandBinding = new CommandBinding(
                MostrarCommand, ExecuteMostrarCommand, CanExecuteMostrarCommand);
            CommandBinding OcultarCommandBinding = new CommandBinding(
                OcultarCommand, ExecuteOcultarCommand, CanExecuteOcultarCommand);
            CommandBinding CerrarCommandBinding = new CommandBinding(
                CerrarCommand, ExecuteCerrarCommand, CanExecuteCerrarCommand);

        }

        private void ExecuteCerrarCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = ventanas_ListBox.SelectedIndex;
            ventanas[n].Close();
            if (ventanas[n] is HijaA) reordenarVentanas(1, n);
            if (ventanas[n] is HijaB) reordenarVentanas(2, n);
            if (ventanas[n] is HijaC) reordenarVentanas(3, n);
            ventanas.RemoveAt(n);
            ActualizarVinculos();
            ActualizarContadorTotal();

        }
        private void CanExecuteCerrarCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ventanas_ListBox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }
        private void ExecuteOcultarCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.Parameter != null)
            {
                if (e.Parameter.ToString() == "1")
                {
                    if (ocultar_TipoA_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            if (w is HijaA)
                            {
                                ((HijaA)w).TituloCompleto = ((HijaA)w).titulo + " : " + ((HijaA)w).Title;
                                w.Hide();
                                ((HijaA)w).Ocultar = true;
                                ((HijaA)w).TituloCompleto = ((HijaA)w).TituloCompleto + " (oculta)";
                            }
                        }
                    }
                    else if (ocultar_TipoB_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            if (w is HijaB)
                            {
                                ((HijaB)w).TituloCompleto = ((HijaB)w).titulo + " : " + ((HijaB)w).Title;
                                w.Hide();
                                ((HijaB)w).Ocultar = true;
                                ((HijaB)w).TituloCompleto = ((HijaA)w).TituloCompleto + " (oculta)";
                            }
                        }
                    }
                    else if (ocultar_TipoC_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            if (w is HijaC)
                            {
                                ((HijaC)w).TituloCompleto = ((HijaC)w).titulo + " : " + ((HijaC)w).Title;
                                w.Hide();
                                ((HijaC)w).Ocultar = true;
                                ((HijaC)w).TituloCompleto = ((HijaA)w).TituloCompleto + " (oculta)";
                            }
                        }
                    }
                    else if (ocultar_Todas_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            w.Hide();
                            if (w is HijaA)
                            {
                                ((HijaA)w).TituloCompleto = ((HijaA)w).titulo + " : " + ((HijaA)w).Title;
                                ((HijaA)w).Ocultar = true;
                                ((HijaA)w).TituloCompleto = ((HijaA)w).TituloCompleto + " (oculta)";
                            }
                            if (w is HijaB)
                            {
                                ((HijaB)w).TituloCompleto = ((HijaB)w).titulo + " : " + ((HijaB)w).Title;
                                ((HijaB)w).Ocultar = true;
                                ((HijaB)w).TituloCompleto = ((HijaB)w).TituloCompleto + " (oculta)";
                            }
                            if (w is HijaC)
                            {
                                ((HijaC)w).TituloCompleto = ((HijaC)w).titulo + " : " + ((HijaC)w).Title;
                                ((HijaC)w).Ocultar = true;
                                ((HijaC)w).TituloCompleto = ((HijaC)w).TituloCompleto + " (oculta)";
                            }
                        }
                    }
                    else
                    {
                        advertencia("Se ha de seleccionar un tipo para ocultar");
                    }
                    ActualizarVinculos();
                }

                if(e.Parameter.ToString() == "2")
                {
                    if (ventanas_ListBox.SelectedIndex == -1)
                    {
                        advertencia("Se ha de seleccionar un tipo para Ocultar");
                    }
                    else
                    {
                        int n = ventanas_ListBox.SelectedIndex;
                        if (ventanas[n] is HijaA )
                        {
                            ((HijaA)ventanas[n]).TituloCompleto = ((HijaA)ventanas[n]).titulo + " : " + ((HijaA)ventanas[n]).Title;
                                ventanas[n].Hide();
                                ((HijaA)ventanas[n]).Ocultar = true;
                                ((HijaA)ventanas[n]).TituloCompleto = ((HijaA)ventanas[n]).TituloCompleto + " (oculta)";


                        }
                        if (ventanas[n] is HijaB)
                        {
                            ((HijaB)ventanas[n]).TituloCompleto = ((HijaB)ventanas[n]).titulo + " : " + ((HijaB)ventanas[n]).Title;
                            ventanas[n].Hide();
                                ((HijaB)ventanas[n]).Ocultar = true;
                                ((HijaB)ventanas[n]).TituloCompleto = ((HijaB)ventanas[n]).TituloCompleto + " (oculta)";


                        }
                        if (ventanas[n] is HijaC)
                        {
                            ((HijaC)ventanas[n]).TituloCompleto = ((HijaC)ventanas[n]).titulo + " : " + ((HijaC)ventanas[n]).Title;
                            ventanas[n].Hide();
                                ((HijaC)ventanas[n]).Ocultar = true;
                                ((HijaC)ventanas[n]).TituloCompleto = ((HijaC)ventanas[n]).TituloCompleto + " (oculta)";

                        }
                        ActualizarVinculos();
                    }
                }
            }
 
        }
        private void CanExecuteOcultarCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecuteMostrarCommand(object sender, ExecutedRoutedEventArgs e)
        {

            if (e.Parameter != null)
            {
                if (e.Parameter.ToString() == "1")
                {
                    if (mostrar_TipoA_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            if (w is HijaA)
                            {
                                ((HijaA)w).TituloCompleto = ((HijaA)w).titulo + " : " + ((HijaA)w).Title;
                                w.Show();
                                ((HijaA)w).Ocultar = false;
                            }
                        }
                    }
                    else if (mostrar_TipoB_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            if (w is HijaB)
                            {
                                ((HijaB)w).TituloCompleto = ((HijaB)w).titulo + " : " + ((HijaB)w).Title;
                                w.Show();
                                ((HijaB)w).Ocultar = false;
                            }
                        }
                    }
                    else if (mostrar_TipoC_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            if (w is HijaC)
                            {
                                ((HijaC)w).TituloCompleto = ((HijaC)w).titulo + " : " + ((HijaC)w).Title;
                                w.Show();
                                ((HijaC)w).Ocultar = false;
                            }
                        }
                    }
                    else if (mostrar_Todas_rbt.IsChecked == true)
                    {
                        foreach (Window w in ventanas)
                        {
                            w.Show();
                            if (w is HijaA)
                            {
                                ((HijaA)w).TituloCompleto = ((HijaA)w).titulo + " : " + ((HijaA)w).Title;
                                ((HijaA)w).Ocultar = false;
                            }
                            if (w is HijaB)
                            {
                                ((HijaB)w).TituloCompleto = ((HijaB)w).titulo + " : " + ((HijaB)w).Title;
                                ((HijaB)w).Ocultar = false;
                            }
                            if (w is HijaC)
                            {
                                ((HijaC)w).TituloCompleto = ((HijaC)w).titulo + " : " + ((HijaC)w).Title;
                                ((HijaC)w).Ocultar = false;
                            }
                        }
                    }
                    else
                    {
                        advertencia("Se ha de seleccionar un tipo para ocultar");
                    }
                    ActualizarVinculos();
                }

                if (e.Parameter.ToString() == "2")
                {
                    if (ventanas_ListBox.SelectedIndex == -1)
                    {
                        advertencia("Se ha de seleccionar un tipo para Ocultar");
                    }
                    else
                    {
                        int n = ventanas_ListBox.SelectedIndex;
                        if (ventanas[n] is HijaA)
                        {
                            ((HijaA)ventanas[n]).TituloCompleto = ((HijaA)ventanas[n]).titulo + " : " + ((HijaA)ventanas[n]).Title;
                            ventanas[n].Show();
                            ((HijaA)ventanas[n]).Ocultar = false;
                        }
                        if (ventanas[n] is HijaB)
                        {
                            ((HijaB)ventanas[n]).TituloCompleto = ((HijaB)ventanas[n]).titulo + " : " + ((HijaB)ventanas[n]).Title;
                            ventanas[n].Show();
                            ((HijaB)ventanas[n]).Ocultar = false;
                        }
                        if (ventanas[n] is HijaC)
                        {
                            ((HijaC)ventanas[n]).TituloCompleto = ((HijaC)ventanas[n]).titulo + " : " + ((HijaC)ventanas[n]).Title;
                            ventanas[n].Show();
                            ((HijaC)ventanas[n]).Ocultar = false;
                        }
                        ActualizarVinculos();
                    }
                }
            }
        }
        private void CanExecuteMostrarCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutelanzarHijaCCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = consguirPosicionHija(3);
            ventanas.Add(new HijaC((n + 1)));
            ventanas[contarTodas() - 1].Show();
            ActualizarContadorTotal();
        }
        private void CanExecutelanzarHijaCCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutelanzarHijaBCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = consguirPosicionHija(2);
            ventanas.Add(new HijaB((n + 1)));
            ventanas[contarTodas() - 1].Show();
            ActualizarContadorTotal();
        }
        private void CanExecutelanzarHijaBCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutelanzarHijaACommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = consguirPosicionHija(1);
            ventanas.Add(new HijaA((n + 1)));
            ventanas[contarTodas() - 1].Show();
            ActualizarContadorTotal();
        }
        private void CanExecutelanzarHijaACommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private int contarTodas()
        {
            return ventanas.Count();
        }

        private int consguirPosicionHija(int w)
        {

            int n = 0, j = 0, q = 0;
            foreach (Window v in ventanas)
            {
                if (v is HijaA) n++;
                if (v is HijaB) j++;
                if (v is HijaC) q++;
            }
            if (w == 1) return n;
            if (w == 2) return j;
            if (w == 3) return q;
            return 0;

        }

        private void ActualizarContadorTotal()
        {
            numeroVentanas_Lbl.Content = "Numero de ventanas: " + ventanas.Count.ToString();
        }

        private void reordenarVentanas(int n, int j)
        {
            if (n == 1)
            {
                for (int i = j; i < ventanas.Count; i++)
                {
                    if (ventanas[i] is HijaA)
                    {
                        ((HijaA)ventanas[i]).NTitulo--;
                        ((HijaA)ventanas[i]).Title = "A - " + ((HijaA)ventanas[i]).NTitulo;
                        ((HijaA)ventanas[i]).TituloCompleto = ((HijaA)ventanas[i]).titulo + " : " + ((HijaA)ventanas[i]).Title;
                    }
                }
            }
            if (n == 2)
            {
                for (int i = j; i < ventanas.Count; i++)
                {
                    if (ventanas[i] is HijaB)
                    {
                        ((HijaB)ventanas[i]).NTitulo--;
                        ((HijaB)ventanas[i]).Title = "B - " + ((HijaB)ventanas[i]).NTitulo;
                        ((HijaB)ventanas[i]).TituloCompleto = ((HijaB)ventanas[i]).titulo + " : " + ((HijaB)ventanas[i]).Title;
                    }
                }
            }
            if (n == 3)
            {
                for (int i = j; i < ventanas.Count; i++)
                {
                    if (ventanas[i] is HijaC)
                    {
                        ((HijaC)ventanas[i]).NTitulo--;
                        ((HijaC)ventanas[i]).Title = "C - " + ((HijaC)ventanas[i]).NTitulo;
                        ((HijaC)ventanas[i]).TituloCompleto = ((HijaC)ventanas[i]).titulo + " : " + ((HijaC)ventanas[i]).Title;
                    }
                }
            }
        }

        private void ActualizarVinculos()
        {
            ventanas_ListBox.ItemsSource = null;
            ventanas_ListBox.ItemsSource = ventanas;
        }

        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
