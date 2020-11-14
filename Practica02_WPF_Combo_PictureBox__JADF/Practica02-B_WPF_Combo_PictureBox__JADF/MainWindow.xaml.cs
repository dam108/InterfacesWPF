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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practica02_B_WPF_Combo_PictureBox__JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListProvincias lista = new ListProvincias();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = lista;
            provincias_ComboBox.SelectedIndex = 0;
            localidades_ComboBox.SelectedIndex = 0;
            modificar_Localidad_Rbtn.IsEnabled = false;
        }

        private void provincias_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(provincias_ComboBox.SelectedIndex != -1)
            {
                localidades_ComboBox.ItemsSource = lista.Provincias[provincias_ComboBox.SelectedIndex].Localidades;
                localidades_ComboBox.SelectedIndex = 0;
            }

        }

        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void limpiarCampos()
        {
            provincias_ComboBox.SelectedIndex = 0;
            localidades_ComboBox.SelectedIndex = 0;
            nueva_Localidad_Rbtn.IsChecked = false;
            eliminar_Localidad_Rbtn.IsChecked = false;
            nueva_Localidad_TextBox.Text = "";
        }

        private bool existeLocalidad(string localidad, int pos)
        {
            foreach (var l in lista.Provincias[pos].Localidades)
            {
                if (l.Nombre.ToLower() == localidad.ToLower()) return true;
            }
            return false;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (eliminar_Localidad_Rbtn.IsChecked == true && localidades_ComboBox.SelectedIndex >= 0)
            {
                e.CanExecute = true;
            }
            else if (nueva_Localidad_Rbtn.IsChecked == true)
            {
                e.CanExecute = true;
            }
            else e.CanExecute = false;

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (eliminar_Localidad_Rbtn.IsChecked == true)
            {
                int localidadSeleccionada = localidades_ComboBox.SelectedIndex;
                int provinciaSeleccionada = provincias_ComboBox.SelectedIndex;
                if (localidadSeleccionada >= 0 && localidadSeleccionada <= lista.Provincias[provinciaSeleccionada].Localidades.Count)
                {
                    lista.Provincias[provinciaSeleccionada].eliminarLocalidad(localidadSeleccionada);
                    limpiarCampos();
                    MessageBox.Show("Se ha eliminado la localidad correctamente", "Localidad eliminada", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    advertencia("Se debe seleccionar una localidad");
                    limpiarCampos();
                }

            }
            else if (nueva_Localidad_Rbtn.IsChecked == true)
            {
                int provinciaSeleccioanda = provincias_ComboBox.SelectedIndex;
                if (nueva_Localidad_TextBox.Text != "")
                {
                    if (!existeLocalidad(nueva_Localidad_TextBox.Text, provinciaSeleccioanda))
                    {
                        lista.Provincias[provinciaSeleccioanda].añadirLocalidades(nueva_Localidad_TextBox.Text);
                        limpiarCampos();
                        MessageBox.Show("Se ha añadido la localidad correctamente", "Localidad añadida", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        advertencia("Esta localidad ya existe en esta provincia");
                    }
                }
                else
                {
                    advertencia("Introduce la nueva localidad en la caja de texto antes de darle a ejecutar");
                    nueva_Localidad_TextBox.Focus();
                }
            }
            else
            {
                advertencia("Se debe seleccionar una opcion de la izquierda");
            }
        }
    }
}
