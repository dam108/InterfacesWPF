using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;


namespace Practica07_WPF_MDI_JADF
{
    /// <summary>
    /// Lógica de interacción para EncriptaGif_Window.xaml
    /// </summary>
    public partial class EncriptaGif_Window : Window
    {
        public ObservableCollection<ImagenGIF> imagenes;

        public static RoutedCommand EncriptarArchivoCommand = new RoutedCommand();
        public static RoutedCommand EncriptarCarpetaCommand = new RoutedCommand();
        public static RoutedCommand DesencriptarCommand = new RoutedCommand();
        public static RoutedCommand MostarCommand = new RoutedCommand();

        public EncriptaGif_Window()
        {
            InitializeComponent();

            imagenes = new ObservableCollection<ImagenGIF>();

            this.DataContext = this;
            gif_ListBox.ItemsSource = imagenes;
            gif_ListBox.DisplayMemberPath = "NombreMostrar";

            CommandBinding EncriptarArchivoCommandBinding = new CommandBinding(
                EncriptarArchivoCommand, ExecuteEncriptarArchivoCommand, CanExecuteEncriptarArchivoCommand);
            CommandBinding EncriptarCarpetaCommandBinding = new CommandBinding(
                EncriptarCarpetaCommand, ExecuteEncriptarCarpetaCommand, CanExecuteEncriptarCarpetaCommand);
            CommandBinding DesencriptarCommandBinding = new CommandBinding(
                DesencriptarCommand, ExecuteDesencriptarCommand, CanExecuteDesencriptarCommand);
            CommandBinding MostarCommandBinding = new CommandBinding(
                MostarCommand, ExecuteMostarCommand, CanExecuteMostarCommand);
        }

        private void ExecuteMostarCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            finalEncriptar_Lbl.Visibility =Visibility.Hidden;
            if (gif_ListBox.SelectedIndex >= 0)
            {
                System.Diagnostics.Process.Start(imagenes[gif_ListBox.SelectedIndex].Path);
            }
            else
            {
                advertencia("Debes seleccionar una imagen");
            }
        }
        private void CanExecuteMostarCommand(Object sender, CanExecuteRoutedEventArgs e)
        {
            if (gif_ListBox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void ExecuteDesencriptarCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            finalEncriptar_Lbl.Visibility = Visibility.Hidden;
            if (gif_ListBox.SelectedIndex >= 0)
            {
                if (!comprobarSiEstaEncriptado(imagenes[gif_ListBox.SelectedIndex].Path))
                {
                    barraDeProgreso.Value = 0;
                    encriptarDesencriptaImagen(imagenes[gif_ListBox.SelectedIndex].Path);
                    imagenes[gif_ListBox.SelectedIndex].NombreMostrar = imagenes[gif_ListBox.SelectedIndex].Nombre;

                    EnseñarImagen();

                    barraDeProgreso.Value = 100;
                    finalEncriptar_Lbl.Visibility = Visibility.Visible;
                }
                else
                {
                    advertencia("Este archivo ya esta desencriptado");
                }

                gif_ListBox.ItemsSource = null;
                gif_ListBox.ItemsSource = imagenes;
            }
            else
            {
                advertencia("Se debe seleccionar una imagen de la lista para desencriptar");
            }
        }

        private void EnseñarImagen()
        {
            try
            {
                BitmapImage bmp = new BitmapImage();

                // importante cargar la imagen en memoria si no luego no se puede usar por que el proceso esta bloqueado
                using (FileStream fileStream = new FileStream(imagenes[gif_ListBox.SelectedIndex].Path, FileMode.Open))
                {
                    bmp.BeginInit();
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.StreamSource = fileStream;
                    bmp.EndInit();
                    if (bmp.CanFreeze)
                        bmp.Freeze();

                    gif_Picturebox.Source = bmp;
                }
            }
            catch (Exception)
            {
                encriptarDesencriptaImagen(imagenes[gif_ListBox.SelectedIndex].Path);
                EnseñarImagen();
                encriptarDesencriptaImagen(imagenes[gif_ListBox.SelectedIndex].Path);
            }
        }

        private void CanExecuteDesencriptarCommand(Object sender, CanExecuteRoutedEventArgs e)
        {
            if (gif_ListBox.SelectedIndex >= 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void ExecuteEncriptarCarpetaCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            finalEncriptar_Lbl.Visibility = Visibility.Hidden;
            imagenes.Clear();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String[] archivos = Directory.GetFiles(fbd.SelectedPath, "*.gif", SearchOption.AllDirectories);

                foreach (var item in archivos)
                {
                    barraDeProgreso.Value = 0;
                    string nombre = Path.GetFileName(item);
                    string path = item;

                    if (!comprobarSiEstaEncriptado(item))
                    {
                        imagenes.Add(new ImagenGIF(nombre, path, "( encriptado)"));
                    }
                    else
                    {
                        encriptarDesencriptaImagen(path);
                        Console.WriteLine(path);

                        imagenes.Add(new ImagenGIF(nombre, path, "( encriptado)"));
                    }
                    barraDeProgreso.Value = 100;
                    finalEncriptar_Lbl.Visibility = Visibility.Visible;
                }

            }
        }
        private void CanExecuteEncriptarCarpetaCommand(Object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void gif_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gif_ListBox.SelectedIndex >= 0)
            {
                EnseñarImagen();
            }
        }

        private void ExecuteEncriptarArchivoCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            finalEncriptar_Lbl.Visibility = Visibility.Hidden;
            OpenFileDialog elegirArchivo = new OpenFileDialog();

            elegirArchivo.DefaultExt = ".gif";
            elegirArchivo.Filter = "GIF Files (*.gif)|*.gif";
            elegirArchivo.ShowDialog();
            string ruta = elegirArchivo.FileName;

            if (ruta != "")
            {
                try
                {
                    if (!existeImagen(ruta))
                    {
                        string nombre = Path.GetFileName(ruta);

                        if (!comprobarSiEstaEncriptado(ruta))
                        {
                            barraDeProgreso.Value = 0;
                            imagenes.Add(new ImagenGIF(nombre, ruta, "( encriptado)"));
                            barraDeProgreso.Value = 100;
                            finalEncriptar_Lbl.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            barraDeProgreso.Value = 0;
                            encriptarDesencriptaImagen(ruta);
                            imagenes.Add(new ImagenGIF(nombre, ruta, "( encriptado)"));
                            barraDeProgreso.Value = 100;
                            finalEncriptar_Lbl.Visibility = Visibility.Visible;
                        }

                        gif_ListBox.SelectedItem = false;
                    }
                    else
                    {
                        advertencia("Esta imagen ya esta en la lista");
                    }
                }
                catch (ArgumentException)
                {
                    advertencia("No se puede dejar vacia la seleccion de imagen");
                }
            }
        }
        private void CanExecuteEncriptarArchivoCommand(Object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private bool existeImagen(string ruta)
        {
            foreach (var item in imagenes)
            {
                if (item.Path == ruta) return true;
                return false;
            }
            return false;
        }
        private void advertencia(string txt)
        {
            System.Windows.MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void encriptarDesencriptaImagen(string ruta)
        {
            //leer los Bytes y guardarlos en una matriz de bytes
            Byte[] archivoBytes = File.ReadAllBytes(ruta);
            // cambiar primer byte por tercer byte
            // guardamos el byte 3
            Byte tres = archivoBytes[2];
            //copiamos lo que hay en el byte 1 a la posicion 3
            archivoBytes[2] = archivoBytes[0];
            // lo guardado del 3 la copiamos a la posicion 1
            archivoBytes[0] = tres;
            //Borramos el archivo
            File.Delete(ruta);
            // guardar bytes en un archivo nuevo con el mismo nombre y ruta
            File.WriteAllBytes(ruta, archivoBytes);
        }
        private bool comprobarSiEstaEncriptado(string ruta)
        {
            if (File.Exists(ruta))
            {
                Byte[] bytes = File.ReadAllBytes(ruta);

                if (bytes[0] == 71)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
