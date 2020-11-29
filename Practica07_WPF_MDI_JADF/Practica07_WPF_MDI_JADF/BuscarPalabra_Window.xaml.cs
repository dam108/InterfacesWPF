using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica07_WPF_MDI_JADF
{
    /// <summary>
    /// Lógica de interacción para BuscarPalabra_Window.xaml
    /// </summary>
    public partial class BuscarPalabra_Window : Window
    {
        String rutaArchivoOriginal;

        public ObservableCollection<Linea> lineas;

        public static RoutedCommand BuscarCommand = new RoutedCommand();


        public BuscarPalabra_Window()
        {
            InitializeComponent();
            lineas = new ObservableCollection<Linea>();

            mostrarLineas_ListBox.ItemsSource = lineas;
            this.DataContext = this;


            CommandBinding BuscarCommandBinding = new CommandBinding(
                BuscarCommand, ExecuteBuscarCommand, CanExecuteBuscarCommand);
        }

        private void ExecuteBuscarCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if(rutaArchivoOriginal != null)
            {
                string palabra = palabraBuscar_TextBox.Text;


                MessageBox.Show("Este proceso puede tardar!", "información", MessageBoxButton.OK, MessageBoxImage.Information);

                IEnumerable<TextRange> wordRanges = GetAllWordRanges(mostrarTexto_RichTextBox.Document);
                foreach (TextRange wordRange in wordRanges)
                {
                    if (wordRange.Text == palabra)
                    {
                        wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                    }
                }

                using (var sr = new StreamReader(rutaArchivoOriginal))
                {
                    int index = 0;
                    while (!sr.EndOfStream)
                    {
                        index++;
                        var line = sr.ReadLine();
                        if (String.IsNullOrEmpty(line)) continue;
                        if (line.IndexOf(palabraBuscar_TextBox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            //MessageBox.Show("Se agrago una linea");
                            lineas.Add(new Linea(index.ToString()));
                        }
                    }
                }

            }
            else
            {
                advertencia("Seleccione un documento primero!");
            }

        }
        private void CanExecuteBuscarCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if(palabraBuscar_TextBox.Text != "")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            
        }

        private void AbirDocumento_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog elegirArchivo = new OpenFileDialog();
            if (elegirArchivo != null)
            {
                try
                {
                    elegirArchivo.ShowDialog();

                    mostrarTexto_RichTextBox.Document.Blocks.Clear();

                    string[] leerArchivo = File.ReadAllLines(elegirArchivo.FileName);
                    rutaArchivoOriginal = elegirArchivo.FileName;

                    foreach (var linea in leerArchivo)
                    {
                        mostrarTexto_RichTextBox.AppendText(linea);
                    }

                }
                catch (ArgumentException)
                {
                    advertencia("no se puede dejar vacio la seleccion de la documento");
                }
            }
        }

        private void BorrarLinea_Click(object sender, RoutedEventArgs e)
        {
            if (mostrarLineas_ListBox.SelectedIndex >= 0)
            {
                int n = Int16.Parse(lineas[mostrarLineas_ListBox.SelectedIndex].Nombre);
                List<String> texto = new List<string>();

                //Abrir y leer un archivo de texto linea a linea

                try
                {
                    StreamReader sr = new StreamReader(rutaArchivoOriginal);

                    String linea;


                    while ((linea = sr.ReadLine()) != null)
                    {
                        texto.Add(linea);
                    }

                    sr.Close();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("No se ha encontrado el archivo");
                }

                if (n >= 0)
                {
                    texto.RemoveAt(n - 1);
                    lineas.Clear();
                    palabraBuscar_TextBox.Clear();
                    File.WriteAllLines(rutaArchivoOriginal, texto.ToArray());
                    //string leerArchivo = File.ReadAllText(rutaArchivoOriginal);
                    //mostrarTexto_RichTextBox.Text = leerArchivo;


                    mostrarTexto_RichTextBox.Document.Blocks.Clear();

                    string[] leerArchivo = File.ReadAllLines(rutaArchivoOriginal);

                    foreach (var linea in leerArchivo)
                    {
                        mostrarTexto_RichTextBox.AppendText(linea);
                    }

                }
                else
                {
                    advertencia("No hay una linea seleccionada para borrar");
                }

            }
        }

        private void CopiarLinea_Click(object sender, RoutedEventArgs e)
        {
            int n = Int16.Parse(lineas[mostrarLineas_ListBox.SelectedIndex].Nombre);
            int linea = n - 1;

            try
            {
                // abrimos el archivo del que queremos leer
                string[] datos = File.ReadAllLines(rutaArchivoOriginal);

                // sacamos el nombre del archivo de su ruta 
                string nombreArchivo = sacarNombre(rutaArchivoOriginal);

                // guardamos la linea en el archivo y si no existe lo creamos
                // se va guardar en la carpeta debug
                File.AppendAllText("lineas" + nombreArchivo, datos[linea] + "\n");
                MessageBox.Show("Se ha guardado la linea correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                Console.WriteLine("No se ha encontrado el archivo");
            }
        }

        public static IEnumerable<TextRange> GetAllWordRanges(FlowDocument document)
        {
            string pattern = @"[^\W\d](\w|[-']{1,2}(?=\w))*";
            TextPointer pointer = document.ContentStart;
            while (pointer != null)
            {
                if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = pointer.GetTextInRun(LogicalDirection.Forward);
                    MatchCollection matches = Regex.Matches(textRun, pattern);
                    foreach (Match match in matches)
                    {
                        int startIndex = match.Index;
                        int length = match.Length;
                        TextPointer start = pointer.GetPositionAtOffset(startIndex);
                        TextPointer end = start.GetPositionAtOffset(length);
                        yield return new TextRange(start, end);
                    }
                }

                pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
            }
        }


        private void advertencia(string txt)
        {
            MessageBox.Show(txt, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void palabraBuscar_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show("Cambio la palabra");
            // Desacemos la seleccion pintando todas las palabras de negro
            IEnumerable<TextRange> wordRanges = GetAllWordRanges(mostrarTexto_RichTextBox.Document);
            foreach (TextRange wordRange in wordRanges)
            {
                 wordRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            }
            lineas.Clear();
        }

        private string sacarNombre(string path)
        {
            return System.IO.Path.GetFileName(path);
        }
    }


    public class Linea
    {
        public Linea(string nombre)
        {
            this.Nombre = nombre;
            this.NombreMostrar = "Linea: " + nombre;
        }

        public string Nombre { get; set; }
        public string NombreMostrar { get; set; }
    }
}
