using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Path = System.IO.Path;

namespace Practica08_WPF_UserContol_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileInfo presionesXML;
        public DataSet ds;
        public DataView dtv;

        public static RoutedCommand cargarPresionesCommand = new RoutedCommand();
        public static RoutedCommand cargarPresionesOptimasCommand = new RoutedCommand();
        public static RoutedCommand volcarPresionesCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();
            presionesXML = new FileInfo(@"..\..\xml\1111AAA.xml");
            ds = new DataSet();

            RuedaDI.IsEnabled = false;
            RuedaDD.IsEnabled = false;
            RuedaTI.IsEnabled = false;
            RuedaTD.IsEnabled = false;

            CommandBinding cargarPresionesCommandBinding = new CommandBinding(
                cargarPresionesCommand, ExecutecargarPresionesCommand, CanExecutecargarPresionesCommand);
            CommandBinding cargarPresionesOptimasCommandBinding = new CommandBinding(
                cargarPresionesOptimasCommand, ExecutecargarPresionesOptimasCommand, CanExecutecargarPresionesOptimasCommand);
            CommandBinding volcarPresionesCommandBinding = new CommandBinding(
                volcarPresionesCommand, ExecutevolcarPresionesCommand, CanExecutevolcarPresionesCommand);
        }

        private void CanExecutevolcarPresionesCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutevolcarPresionesCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (dtv != null)
            {
                volcarDatosADataGrid();
                ds.WriteXml(presionesXML.FullName);
                MessageBox.Show("Se han guardado los datos correctamente en el XML");
            }
            else
            {
                MessageBox.Show("No se puede volcar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CanExecutecargarPresionesOptimasCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutecargarPresionesOptimasCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if(dtv != null)
            {
                cargarPresionesOptimas();
            }
            else
            {
                presiones_DataGrid.ItemsSource = null;
                presiones_DataGrid.ItemsSource = dtv;

                cargarPresionesOptimas();
            }

        }
        private void cargarPresionesOptimas()
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    RuedaDI.cambiarPresion(i, 1);
                }
                if (i == 1)
                {
                    RuedaDD.cambiarPresion(i, 1);
                }
                if (i == 2)
                {
                    RuedaTI.cambiarPresion(i, 1);
                }
                if (i == 3)
                {
                    RuedaTD.cambiarPresion(i, 1);
                }
            }
        }
        private void CanExecutecargarPresionesCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void ExecutecargarPresionesCommand(object sender, ExecutedRoutedEventArgs e)
        {
            presiones_DataGrid.ItemsSource = null;
            if(dtv != null ) dtv.Table.Clear();
            CargarDatosXML();
        }

        private void CargarDatosXML()
        {

            try
            {
                ds.ReadXml(presionesXML.FullName);
                presiones_DataGrid.IsReadOnly = true;
                dtv = new DataView(ds.Tables[0]);
                presiones_DataGrid.ItemsSource = dtv;

                presiones_Lbl.Content = "Tabla Presiones " + Path.GetFileNameWithoutExtension(presionesXML.Name);

                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        RuedaDI.Ds = ds;
                        RuedaDI.IsEnabled = true;
                        RuedaDI.cambiarEtiqueta(i);
                        RuedaDI.cambiarPresion(i, 0);

                    }
                    if (i == 1)
                    {
                        RuedaDD.Ds = ds;
                        RuedaDD.IsEnabled = true;
                        RuedaDD.cambiarEtiqueta(i);
                        RuedaDD.cambiarPresion(i, 0);
                    }
                    if (i == 2)
                    {
                        RuedaTI.Ds = ds;
                        RuedaTI.IsEnabled = true;
                        RuedaTI.cambiarEtiqueta(i);
                        RuedaTI.cambiarPresion(i, 0);
                    }
                    if (i == 3)
                    {
                        RuedaTD.Ds = ds;
                        RuedaTD.IsEnabled = true;
                        RuedaTD.cambiarEtiqueta(i);
                        RuedaTD.cambiarPresion(i, 0);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void volcarDatosADataGrid()
        {
            ds.Tables[0].Rows[0].SetField<string>(1, RuedaDI.Presion.Replace(".", ","));
            ds.Tables[0].Rows[1].SetField<string>(1, RuedaDD.Presion.Replace(".", ","));
            ds.Tables[0].Rows[2].SetField<string>(1, RuedaTI.Presion.Replace(".", ","));
            ds.Tables[0].Rows[3].SetField<string>(1, RuedaTD.Presion.Replace(".", ","));
        }

    }
}
