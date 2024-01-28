﻿using ComunidadVecinos.Domain;
using ComunidadVecinos.ViewModel;
using ComunidadVecinos.ViewModel.ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static Mysqlx.Crud.Order.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComunidadVecinos.View
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ComunidadModelView modelCommunity = new ComunidadModelView();
        private PortalModelView modelPortal = new PortalModelView();
        private EscaleraModelView modelstair= new EscaleraModelView();

        public Window1()
        {
            InitializeComponent();
            DataContext = modelCommunity;
            modelCommunity.LoadCommunities();
        }
        private void FinishDataCommunity(object sender, RoutedEventArgs e)
        {
            // Validar los valores antes de crear la comunidad
            if (ValidateInput())
            {
                // Obtener los valores de los controles en la interfaz de usuario
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;

                if (modelCommunity.MetrosCuadrados.HasValue && modelCommunity.MetrosCuadrados.Value > 0)
                {
                    // Validar y obtener el valor de Fecha de Creación
                    if (DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaCreacion))
                    {
                        // Validar y obtener el valor de Metros Cuadrados

                        modelCommunity.Piscina = (byte)(chPiscina.IsChecked == true ? 1 : 0);
                        modelCommunity.ParqueInfantil = (byte)(chParqueInfantil.IsChecked == true ? 1 : 0);
                        modelCommunity.MaquinasEjercicio = (byte)(chMaquinasEjercicio.IsChecked == true ? 1 : 0);
                        modelCommunity.SalaReuniones = (byte)(chSalaReuniones.IsChecked == true ? 1 : 0);
                        modelCommunity.PisoPortero = (byte)(chPisoPortero.IsChecked == true ? 1 : 0);
                        modelCommunity.PistaTenis = (byte)(chPistaTenis.IsChecked == true ? 1 : 0);
                        modelCommunity.ZonaDuchasBanio = (byte)(chZonaDuchasBanio.IsChecked == true ? 1 : 0);
                        modelCommunity.PistaPadel = (byte)(chPistaPadel.IsChecked == true ? 1 : 0);

                        if (modelCommunity.Comunidades == null)
                            modelCommunity.Comunidades = new ObservableCollection<Comunidad>();

                        if (modelCommunity.Comunidades.Where(x=> x.Nombre == modelCommunity.Nombre).FirstOrDefault() == null)
                        {
                            modelCommunity.Comunidades.Add(
                                new Comunidad
                                {
                                    Nombre = modelCommunity.Nombre,
                                    Direccion = modelCommunity.Direccion,
                                    FechaCreacion = fechaCreacion.ToString(),
                                    MetrosCuadrados = modelCommunity.MetrosCuadrados,
                                    Piscina = modelCommunity.Piscina,
                                    ParqueInfantil = modelCommunity.ParqueInfantil,
                                    MaquinasEjercicio = modelCommunity.MaquinasEjercicio,
                                    PisoPortero = modelCommunity.PisoPortero,
                                    ZonaDuchasBanio = modelCommunity.ZonaDuchasBanio,
                                    SalaReuniones = modelCommunity.SalaReuniones,
                                    PistaTenis = modelCommunity.PistaTenis,
                                    PistaPadel = modelCommunity.PistaPadel
                              
                                });

                            Comunidad nuevaComunidad = modelCommunity.Comunidades.LastOrDefault();

                            if (nuevaComunidad != null)
                            {
                                MessageBox.Show($"Nueva Comunidad Creada: {nuevaComunidad.ToString()}", "Nueva Comunidad Creada");
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron nuevas comunidades", "Nueva Comunidad Creada");
                            }
                            modelCommunity.NewComunity();
                            pestañaportales.Focus();
                            
                        }
                        else
                        {
                            foreach (Comunidad c in modelCommunity.Comunidades)
                            {
                                if (c.Nombre.Equals(modelCommunity.Nombre))
                                {
                                    c.Direccion = modelCommunity.Direccion;
                                    c.FechaCreacion = fechaCreacion.ToString();
                                    c.MetrosCuadrados = modelCommunity.MetrosCuadrados;
                                    c.Piscina = modelCommunity.Piscina;
                                    c.ParqueInfantil = modelCommunity.ParqueInfantil;
                                    c.MaquinasEjercicio = modelCommunity.MaquinasEjercicio;
                                    c.PisoPortero = modelCommunity.PisoPortero;
                                    c.ZonaDuchasBanio = modelCommunity.ZonaDuchasBanio;
                                    c.SalaReuniones = modelCommunity.SalaReuniones;
                                    c.PistaTenis = modelCommunity.PistaTenis;
                                    c.PistaPadel = modelCommunity.PistaPadel;
                                    break;
                                }
                                modelCommunity.UpdateCommunity();
                            }
                            comunidaNombrePortales.Text = "Comunidad:" + modelCommunity.Nombre;

                            pestañaportales.Focus();                    
                            
                         
                        }
                    }
                    else
                    {
                        ShowError("El formato de la Fecha de Creación no es válido. Utiliza el formato dd/MM/yyyy.");
                    }
                }
                else
                {
                    ShowError("El valor de metros cuadrados no es válido.");
                }
            }
            else
            {
                ShowError("El valor de Metros Cuadrados no es válido.");
            }
        }
        private void AñadirPortales(object sender, RoutedEventArgs e)
        {
            // Obtener el número de portales desde la TextBox
            if (int.TryParse(txtNumeroPortales.Text, out int numeroPortales))
            {
                modelPortal.IdComunidad = ComunidadModelView.ObtenerIdComunidadPorNombre(modelCommunity.Nombre);
                
                MessageBox.Show($"Se añadirán {numeroPortales} portales a la comunidad.");                
                modelPortal.Number = $"Portal";
                modelPortal.insertarPortales(modelPortal.IdComunidad, numeroPortales);
                int numPortales = modelPortal.contarPortalesComunidad(modelCommunity.Nombre);
                LlenarComboBox(numPortales, "Portal");
                
                pestañaescaleras.Focus();
            }
            else
            {
                // Manejar el caso en el que la entrada no sea un número entero
                MessageBox.Show("Por favor, ingresa un número entero válido.");
            }
        }
        private void AñadirUnaEscalera(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtNumeroEscaleras.Text, out int numeroEscaleras))
            {
                modelstair.Nombre = "Escalera";
                modelPortal.Number = ObtenerPortalSeleccionado();
                modelstair.IdPortal = modelPortal.SacarIdPortal();
                MessageBox.Show($"Se añadirán {numeroEscaleras} escaleras al {modelPortal.Number} de la comunidad.");
                modelstair.insertarEscaleras(numeroEscaleras);

                //LlenarComboBox(numPortales, modelstair.Nombre);

                pestañaescaleras.Focus();
            }
            else
            {
                // Manejar el caso en el que la entrada no sea un número entero
                MessageBox.Show("Por favor, ingresa un número entero válido.");
            }  

        }

            private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permitir solo dígitos (números) en la TextBox
            e.Handled = !int.TryParse(e.Text, out _);
        }
        private void LlenarComboBox(int numeroOpciones,string nombre)
        {
            // Limpiar el ComboBox antes de volver a llenarlo
            comboBoxPortal.Items.Clear();

            // Llenar el ComboBox con el número de opciones según el bucle
            for (int i = 1; i <= numeroOpciones; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = $"{nombre} {i}";   
                comboBoxPortal.Items.Add(item);
            }
        }
        private string ObtenerPortalSeleccionado()
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
