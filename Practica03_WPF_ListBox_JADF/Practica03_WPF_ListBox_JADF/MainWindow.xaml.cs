using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Practica03_WPF_ListBox_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Personas lista = new Personas();

        //Definimos el comandos personalizados y lo instanciamos
        public static RoutedCommand NuevoCommand = new RoutedCommand();
        public static RoutedCommand AñadirCommand = new RoutedCommand();
        public static RoutedCommand EliminarCommand = new RoutedCommand();
        public static RoutedCommand ModificarCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
            // indicamos de donde vienen los datos para el listBox
            DataContext = lista;

            // elanzamos los comandos con sus eventes canExecute y Execute
            CommandBinding NuevoCommandBinding = new CommandBinding( NuevoCommand, ExecutedNuevoCommand, CanExecuteNuevoCommand);
            this.CommandBindings.Add(NuevoCommandBinding);
            CommandBinding AñadirCommandBinding = new CommandBinding( AñadirCommand, ExecutedAñadirCommand, CanExecuteAñadirCommand);
            this.CommandBindings.Add(AñadirCommandBinding);
            CommandBinding EliminarCommandBinding = new CommandBinding(EliminarCommand, ExecutedEliminarCommand, CanExecuteEliminarCommand);
            this.CommandBindings.Add(EliminarCommandBinding);
            CommandBinding ModificarCommandBinding = new CommandBinding(ModificarCommand, ExecutedModificarCommand, CanExecuteModificarCommand);
            this.CommandBindings.Add(ModificarCommandBinding);
        }

        // Evento click para el boton confirmar ( modificar)
        private void confirmar_Btn_Click(object sender, RoutedEventArgs e)
        {
            string nombre = nombre_TextBox.Text;
            string telefono = telefono_TextBox.Text;
            string email = email_TextBox.Text;
            int pos = personas_ListBox.SelectedIndex;
            BorrarImagen(lista.Persons[pos].NombreFoto);
            lista.Persons[pos].Nombre = nombre;
            lista.Persons[pos].Telefono = telefono;
            lista.Persons[pos].Email = email;
            lista.Persons[pos].NombreFoto = nombre + ".png";
            GuardarImagen(lista.Persons[pos].NombreFoto);
            MessageBox.Show("Se ha Modificado el contacto correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            limpiarCampos();
            ActualizarBinding();
            ActivarNuevo();
        }

        // Creamos el event handler de el comando Modificar , executed
        private void ExecutedModificarCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ActivarConfirmar();
        }

        // Creamos el event handler de el comando Modificar , canExecuted
        private void CanExecuteModificarCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (personas_ListBox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        // Creamos el event handler de el comando eliminar , executed
        private void ExecutedEliminarCommand(object sender, ExecutedRoutedEventArgs e)
        {
            int n = personas_ListBox.SelectedIndex;
            EliminarDatosEnLista(n);
            ActivarNuevo();
        }

        // Creamos el event handler de el comando eliminar , canExecuted
        private void CanExecuteEliminarCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (personas_ListBox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        // Creamos el event handler de el comando añadir , executed
        private void ExecutedAñadirCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (ComprobacionNombre() && ComprobacionTelefono() && ComprobacionEmail() && ComprobacionImagen())
            {
                string nombre = nombre_TextBox.Text;
                string telefono = telefono_TextBox.Text;
                string email = email_TextBox.Text;
                string nombreFoto = nombre + ".png";
                GuardarImagen(nombreFoto);
                lista.Persons.Add(new Persona(nombre, telefono, email, nombreFoto));
                ActualizarBinding();
                ActivarNuevo();
            }
        }

        // Creamos el event handler de el comando añadir , canExecuted
        private void CanExecuteAñadirCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Creamos el event handler de el comando nuevo , executed
        private void ExecutedNuevoCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ActivarAñadir();
        }

        // Creamos el event handler de el comando nuevo , canExecuted
        private void CanExecuteNuevoCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        // Metodo que abre un explorador de archivos y devuelve una imagen 
        private void CargarImagen()
        {
            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = "C:\\";
            getImage.Filter = "Archivos de Imagen (*.jpg)(*.jpeg)|*.jpg;*.jpef|PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            if (getImage.ShowDialog() == true)
            {
                imagen_Mostrar.Source = new BitmapImage(new Uri(getImage.FileName));
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna imagen", "");
            }
        }

        //Evento para cuando hacemos click sobre el cuadro de imagen para elejir una imagen desde el disco duro
        private void imagen_Mostrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CargarImagen();
        }

        // Evento que lanza la funcion para mostrar los datos segun la posicion del listBox Seleccionada
        private void personas_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(personas_ListBox.Items.Count >= 1)
            {
                int n = personas_ListBox.SelectedIndex;
                MostrarCampos(n);
            }
        }

        // Metodo que muestra los datos en los cuadros
        private void MostrarCampos(int pos)
        {
            if (pos >= 0)
            {
                nombre_TextBox.Text = lista.Persons[pos].Nombre;
                telefono_TextBox.Text = lista.Persons[pos].Telefono;
                email_TextBox.Text = lista.Persons[pos].Email;
                string foto = lista.Persons[pos].NombreFoto;

                // recogemos el path de donde se genera el ejecutable del programa
                string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                try
                {
                    // instanciamos una nueva imagen de bits
                    BitmapImage b = new BitmapImage();
                    b.BeginInit();
                    // guardamos la ruta 
                    b.UriSource = new Uri(dir + @"..\..\..\img\" + foto);
                    // la cargamos en cache
                    b.CacheOption = BitmapCacheOption.OnLoad;
                    b.EndInit();
                    // mostramos la imagen 
                    imagen_Mostrar.Source = b;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    // si el programa rompe mostramos la imagen por defecto
                    BitmapImage b = new BitmapImage(new Uri(dir +  @"..\..\..\img\FotoLimpiar.png"));
                    imagen_Mostrar.Source = b;
                }


            }
            else
            {
                //advertimos de que no hay ningun contacto
                advertencia("No hay ningun contacto , pulsa nuevo para crear uno");
            }
        }
        
        // Metodo que lanza un aviso de error
        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //
        // Metodos de Comprobaciones de las cajas y la imagen
        //

        private bool ComprobacionNombre()
        {
            if (nombre_TextBox.Text != "") return true;
            else
            {
                advertencia("Debes rellenar el campo nombre");
                nombre_TextBox.Focus();
                return false;
            }
        }

        private bool ComprobacionTelefono()
        {
            if (telefono_TextBox.Text != "") return true;
            else
            {
                advertencia("Debes rellenar el campo telefono");
                telefono_TextBox.Focus();
                return false;
            }
        }

        private bool ComprobacionEmail()
        {
            if (email_TextBox.Text != "") return true;
            else
            {
                advertencia("Debes rellenar el campo email");
                email_TextBox.Focus();
                return false;
            }
        }

        private bool ComprobacionImagen()
        {


            if (imagen_Mostrar.Source != null)
            {
                return true;
            }
            else
            {
                advertencia("Debes seleccionar una imagen");
                return false;
            }

        }

        //
        //  Fin Metodos de Comprobaciones de las cajas y la imagen
        //
        
        // Metodo que guarda la imagen seleccionada en la carpeta del proyecto
        private void GuardarImagen(string nombreFoto)
        {
            // si existe la borramos
            BorrarImagen(nombreFoto);
            
            // y despues guardamos
            String filePath = @"..\..\img\" + nombreFoto;

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imagen_Mostrar.Source));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);
        }

        // Metodo para actualizar los enlaces del listBox
        private void ActualizarBinding()
        {
            DataContext = null;
            DataContext = lista;
        }

        //
        // Metodos que lanza las activaciones y desactivaciones de cajas de texto y Botones
        //
        private void ActivarNuevo()
        {
            nombre_TextBox.IsEnabled = false;
            telefono_TextBox.IsEnabled = false;
            email_TextBox.IsEnabled = false;
            imagen_Mostrar_Border.IsEnabled = false;
            nuevo_Btn.IsEnabled = true;
            limpiarCampos();
            nuevo_Btn.Visibility = System.Windows.Visibility.Visible;
            añadir_Btn.Visibility = System.Windows.Visibility.Hidden;
            //modificar_Btn.Visibility = System.Windows.Visibility.Visible;
            confirmar_Btn.Visibility = System.Windows.Visibility.Hidden;
            //eliminar_Btn.Visibility = System.Windows.Visibility.Visible;
            //modificar_Btn.IsEnabled = false;
            //eliminar_Btn.IsEnabled = false;
            //confirmar_Btn.IsEnabled = false;
        }

        private void ActivarAñadir()
        {
            nombre_TextBox.IsEnabled = true;
            telefono_TextBox.IsEnabled = true;
            email_TextBox.IsEnabled = true;
            imagen_Mostrar_Border.IsEnabled = true;
            nuevo_Btn.IsEnabled = false;
            limpiarCampos();
            nuevo_Btn.Visibility = System.Windows.Visibility.Hidden;
            añadir_Btn.Visibility = System.Windows.Visibility.Visible;
        }

        private void ActivarConfirmar()
        {
            nombre_TextBox.IsEnabled = true;
            telefono_TextBox.IsEnabled = true;
            email_TextBox.IsEnabled = true;
            imagen_Mostrar_Border.IsEnabled = true;
            nuevo_Btn.IsEnabled = false;
            nuevo_Btn.Visibility = System.Windows.Visibility.Hidden;
            añadir_Btn.Visibility = System.Windows.Visibility.Hidden;
            confirmar_Btn.Visibility = System.Windows.Visibility.Visible;
        }

        //
        // Fin Metodos que lanza las activaciones y desactivaciones de cajas de texto y Botones
        //

        // Metodo para Eliminar Datos en lista de contactos
        private void EliminarDatosEnLista(int pos)
        {
                string nombre, nombreFoto;
                nombre = nombre_TextBox.Text;
                nombreFoto = nombre + ".png";
                BorrarImagen(nombreFoto);
                lista.Persons.RemoveAt(pos);
                ActualizarBinding();
                MessageBox.Show("Se ha eliminado el contacto correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiarCampos();
        }

        // Metodo que borra una imagen 
        private void BorrarImagen(string nombreFoto)
        {
            if (System.IO.File.Exists(@"..\..\img\" + nombreFoto))
            {
                System.IO.File.Delete(@"..\..\img\" + nombreFoto);
            }
        }

        //Metodo para limpiar las cajas de texto
        private void limpiarCampos()
        {
            nombre_TextBox.Text = "";
            telefono_TextBox.Text = "";
            email_TextBox.Text = "";
            imagen_Mostrar.Source = null;
        }
    }
}
