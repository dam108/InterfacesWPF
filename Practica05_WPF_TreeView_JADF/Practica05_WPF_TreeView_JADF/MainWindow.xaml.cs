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

namespace Practica05_WPF_TreeView_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<String> localidades;
        public ObservableCollection<Trabajador> trabajadors;

        public static RoutedCommand mostrarTrabajadoresCommand = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();

            localidades = new ObservableCollection<string>();
            localidades.Add("FERROL");
            localidades.Add("BETANZOS");
            localidades.Add("SADA");
            localidades.Add("CORUÑA");
            localidades_ComboBox.ItemsSource = localidades;


            trabajadors = new ObservableCollection<Trabajador>();
            trabajadors.Add(new Trabajador("JOSE", "DOVAL", "BETANZOS", "JEFE", 1));
            trabajadors.Add(new Trabajador("MANUEL", "ORTEGA", "SADA", "JEFE", 2));
            trabajadors.Add(new Trabajador("DIEGO", "PEREZ", "FERROL", "JEFE", 0));
            trabajadors.Add(new Trabajador("JUAN", "SANCHEZ", "BETANZOS", "1º OFICIAL", 0));
            trabajadors.Add(new Trabajador("MIGUEL", "CASTRO", "SADA", "1º OFICIAL", 0));
            trabajadors.Add(new Trabajador("JESUS", "IGLESIAS", "BETANZOS", "2º OFICIAL", 0));
            trabajadors.Add(new Trabajador("PABLO", "SILVA", "CORUÑA", "JEFE", 3));
            //trabajadores_ListView.ItemsSource = trabajadors;

            CommandBinding mostrarTrabajadoresCommandBinding = new CommandBinding(
    mostrarTrabajadoresCommand, ExecutemostrarTrabajadoresCommand, CanExecutemostrarTrabajadoresCommand);

        }

        private void ExecutemostrarTrabajadoresCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var lstTrabjadores = trabajadors.Where(t => t.Localidad == localidades_ComboBox.Text).ToList();
            trabajadores_ListView.ItemsSource = lstTrabjadores;
        }
        private void CanExecutemostrarTrabajadoresCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (localidades_ComboBox.SelectedItem != null) e.CanExecute = true;
            else e.CanExecute = false;
        }

        //
        // Rellenamos el treeView
        //

        //private void CrearTreeView()
        //{
        //    // CREAMOS UNA LISTA PARA GUARDAR LOS ELEMENTOS RAIZ , EN NUESTRO CASO ESTA LISTA SOLO VA TENER UN ELEMENTO RAIZ
        //    List<Cuadrilla> cuadrillas = new List<Cuadrilla>();

        //    // CREAMOS EL ELEMENTO RAIZ
        //    Cuadrilla cuadrilla1 = new Cuadrilla() { Nombre = "CUADRILLAS" };

        //    // CREAMOS LAS LOCALIDADES 
        //    cuadrilla1.Localidades.Add(new Localidad() { Nombre = "FERROL"});
        //    cuadrilla1.Localidades.Add(new Localidad() { Nombre = "BETANZOS" });
        //    cuadrilla1.Localidades.Add(new Localidad() { Nombre = "SADA" });
        //    cuadrilla1.Localidades.Add(new Localidad() { Nombre = "A CORUÑA" });




        //    // BINDEAMOS EL ROOT 
        //    trabajadores_TreeView.ItemsSource = cuadrillas;



        //}
    }

    //public class Cuadrilla
    //{
    //    public string Nombre = "CUADRILLAS";

    //    public ObservableCollection<Localidad> Localidades { get; set; }
    //    public Cuadrilla()
    //    {
    //        this.Localidades = new ObservableCollection<Localidad>();
    //    }

    //}

    //public class Localidad
    //{
    //    public string Nombre { get; set; }
    //    public ObservableCollection<Jefe> jefes { get; set; }

    //    public Localidad()
    //    {
    //        jefes = new ObservableCollection<Jefe>();
    //    }
    //}

    //public class Jefe
    //{
    //    public string Nombre { get; set; }
    //    public ObservableCollection<Oficial1> primerosOficiales { get; set; }

    //    public Jefe()
    //    {
    //        this.primerosOficiales = new ObservableCollection<Oficial1>();
    //    }
    //}

    //public class Oficial1
    //{
    //    public string Nombre { get; set; }
    //    public ObservableCollection<Oficial2> segundosOficiales { get; set; }

    //    public Oficial1()
    //    {
    //        this.segundosOficiales = new ObservableCollection<Oficial2>();
    //    }
    //}

    //public class Oficial2
    //{
    //    public string Nombre { get; set; }

    //    public Oficial2() { }
    //}
}
