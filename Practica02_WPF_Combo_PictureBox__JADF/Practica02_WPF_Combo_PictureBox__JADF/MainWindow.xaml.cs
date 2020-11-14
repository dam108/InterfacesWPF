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

namespace Practica02_WPF_Combo_PictureBox__JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Alfombras lista = new Alfombras();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = lista;
        }

        private void eliminarAlfombra_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(alfombras_ComboBox.SelectedIndex >=0 && alfombras_ComboBox.SelectedIndex <= lista.Alf.Count)
            {
                lista.borrarAlfombra(alfombras_ComboBox.SelectedIndex);
                MessageBox.Show("Se ha borrado el elemento de la lista", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                actulizarCombo();
            }
            else
            {
                advertencia("No hay ningún elemento seleccionado");
            }
            
        }

        private void eliminarTodas_Btn_Click(object sender, RoutedEventArgs e)
        {
            lista.vaciarLista();
            actulizarCombo();
            MessageBox.Show("Se han eliminado todos los elementos de la lista", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void infoAlfombra_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "MODELO: "+ lista.Alf[alfombras_ComboBox.SelectedIndex].Modelo +"\n" +
                "COLOR: " + lista.Alf[alfombras_ComboBox.SelectedIndex].Color + "\n" +
                "ANCHO " + lista.Alf[alfombras_ComboBox.SelectedIndex].Ancho + "\n" +
                "ALTO: " + lista.Alf[alfombras_ComboBox.SelectedIndex].Alto,
                "Información", MessageBoxButton.OK, MessageBoxImage.Information
                );
        }

        private void añadir_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(modelo_txtBox.Text != ""){
                if(color_txtBox.Text != "")
                {
                    if(ancho_txtBox.Text != "" && CajaNumValida(ancho_txtBox.Text))
                    {
                        if (alto_txtBox.Text != "" && CajaNumValida(alto_txtBox.Text))
                        {
                            lista.añadirAlfombra(new Alfombra(modelo_txtBox.Text, color_txtBox.Text, Int32.Parse(ancho_txtBox.Text), Int32.Parse(alto_txtBox.Text)));
                            MessageBox.Show("Producto Añadido", "Añadir", MessageBoxButton.OK, MessageBoxImage.Information);
                            actulizarCombo();

                        }
                        else
                        {
                            advertencia("El campo alto no puede estar vacio y tiene que ser un número");
                            alto_txtBox.Focus();
                        }
                    }
                    else
                    {
                        advertencia("El campo ancho no puede estar vacio y tiene que ser un número");
                        ancho_txtBox.Focus();
                    }
                }
                else
                {
                    advertencia("El campo color no se puede dejar vacio");
                    color_txtBox.Focus();
                }
            }
            else
            {
                advertencia("El campo modelo no se puede dejar en vacio");
                modelo_txtBox.Focus();
            }
        }

        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool CajaNumValida(string txt)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                char a = txt[i];
                if (!char.IsDigit(a)) return false;
            }
            return true;
        }

        private void limpiarCajas()
        {
            modelo_txtBox.Clear();
            color_txtBox.Clear();
            ancho_txtBox.Clear();
            alto_txtBox.Clear();
        }

        private void actulizarCombo()
        {
            DataContext = null;
            DataContext = lista;
            limpiarCajas();
        }
    }
}
