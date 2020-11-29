using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Path = System.IO.Path;
using TreeView = System.Windows.Controls.TreeView;

namespace Practica07_WPF_MDI_JADF
{
    /// <summary>
    /// Lógica de interacción para OrganizarVideos_Window.xaml
    /// </summary>
    public partial class OrganizarVideos_Window : Window
    {
        public ObservableCollection<FileInfo> videos;
        static ObservableCollection<DirectoryInfo> directorios;

        public static RoutedCommand SeleccionarCarpetaCommand = new RoutedCommand();
        public static RoutedCommand OrganizarCommand = new RoutedCommand();

        public OrganizarVideos_Window()
        {
            InitializeComponent();
            videos = new ObservableCollection<FileInfo>();
            directorios = new ObservableCollection<DirectoryInfo>();

            videos_ListBox.ItemsSource = videos;
            videos_ListBox.DisplayMemberPath = "Name";
            this.DataContext = this;

            CommandBinding SeleccionarCarpetaCommandBinding = new CommandBinding(
                SeleccionarCarpetaCommand, ExecuteSeleccionarCarpetaCommand, CanExecuteSeleccionarCarpetaCommand);
            CommandBinding OrganizarCommandBinding = new CommandBinding(
                OrganizarCommand, ExecuteOrganizarCommand, CanExecuteOrganizarCommand);
        }

        private void ExecuteOrganizarCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            TreeViewItem nombreRutaSeleccionada = (TreeViewItem)carpetas_TreeView.SelectedItem;
            
            foreach (var item in directorios)
            {
                if (nombreRutaSeleccionada.Header.ToString() == item.Name)
                {
                    if (organizar_DatePicker.SelectedDate == null) OrganizarVideos(item, DateTime.MinValue);
                    else OrganizarVideos(item, ((DateTime)organizar_DatePicker.SelectedDate));
                }
            }
        }
        private void CanExecuteOrganizarCommand(Object sender, CanExecuteRoutedEventArgs e)
        {
            if (carpetas_TreeView.SelectedItem != null) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void ExecuteSeleccionarCarpetaCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    ListarDirectorio(carpetas_TreeView, fbd.SelectedPath);
                }
                catch (Exception)
                {
                    advertencia("Ha ocurrido un error inesperado, selecciona una carpeta valida");
                }

                try
                {
                    ListarArchivos(fbd);
                }
                catch (ArgumentException)
                {
                    advertencia("No hay archivos de video");
                }

            }
        }

        private void CanExecuteSeleccionarCarpetaCommand(Object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void videos_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListarArchivos(System.Windows.Forms.FolderBrowserDialog fbd)
        {
            var lst = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s =>
                                         s.EndsWith(".mov") || s.EndsWith(".mp4") || s.EndsWith(".avi"));

            string root = fbd.SelectedPath;

            foreach (var item in lst)
            {
                videos.Add(new FileInfo(item));
            }
        }

        private void ListarDirectorio(TreeView arbol, string ruta)
        {
            arbol.Items.Clear();
            var raizDirectoryInfo = new DirectoryInfo(ruta);
            arbol.Items.Add(CrearNodoDirectorio(raizDirectoryInfo));
        }

        private static TreeViewItem CrearNodoDirectorio(DirectoryInfo d_info)
        {
            directorios.Add(d_info);

            var nododirectorio = new TreeViewItem { Header = d_info.Name };

            foreach (var directorio in d_info.GetDirectories())
            {
                nododirectorio.Items.Add(CrearNodoDirectorio(directorio));
            }

            return nododirectorio;
        }

        private void advertencia(string txt)
        {
            System.Windows.MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error) ;
        }

        private void OrganizarVideos(DirectoryInfo carpeta, DateTime fecha)
        {

            advertencia(fecha.ToString());

            var lst = Directory.GetFiles(carpeta.FullName, "*.*", SearchOption.AllDirectories).Where(s =>
                                         s.EndsWith(".mov") || s.EndsWith(".mp4") || s.EndsWith(".avi"));

            System.Windows.Forms.MessageBox.Show("A continuación seleccione una carpeta donde se van a guardar los videos organizados por fecha",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fecha == DateTime.MinValue)
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (var item in lst)
                    {
                        DateTime modificacion = File.GetLastWriteTime(item);

                        String rutaDirFinal = fbd.SelectedPath + @"\" + modificacion.ToString().Substring(6, 4)
                            + @"\" + modificacion.ToString().Substring(3, 2);

                        if (!Directory.Exists(rutaDirFinal))
                        {
                            Directory.CreateDirectory(rutaDirFinal);
                            File.Copy(item, rutaDirFinal + @"\" + Path.GetFileName(item));

                        }
                        else
                        {
                            if (File.Exists(rutaDirFinal + @"\" + Path.GetFileName(item)))
                            {
                                File.Delete(rutaDirFinal + @"\" + Path.GetFileName(item));
                                File.Copy(item, rutaDirFinal + @"\" + Path.GetFileName(item));
                            }
                            else
                            {
                                File.Copy(item, rutaDirFinal + @"\" + Path.GetFileName(item));
                            }
                        }

                    }

                }
            }

            else
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    foreach (var item in lst)
                    {
                        DateTime modificacion = File.GetLastWriteTime(item);

                        if (modificacion >= fecha)
                        {
                            String rutaDirFinal = fbd.SelectedPath + @"\" + modificacion.ToString().Substring(6, 4)
                            + @"\" + modificacion.ToString().Substring(3, 2);

                            if (!Directory.Exists(rutaDirFinal))
                            {
                                Directory.CreateDirectory(rutaDirFinal);
                                File.Copy(item, rutaDirFinal + @"\" + Path.GetFileName(item));

                            }
                            else
                            {
                                if (File.Exists(rutaDirFinal + @"\" + Path.GetFileName(item)))
                                {
                                    File.Delete(rutaDirFinal + @"\" + Path.GetFileName(item));
                                    File.Copy(item, rutaDirFinal + @"\" + Path.GetFileName(item));
                                }
                                else
                                {
                                    File.Copy(item, rutaDirFinal + @"\" + Path.GetFileName(item));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void carpetas_TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(carpetas_TreeView.SelectedItem != null)
            {
                string nombreCarpeta = ((TreeViewItem)carpetas_TreeView.SelectedItem).Header.ToString();

                foreach (var item in directorios)
                {
                    if (nombreCarpeta == item.Name) mostrarRutaCarpeta_Lbl.Content = item.FullName;
                    mostrarRutaCarpeta_Lbl.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
