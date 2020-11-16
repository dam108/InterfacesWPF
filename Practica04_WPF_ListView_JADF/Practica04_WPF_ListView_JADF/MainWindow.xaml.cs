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

namespace Practica04_WPF_ListView_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // listas
        public ObservableCollection<String> provincias;
        public ObservableCollection<String> profesiones;
        public ObservableCollection<Trabajador> trabajadors;

        // Comandos
        //Definimos el comandos personalizados y lo instanciamos
        public static RoutedCommand eliminarProvinciaCommand = new RoutedCommand();
        public static RoutedCommand añadirProvinciaCommand = new RoutedCommand();
        public static RoutedCommand eliminarProfesionCommand = new RoutedCommand();
        public static RoutedCommand añadirProfesionCommand = new RoutedCommand();
        public static RoutedCommand añadirTrabajadorCommand = new RoutedCommand();
        public static RoutedCommand eliminarTrabajadorCommand = new RoutedCommand();
        public static RoutedCommand cerrarAplicacionCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
            IniciarListaProvincias();
            IniciarListaProfesiones();
            IniciarListaTrabajadores();

            // enlazamos los comandos con sus eventos canExecute y Execute
            EnlazarComandos();
        }

        // Metodo para enlazar comandos 
        private void EnlazarComandos()
        {
            CommandBinding eliminarProvinciaCommandBinding = new CommandBinding(
                eliminarProvinciaCommand, ExecuteeliminarProvinciaCommand, CanExecuteeliminarProvinciaCommand);
            CommandBinding añadirProvinciaCommandBinding = new CommandBinding(
                añadirProvinciaCommand, ExecuteañadirProvinciaCommand, CanExecuteañadirProvinciaCommand);
            CommandBinding eliminarProfesionCommandBinding = new CommandBinding(
                eliminarProfesionCommand, ExecuteeliminarProfesionCommand, CanExecuteeliminarProfesionCommand);
            CommandBinding añadirProfesionCommandBinding = new CommandBinding(
                añadirProfesionCommand, ExecuteañadirProfesionCommand, CanExecuteañadirProfesionCommand);
            CommandBinding añadirTrabajadorCommandBinding = new CommandBinding(
                añadirTrabajadorCommand, ExecuteañadirTrabajadorCommand, CanExecuteañadirTrabajadorCommand);
            CommandBinding eliminarTrabajadorCommandBinding = new CommandBinding(
                eliminarTrabajadorCommand, ExecuteeliminarTrabajadorCommand, CanExecuteeliminarTrabajadorCommand);
            CommandBinding cerrarAplicacionCommandBinding = new CommandBinding(
                cerrarAplicacionCommand, ExecutecerrarAplicacionCommand, CanExecutecerrarAplicacionCommand);
            
        }

        // Eventos CanExecute y Execute de todos los comandos
        // eliminar provincias
        private void ExecuteeliminarProvinciaCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = provincias_Comboox.SelectedIndex;
            EliminarProvincias(n);
        }
        private void CanExecuteeliminarProvinciaCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (provincias_Comboox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        // añadir provincias
        private void ExecuteañadirProvinciaCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string provincia = añadirProvincia_TextBox.Text;
            if (!existeProvincia(provincia))
            {
                AñadirProvincias(provincia);
                añadirProvincia_TextBox.Text = "";
                informacion("Se ha añadido la provincia correctamente");
            }
            else
            {
                añadirProvincia_TextBox.Text = "";
                advertencia("Esta provincia ya existe");
            }
        }
        private void CanExecuteañadirProvinciaCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (añadirProvincia_TextBox.Text != "") e.CanExecute = true;
            else e.CanExecute = false;
        }

        // eliminar profesion
        private void ExecuteeliminarProfesionCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = profesiones_ListBox.SelectedIndex;
            EliminarProfesiones(n);
        }
        private void CanExecuteeliminarProfesionCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (profesiones_ListBox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        // añadir profesion
        private void ExecuteañadirProfesionCommand(object sender, ExecutedRoutedEventArgs e)
        {
            string profesion = añadirProfesion_TextBox.Text;
            if (!existeProfesion(profesion))
            {
                AñadirProfesiones(profesion);
                añadirProfesion_TextBox.Text = "";
                informacion("Se ha añadido la nueva profesión");
            }
            else
            {
                añadirProfesion_TextBox.Text = "";
                advertencia("Esta profesión ya existe");
            }
        }
        private void CanExecuteañadirProfesionCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (añadirProfesion_TextBox.Text != "") e.CanExecute = true;
            else e.CanExecute = false;
        }

        // añadir trabajador
        private void ExecuteañadirTrabajadorCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (!existeDni(dni_TextBox.Text))
            {
                AñadirTrabajadores(dni_TextBox.Text, nombre_TextBox.Text, apellido1_TextBox.Text, apellido2_TextBox.Text,
                    provincias_Comboox.SelectedItem.ToString(), profesiones_ListBox.SelectedItem.ToString());
                informacion("Se ha añadido al trabajador correctamente");
                limpiarCampos();
            }
            else
            {
                advertencia("Este Trabajador ya existe");
                limpiarCampos();
            }
        }
        private void CanExecuteañadirTrabajadorCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if(dni_TextBox.Text != "" && nombre_TextBox.Text != "" && apellido1_TextBox.Text != "" && apellido2_TextBox.Text != "" 
                && provincias_Comboox.SelectedItem != null && profesiones_ListBox.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        // eliminar trabajador
        private void ExecuteeliminarTrabajadorCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if(trabajadores_ListView.SelectedIndex >= 0)
            {
                int n = trabajadores_ListView.SelectedIndex;
                EliminarTrabajadores(n);
                informacion("Se ha eliminado al trabajado correctamente");
                limpiarCampos();
            }
            else
            {
                advertencia("Seleccione un trabajador");
            }
        }
        private void CanExecuteeliminarTrabajadorCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (trabajadores_ListView.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        // cerrar aplicacion
        private void ExecutecerrarAplicacionCommand(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void CanExecutecerrarAplicacionCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        // metodo para inciar la lista de trabajadores
        private void IniciarListaTrabajadores()
        {
            trabajadors = new ObservableCollection<Trabajador>();
            trabajadors.Add(new Trabajador("79336700V", "Jose Angel", "Doval", "Fraga", "A CORUÑA", "Programador"));
            trabajadors.Add(new Trabajador("79556712C", "Pedro", "Pica", "Piedra", "LUGO", "Carpintero"));
            trabajadors.Add(new Trabajador("78736420G", "Miguel", "Suarez", "Castro", "A CORUÑA", "Fontanero"));
            trabajadores_ListView.ItemsSource = trabajadors;
        }

        // metodo para añadir Trabajadores a la lista 
        private void AñadirTrabajadores(string dni, string nombre, string ap1, string ap2, string provi, string profesion)
        {
            trabajadors.Add(new Trabajador(dni, nombre, ap1, ap2, provi, profesion));
        }

        //Metodo para eliminar Trabajadores
        private void EliminarTrabajadores(int pos)
        {
            if(pos >= 0) trabajadors.RemoveAt(pos);
        }

        // Metodo para iniciar la lista de profesiones y vincularla con el listBox
        private void IniciarListaProfesiones()
        {
            profesiones = new ObservableCollection<string>();
            profesiones.Add("Fontanero");
            profesiones.Add("Programador");
            profesiones.Add("Carpintero");
            profesiones.Add("Contable");
            profesiones_ListBox.ItemsSource = profesiones;
        }

        // metodo para añadir profesiones a la lista 
        private void AñadirProfesiones(string pro)
        {
            profesiones.Add(pro);
        }

        //Metodo para eliminar provincias
        private void EliminarProfesiones(int pos)
        {
            profesiones.RemoveAt(pos);
        }

        // Metodo para iniciar la lista de provincias y vincularla con el combobox
        private void IniciarListaProvincias()
        {
            provincias = new ObservableCollection<string>();
            provincias.Add("A CORUÑA");
            provincias.Add("LUGO");
            provincias_Comboox.ItemsSource = provincias;
        }

        // metodo para añadir provincias a la lista 
        private void AñadirProvincias(string pro)
        {
            provincias.Add(pro.ToUpper());
        }
        
        //Metodo para eliminar provincias
        private void EliminarProvincias(int pos)
        {
            provincias.RemoveAt(pos);
        }

        //Evento para cuando se selecciona a un trabajador del ListView
        private void trabajadores_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ( trabajadores_ListView.SelectedIndex >= 0)
            {
                int n = trabajadores_ListView.SelectedIndex;
                
                string txt = string.Format("DATOS DEl TRABAJADOR: {0}DNI: {1}{0}NOMBRE: {2}{0}APELLIDO 1: {3}{0}APELLIDO 2: {4}{0}PROVINCIA: {5}{0}PROFESION: {6}{0}", Environment.NewLine,
                trabajadors[n].Dni, trabajadors[n].Nombre, trabajadors[n].Apellido1, trabajadors[n].Apellido2, trabajadors[n].Provincia, trabajadors[n].Profesion);
                trabajador_TextBlock.Text = txt;
                               
            }
        }

        //Metodo advertencia
        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Metodo información
        private void informacion(string txt)
        {
            MessageBox.Show(txt, "información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // metodo para comprobar si una provincia ya existe
        private bool existeProvincia(string provincia)
        {
            foreach (var item in provincias)
            {
                if (provincia.ToUpper() == item.ToUpper()) return true;
            }

            return false;
        }

        // metodo para comprobar si una profesio ya existe
        private bool existeProfesion(string profesion)
        {
            foreach (var item in profesiones)
            {
                if (profesion.ToUpper() == item.ToUpper()) return true;
            }

            return false;
        }

        // metodo para comprobar si un trabajador ya existe
        private bool existeDni(string dni)
        {
            Trabajador momentaneo = new Trabajador(dni);
            foreach (var item in trabajadors)
            {
                if (momentaneo == item) return true;
            }
            return false;
        }

        // metodo que limpia las cajas de texto
        private void limpiarCampos()
        {
            dni_TextBox.Text = ""; nombre_TextBox.Text = ""; apellido1_TextBox.Text = ""; apellido2_TextBox.Text = "";
            provincias_Comboox.SelectedItem = null; profesiones_ListBox.SelectedItem = null; 
            trabajador_TextBlock.Text = "";
        }

    }
}
