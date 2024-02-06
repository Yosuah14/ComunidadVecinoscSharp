using ComunidadVecinos.Domain;
using ComunidadVecinos.ViewModel.ComunidadVecinos.Domain;
using ComunidadVecinos.ViewModel;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

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
        private int numPisos;
        

        //Objetos de comunidades 
        private ComunidadModelView modelCommunity = new ComunidadModelView();
        private PlantaModelView modelPLant = new PlantaModelView();
        private PortalModelView modelPortal = new PortalModelView();
        private EscaleraModelView modelstair = new EscaleraModelView();
        private PisoModelView modelPiso = new PisoModelView();
        public Window2()
        {
            InitializeComponent();

        }
        private void comboBoxComunidadProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modelCommunity.LoadCommunities();
            LlenarComboBoxLista(comboBoxComunidadProp, modelCommunity.Comunidades);
            modelCommunity.Nombre = ObtenerComboSeleccionado(comboBoxComunidadProp);
            modelPortal.IdComunidad = ComunidadModelView.ObtenerIdComunidadPorNombre(modelCommunity.Nombre);


        }

        private void comboBoxPortalProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             numPortales = modelPortal.contarPortalesComunidad(modelCommunity.Nombre);
             modelPortal.Number = "Portal";
             LlenarComboBox(comboBox)



        }
        private void comboBoxEscaleraProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void comboBoxPlantaProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void comboBoxPisoProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void AñadirUbicacionPropietario(object sender, RoutedEventArgs e)
        {

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
        private void EliminarItemComboBox(ComboBox comboBox, string itemToRemove)
        {
            foreach (var item in comboBox.Items.Cast<ComboBoxItem>().ToList())
            {
                if (item.Content.ToString().Contains(itemToRemove))
                {
                    comboBox.Items.Remove(item);
                    break; // Sale del bucle después de eliminar el primer elemento coincidente
                }
            }
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
        private void LlenarComboBoxLista(ComboBox comboBox, ObservableCollection<Comunidad>comunidades)
        {
            // Limpiar el ComboBox antes de volver a llenarlo
            comboBox.Items.Clear();

            // Llenar el ComboBox con el número de opciones según el bucle
            for (int i = 1; i <= comunidades.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = comunidades[i];
                comboBox.Items.Add(item);
            }
        }
    }
}

