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

namespace Practica01_WPF_controles_Básicos_JADF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int indextStructGlobal { get; set; }
        private const int  FICHAS_MAX = 10;
        List<FichaPersona> fichas;

        public MainWindow()
        {
            InitializeComponent();
            fichas = new List<FichaPersona>();
            otra_TextBox.IsEnabled = false;
        }

        //struct de ficha para una persona
        public struct FichaPersona
        {
            public string dni, nombre, apellido1, apellido2, strTitulacionMax_Otra;
            public Boolean permisoA, permisoB, permisoC, permisoD, permisoE,
                titulacionMax_Eso, titulacionMax_Bach, titulacionMax_Fp,
                titulacionMax_Uni, titulacionMax_Otra, sexo_Hombre, sexo_Mujer;


            public FichaPersona(string dni, string nombre, string apellido1, string apellido2,
                string strTitulacionMax_Otra, bool permisoA, bool permisoB, bool permisoC, 
                bool permisoD, bool permisoE, bool titulacionMax_Eso, bool titulacionMax_Bach, 
                bool titulacionMax_Fp, bool titulacionMax_Uni, bool titulacionMax_Otra, 
                bool sexo_Hombre, bool sexo_Mujer)
            {
                this.dni = dni;
                this.nombre = nombre;
                this.apellido1 = apellido1;
                this.apellido2 = apellido2;
                this.strTitulacionMax_Otra = strTitulacionMax_Otra;
                this.permisoA = permisoA;
                this.permisoB = permisoB;
                this.permisoC = permisoC;
                this.permisoD = permisoD;
                this.permisoE = permisoE;
                this.titulacionMax_Eso = titulacionMax_Eso;
                this.titulacionMax_Bach = titulacionMax_Bach;
                this.titulacionMax_Fp = titulacionMax_Fp;
                this.titulacionMax_Uni = titulacionMax_Uni;
                this.titulacionMax_Otra = titulacionMax_Otra;
                this.sexo_Hombre = sexo_Hombre;
                this.sexo_Mujer = sexo_Mujer;
            }
        }

        // Validaciones de campos

        private bool validarCajaTexto(string txt) 
        {
            if (txt != "") return true;
            else return false;
        }

        private bool buscarDni(string dni)
        {
            foreach (FichaPersona f in fichas)
            {
                if (dni == f.dni) return true;

            }
            return false;
        }

        private bool ComprobarOtra(string txt)
        {
            if (txt != "") return true;
            else
            {
                advertencia("si se selleciona Otra como titulación máxima se debe escribir cual es en el campo de texto");
                otra_TextBox.Focus();
                return false;
            }
        }

        // advertencias

        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Guardamos los datos en el struct
        private bool GuardarDatos()
        {
            if(fichas.Count <= FICHAS_MAX)
            {
                fichas.Add(new FichaPersona(dni_TextBox.Text, nombre_TextBox.Text, apellido1_TextBox.Text, apellido2_TextBox1.Text
                , otra_TextBox.Text, A_CheckBox.IsChecked.Value, B_CheckBox.IsChecked.Value, C_CheckBox.IsChecked.Value,
                D_CheckBox.IsChecked.Value, E_CheckBox.IsChecked.Value, eso_Rbtn.IsChecked.Value, bach_Rbtn.IsChecked.Value, fp_Rbtn.IsChecked.Value,
                uni_Rbtn.IsChecked.Value, otra_Rbtn.IsChecked.Value, hombre_Rbtn.IsChecked.Value, Mujer_Rbtn.IsChecked.Value
                ));
                return true;
            }
            else
            {
                advertencia("No se pueden añadir mas de diez fichas");
                return false;
            }


    }

        private void rellenarDatos()
        {
            foreach (FichaPersona x in fichas)
            {
                if(buscar_TextBox.Text == x.dni)
                {
                    dni_TextBox.Text = x.dni;
                    nombre_TextBox.Text = x.nombre;
                    apellido1_TextBox.Text = x.apellido1;
                    apellido2_TextBox1.Text = x.apellido2;
                    otra_TextBox.Text = x.strTitulacionMax_Otra;
                    A_CheckBox.IsChecked = x.permisoA;
                    B_CheckBox.IsChecked = x.permisoB;
                    C_CheckBox.IsChecked = x.permisoC;
                    D_CheckBox.IsChecked = x.permisoD;
                    E_CheckBox.IsChecked = x.permisoE;
                    eso_Rbtn.IsChecked = x.titulacionMax_Eso;
                    bach_Rbtn.IsChecked = x.titulacionMax_Bach;
                    fp_Rbtn.IsChecked = x.titulacionMax_Fp;
                    uni_Rbtn.IsChecked = x.titulacionMax_Uni;
                    otra_Rbtn.IsChecked = x.titulacionMax_Otra;
                    hombre_Rbtn.IsChecked = x.sexo_Hombre;
                    Mujer_Rbtn.IsChecked = x.sexo_Mujer;
                }
            }
        }

        private void limpiarCajas()
        {
            dni_TextBox.Text = "";
            nombre_TextBox.Text = "";
            apellido1_TextBox.Text = "";
            apellido2_TextBox1.Text = "";
            otra_TextBox.Text = "";
            A_CheckBox.IsChecked = false;
            B_CheckBox.IsChecked = false;
            C_CheckBox.IsChecked = false;
            D_CheckBox.IsChecked = false;
            E_CheckBox.IsChecked = false;
            eso_Rbtn.IsChecked = false;
            bach_Rbtn.IsChecked = false;
            fp_Rbtn.IsChecked = false;
            uni_Rbtn.IsChecked = false;
            otra_Rbtn.IsChecked = false;
            hombre_Rbtn.IsChecked = false;
            Mujer_Rbtn.IsChecked = false;
        }

        private void guardar_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (validarCajaTexto(dni_TextBox.Text))
            {
                if (!buscarDni(dni_TextBox.Text))
                {
                    if (validarCajaTexto(nombre_TextBox.Text))
                    {
                        if (validarCajaTexto(apellido1_TextBox.Text))
                        {
                            if (validarCajaTexto(apellido2_TextBox1.Text))
                            {
                                if (hombre_Rbtn.IsChecked == true || Mujer_Rbtn.IsChecked == true)
                                {
                                    if (Ninguna_Rbtn.IsChecked == true || eso_Rbtn.IsChecked == true || bach_Rbtn.IsChecked == true
                                        || fp_Rbtn.IsChecked == true || uni_Rbtn.IsChecked == true || (otra_Rbtn.IsChecked == true && ComprobarOtra(otra_TextBox.Text)))
                                    {

                                        if (GuardarDatos())
                                        {
                                            limpiarCajas();
                                            MessageBox.Show("se ha añadido la ficha de esta persona correctamente", "Anadida la Persona a la ficha", MessageBoxButton.OK, MessageBoxImage.Information);
                                        }

                                    }
                                    else
                                    {
                                        advertencia("se debe seleccionar una titulación máxima");
                                    }
                                }
                                else
                                {
                                    advertencia("se debe seleccionar un sexo");
                                }
                            }
                            else
                            {
                                advertencia("El campo segundo apellido esta vacio");
                                apellido2_TextBox1.Focus();
                            }
                        }
                        else
                        {
                            advertencia("El campo primer apellido esta vacio");
                            apellido1_TextBox.Focus();
                        }
                    }
                    else
                    {
                        advertencia("El campo Nombre esta vacio");
                        nombre_TextBox.Focus();
                    }
                }
                else
                {
                    advertencia("esta persona ya esta guardada");
                    dni_TextBox.Focus();
                }
             }
            else
            {
                advertencia("El campo DNI esta vacio");
                dni_TextBox.Focus();
            }
        }

        private void buscar_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (validarCajaTexto(buscar_TextBox.Text))
            {
                if (buscarDni(buscar_TextBox.Text))
                {
                    limpiarCajas();
                    rellenarDatos();
                }
                else
                {
                    advertencia("Esta persona no existe");
                }
            }
            else
            {
                advertencia("se debe introducir un dni para buscar una persona");
            }
        }

        private void otra_Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            otra_TextBox.IsEnabled = true;
            otra_TextBox.Focus();
        }

        private void otra_Rbtn_Unchecked(object sender, RoutedEventArgs e)
        {
            otra_TextBox.Text = "";
            otra_TextBox.IsEnabled = false;
        }
    }
}
