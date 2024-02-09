using ComunidadVecinos.Domain;
using ComunidadVecinos.ViewModel.ComunidadVecinos.Domain;
using ComunidadVecinos.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace ComunidadVecinos.View
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private int numPortales;
        private int numEscaleras;
        private int numPlantas;
        bool veridicado = false;
        private Window2 ventana;


        //Objetos de comunidades 
        private ComunidadModelView modelCommunity = new ComunidadModelView();
        private PlantaModelView modelPLant = new PlantaModelView();
        private PortalModelView modelPortal = new PortalModelView();
        private EscaleraModelView modelstair = new EscaleraModelView();
        private PisoModelView modelPiso = new PisoModelView();
        private PropietarioModelView2 modelPropietario =new PropietarioModelView2();
        public Window2()
        {
            InitializeComponent();
            datospropietario.IsEnabled = false;
            DataContext = modelPropietario;
            comboBoxPortalProp.IsEnabled = false;
            comboBoxEscaleraProp.IsEnabled = false;
            comboBoxPlantaProp.IsEnabled = false;
            comboBoxPisoPorp.IsEnabled = false;
            modelCommunity.LoadCommunities();
            LlenarComboBoxLista(comboBoxComunidadProp, modelCommunity.Comunidades);

        }
        private void comboBoxComunidadProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            modelCommunity.LoadCommunities();           
            modelCommunity.Nombre = ObtenerComboSeleccionado(comboBoxComunidadProp);
            comboBoxPortalProp.IsEnabled = true;
            modelPortal.IdComunidad = ComunidadModelView.ObtenerIdComunidadPorNombre(modelCommunity.Nombre);
            numPortales = modelPortal.contarPortalesComunidad(modelCommunity.Nombre);
            modelPortal.Number = "Portal";
            LlenarComboBox(comboBoxPortalProp, numPortales, modelPortal.Number);
           

        }

        private void comboBoxPortalProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            modelPortal.Number = ObtenerComboSeleccionado(comboBoxPortalProp);
            comboBoxEscaleraProp.IsEnabled = true;
            modelstair.IdPortal = modelPortal.SacarIdPortal();
            numEscaleras = modelstair.contarEscalerasPortal();
            modelstair.Nombre = "Escalera";
            LlenarComboBox(comboBoxEscaleraProp, numEscaleras, modelstair.Nombre);
           


        }
        private void comboBoxEscaleraProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            modelstair.Nombre = ObtenerComboSeleccionado(comboBoxEscaleraProp);
            comboBoxPlantaProp.IsEnabled = true;
            modelPLant.IdEscalera = modelstair.SacarIdEscalera();
            numPlantas = modelPLant.contarPlantasEscalera();
            modelPLant.NumberPlanta = "Planta";
            LlenarComboBox(comboBoxPlantaProp, numPlantas, modelPLant.NumberPlanta);
           


        }
        private void comboBoxPlantaProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            modelPLant.NumberPlanta = ObtenerComboSeleccionado(comboBoxPlantaProp);
            comboBoxPisoPorp.IsEnabled = true;
            modelPiso.IdPlantas = modelPLant.SacarIdPlanta();
            modelPiso.LoadPiso();
            LlenarComboBoxLista2(comboBoxPisoPorp, modelPiso.PisoList);
            modelPiso.PisoList.Clear(); 

        }
        private void comboBoxPisoProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelPiso.NumeroPiso = ObtenerComboSeleccionado(comboBoxPisoPorp);
            modelPropietario.IdPiso = modelPiso.SacarIdPiso();
            comboBoxComunidadProp.IsEnabled = false;
            comboBoxPortalProp.IsEnabled = false;
            comboBoxEscaleraProp.IsEnabled = false;
            comboBoxPlantaProp.IsEnabled = false;
            comboBoxPisoPorp.IsEnabled = false;
            veridicado = true;
        }
        private void AñadirUbicacionPropietario(object sender, RoutedEventArgs e)
        {
            if (veridicado)
            {
                MessageBox.Show("Piso seleccionado para agregar propietario");
                datospropietario.IsEnabled = true;
                datospropietario.Focus();
            }
            else
            {
                MessageBox.Show("Elija bien el campo Porfavor");
            }

        }

        private async void GuardarPropietario(object sender, RoutedEventArgs e)
        {
           
            // Validar que todos los campos estén rellenos
            if (string.IsNullOrWhiteSpace(modelPropietario.Nombre) ||
                string.IsNullOrWhiteSpace(modelPropietario.Apellido) ||
                string.IsNullOrWhiteSpace(modelPropietario.Dni) ||
                string.IsNullOrWhiteSpace(modelPropietario.Provincia) ||
                string.IsNullOrWhiteSpace(modelPropietario.Localidad) ||
                string.IsNullOrWhiteSpace(modelPropietario.CodigoPostal.ToString()))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validar que el código postal sea un número
            int codigoPostal;
            if (!int.TryParse(modelPropietario.CodigoPostal.ToString(), out codigoPostal))
            {
                MessageBox.Show("El código postal debe ser un número.", "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (modelPropietario.ComprobarPropietarios(modelPropietario.Dni))
            {
                MessageBox.Show("El dni del usuario ya esta registrado");
                return;
            }
            modelPropietario.AñadirPropietario();
            MessageBox.Show("Porpietario añadido correctamente");
            
            await Task.Delay(1300);
            this.Close();


        }
        //Metodos
        private string ObtenerComboSeleccionado(ComboBox comboBoxPortal)
        {
            if (comboBoxPortal.SelectedItem != null)
            {
                // Obtener el valor seleccionado del ComboBox (asumiendo que el contenido es un string)
                string selectedText = comboBoxPortal.SelectedItem.ToString();

                // Dividir la cadena para obtener solo la parte necesaria
                string[] parts = selectedText.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 1)
                {
                    // Tomar la segunda parte después de dividir
                    string cleanedText = parts[1].Trim();

                    // Limpia el texto para asegurarte de que solo contenga caracteres seguros para SQL
                    cleanedText = MySql.Data.MySqlClient.MySqlHelper.EscapeString(cleanedText);

                    return cleanedText;
                }
            }

            return null;
        }
        private void LlenarComboBox(ComboBox comboBox, int numeroOpciones, string nombre)
        {
            // Limpiar el ComboBox antes de volver a llenarlo
            comboBox.Items.Clear();

            // Llenar el ComboBox con el número de opciones según el bucle
            for (int i = 1; i <= numeroOpciones; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = $"{nombre} {i}";
                comboBox.Items.Add(item);
            }
        }
        private void LlenarComboBoxLista(ComboBox comboBox, ObservableCollection<Comunidad> comunidades)
        {
            // Limpiar el ComboBox antes de volver a llenarlo
            comboBox.Items.Clear();

            // Llenar el ComboBox con el número de opciones según el bucle
            foreach (Comunidad comunidad in comunidades)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = comunidad.Nombre;
                comboBox.Items.Add(item);
            }
        }
        private void LlenarComboBoxLista2(ComboBox comboBox, ObservableCollection<Piso> Pisos)
        {
            
            // Limpiar el ComboBox antes de volver a llenarlo
            comboBox.Items.Clear();

            // Llenar el ComboBox con el número de opciones según el bucle
            foreach (Piso piso in Pisos)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = piso.NumeroPiso;
                comboBox.Items.Add(item);
            }
        }
    }
}

