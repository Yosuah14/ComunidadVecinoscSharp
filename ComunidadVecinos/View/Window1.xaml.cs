using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace ComunidadVecinos.View
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void FinishDataCommunity(object sender, RoutedEventArgs e)
        {
            // Validar los valores antes de crear la comunidad
            if (ValidateInput())
            {
                // Obtener los valores de los controles en la interfaz de usuario
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;

                // Validar y obtener el valor de Fecha de Creación
                if (DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaCreacion))
                {
                    // Validar y obtener el valor de Metros Cuadrados
                    if (decimal.TryParse(txtMetrosCuadrados.Text, out decimal metrosCuadrados))
                    {
                        // Obtener valores de CheckBoxes
                        byte piscina = chPiscina.IsChecked == true ? (byte)1 : (byte)0;
                        byte parqueInfantil = chParqueInfantil.IsChecked == true ? (byte)1 : (byte)0;
                        byte maquinasEjercicio = chMaquinasEjercicio.IsChecked == true ? (byte)1 : (byte)0;
                        byte salaReuniones = chSalaReuniones.IsChecked == true ? (byte)1 : (byte)0;
                        byte pistaTenis = chPistaTenis.IsChecked == true ? (byte)1 : (byte)0;
                        byte pistaPadel = chPistaPadel.IsChecked == true ? (byte)1 : (byte)0;



                        // Crear una nueva instancia de Comunidad con los valores obtenidos
                        Comunidad nuevaComunidad = new Comunidad
                        {
                            Nombre = nombre,
                            Direccion = direccion,
                            FechaCreacion = fechaCreacion.ToString("dd/MM/yyyy"),
                            MetrosCuadrados = metrosCuadrados,
                            Piscina = piscina,
                            ParqueInfantil = parqueInfantil,
                            MaquinasEjercicio = maquinasEjercicio,
                            SalaReuniones = salaReuniones,
                            PistaTenis = pistaTenis,
                            PistaPadel = pistaPadel,

                            // Configurar otras propiedades según sea necesario...
                        };

                        // Mostrar la información de la nueva comunidad en un cuadro de diálogo (puedes cambiar esto según tus necesidades)
                        MessageBox.Show(nuevaComunidad.ToString(), "Nueva Comunidad Creada");

                        // Aquí puedes realizar más acciones según sea necesario con la nueva comunidad
                    }
                    else
                    {
                        ShowError("El valor de Metros Cuadrados no es válido.");
                    }
                }
                else
                {
                    ShowError("El formato de la Fecha de Creación no es válido. Utiliza el formato dd/MM/yyyy.");
                }
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                ShowError("Por favor, completa todos los campos.");
                return false;
            }
            return true;
        }
        private void ShowError (string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
