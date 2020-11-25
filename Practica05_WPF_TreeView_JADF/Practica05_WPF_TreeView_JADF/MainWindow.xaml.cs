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
        public ObservableCollection<Cuadrilla> contexto;
        public List<Trabajador> trabajadores;

        public static RoutedCommand mostrarTrabajadoresCommand = new RoutedCommand();
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding mostrarTrabajadoresCommandBinding = new CommandBinding(
                mostrarTrabajadoresCommand, ExecutemostrarTrabajadoresCommand, CanExecutemostrarTrabajadoresCommand);

            CrearTreeView();

            trabajadores = new List<Trabajador>();

            rellenarListaTrabajadores();

        }

        private void ExecutemostrarTrabajadoresCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var lstTrabjadores = trabajadores.Where(t => t.Localidad == localidades_ComboBox.Text).ToList();
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

        private void CrearTreeView()
        {
            contexto = new ObservableCollection<Cuadrilla>();
            contexto.Add(new Cuadrilla("Cuadrilla"));


            trabajadores_TreeView.ItemsSource = contexto;

            contexto[0].Localidades.Add(new Localidad("FERROL"));
            contexto[0].Localidades.Add(new Localidad("BETANZOS"));
            contexto[0].Localidades.Add(new Localidad("SADA"));
            contexto[0].Localidades.Add(new Localidad("CORUÑA"));

            contexto[0].Localidades[0].jefes.Add(new Jefe("DIEGO", "PEREZ"));
            contexto[0].Localidades[1].jefes.Add(new Jefe("JOSE", "DOVAL"));
            contexto[0].Localidades[2].jefes.Add(new Jefe("MANUEL", "ORTEGA"));
            contexto[0].Localidades[3].jefes.Add(new Jefe("PABLO", "SILVA"));

            contexto[0].Localidades[1].jefes[0].primerosOficiales.Add(new Oficial1("JUAN", "SANCHEZ"));
            contexto[0].Localidades[2].jefes[0].primerosOficiales.Add(new Oficial1("MIGUEL", "CASTRO"));


            contexto[0].Localidades[1].jefes[0].primerosOficiales[0].segundosOficiales.Add(new Oficial2("JESUS", "IGLESIAS"));

            localidades_ComboBox.ItemsSource = contexto[0].Localidades;

        }

        private void rellenarListaTrabajadores()
        {
            foreach (var localidad in contexto[0].Localidades)
            {
                foreach (var jefe in localidad.jefes)
                {
                    trabajadores.Add(new Trabajador(jefe.Nombre, jefe.Apellido, localidad.Nombre, jefe.Cargo.ToUpper()));

                    foreach (var oficial1 in jefe.primerosOficiales)
                    {
                        trabajadores.Add(new Trabajador(oficial1.Nombre, oficial1.Apellido, localidad.Nombre, oficial1.Cargo.ToUpper()));

                        foreach (var oficial2 in oficial1.segundosOficiales)
                        {
                            trabajadores.Add(new Trabajador(oficial2.Nombre, oficial2.Apellido, localidad.Nombre, oficial2.Cargo.ToUpper()));
                        }
                    }
                }
            }
        
        }


    }

    public class Cuadrilla
    {
        public string Nombre { get; set; }

        public ObservableCollection<Localidad> Localidades { get; set; }
        
        public Cuadrilla(string nombre)
        {
            this.Nombre = nombre;
            this.Localidades = new ObservableCollection<Localidad>();
        }

    }

    public class Localidad
    {
        public string Nombre { get; set; }
        public ObservableCollection<Jefe> jefes { get; set; }

        public Localidad(string nombre)
        {
            this.Nombre = nombre;
            jefes = new ObservableCollection<Jefe>();
        }
    }

    public class Jefe : Persona
    {
        public ObservableCollection<Oficial1> primerosOficiales { get; set; }

        public Jefe(string nombre, string apellido): base(nombre, apellido)
        {
            this.primerosOficiales = new ObservableCollection<Oficial1>();
            this.Cargo = "Jefe";
            this.Descripcion = this.Cargo.ToUpper() + ": " + this.Nombre + " " + this.Apellido;
        }
    }

    public class Oficial1 : Persona
    {
        public ObservableCollection<Oficial2> segundosOficiales { get; set; }

        public Oficial1(string nombre, string apellido) : base(nombre, apellido)
        {
            this.segundosOficiales = new ObservableCollection<Oficial2>();
            this.Cargo = "Primer Oficial";
            this.Descripcion = this.Cargo.ToUpper() + ": " + this.Nombre + " " + this.Apellido;
        }
    }

    public class Oficial2 : Persona
    {

        public Oficial2(string nombre, string apellido) : base(nombre, apellido)
        {
            this.Cargo = "Segundo Oficial";
            this.Descripcion = this.Cargo.ToUpper() + ": " + this.Nombre + " " + this.Apellido;
        }
    }


    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private string cargo;
        private string descripcion;

        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public override bool Equals(object obj)
        {
            return obj is Persona persona &&
                    nombre == persona.nombre &&
                    apellido == persona.apellido;
        }

    }
}
