﻿using ComunidadVecinos.Domain;
using ComunidadVecinos.ViewModel;
using ComunidadVecinos.ViewModel.ComunidadVecinos.Domain;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;


namespace ComunidadVecinos.View
{
/// <summary>
/// Lógica de interacción para Window1.xaml
/// </summary>
public partial class Window1 : Window
{
//NUMERO DE SITIOS DE LA COMUNIDAD
private int numPortales;
private int numEscaleras;
private int numPlantas;

//Objetos de comunidades 
private ComunidadModelView modelCommunity = new ComunidadModelView();
private PlantaModelView modelPLant = new PlantaModelView();
private PortalModelView modelPortal = new PortalModelView();
private EscaleraModelView modelstair= new EscaleraModelView();
private PisoModelView modelPiso=new PisoModelView();

public Window1()
{
        InitializeComponent();
        DataContext = modelCommunity;
        modelCommunity.LoadCommunities();
        pestañaescaleras.IsEnabled = false;
        pestañapisos.IsEnabled = false;
        pestañaplantas.IsEnabled = false;
        pestañaportales.IsEnabled = false;
 }
private void FinishDataCommunity(object sender, RoutedEventArgs e)
{
DateTime? fechaCreacion = datePickerFecha.SelectedDate;
            // Validar los valores antes de crear la comunidad
            if (ValidateInput())
{
// Obtener los valores de los controles en la interfaz de usuario
string nombre = txtNombre.Text;
string direccion = txtDireccion.Text;

if (modelCommunity.MetrosCuadrados.HasValue && modelCommunity.MetrosCuadrados.Value > 0)
{
                    // Validar y obtener el valor de Fecha de Creación
if (fechaCreacion.HasValue) {

string fechaFormateada = fechaCreacion.Value.ToString("dd/MM/yyyy");
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
        pestañaportales.IsEnabled = true;
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
                        pestañaportales.IsEnabled = true;
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
//Metodo para una vez creado los portales pasar a añadir escaleras
private void AñadirPortales(object sender, RoutedEventArgs e)
{
// Obtener el número de portales desde la TextBox
if (int.TryParse(txtNumeroPortales.Text, out int numeroPortales))
{
modelPortal.IdComunidad = ComunidadModelView.ObtenerIdComunidadPorNombre(modelCommunity.Nombre);
                
MessageBox.Show($"Se añadirán {numeroPortales} portales a la comunidad.");                
modelPortal.Number = $"Portal";
modelPortal.insertarPortales(modelPortal.IdComunidad, numeroPortales);
numPortales = modelPortal.contarPortalesComunidad(modelCommunity.Nombre);
LlenarComboBox(comboBoxPortal, numPortales, modelPortal.Number);
pestañaportales.IsEnabled = false;
pestañadatosprevios.IsEnabled = false;
pestañaescaleras.IsEnabled = true;
pestañaescaleras.Focus();
}
else
{
// Manejar el caso en el que la entrada no sea un número entero
MessageBox.Show("Por favor, ingresa un número entero válido.");
}
}
//Metodo que en funcion del portal que elijas en la combo inserta en ese el numero de escaleras que pongas en la textBox
private void AñadirUnaEscalera(object sender, RoutedEventArgs e)
{
if (string.IsNullOrWhiteSpace(txtNumeroEscaleras.Text))
{
    ShowError("Por favor, completa todos los campos.");
}
if (comboBoxPortal.SelectedItem == null)
    {
        ShowError("Por favor, seleccione un portal");
    }
            
else
{
if (int.TryParse(txtNumeroEscaleras.Text, out int numeroEscaleras))
{
modelstair.Nombre = "Escalera";
modelPortal.Number = ObtenerComboSeleccionado(comboBoxPortal);
modelstair.IdPortal = modelPortal.SacarIdPortal();
MessageBox.Show($"Se añadirán {numeroEscaleras} escaleras al {modelPortal.Number} de la comunidad.");
modelstair.insertarEscaleras(numeroEscaleras);

// Elimina el elemento seleccionado d la combo box para que no añadas escaleras de mas 
EliminarItemComboBox(comboBoxPortal, modelPortal.Number);
}
else
{
// Manejar el caso en el que la entrada no sea un número entero
MessageBox.Show("Por favor, ingresa un número entero válido.");
}
}
}
private void AñadirPlantas(object sender, RoutedEventArgs e)
{
if (string.IsNullOrWhiteSpace(txtNumeroEscaleras.Text))
{
ShowError("Por favor, completa todos los campos.");
           
}
else
{
//Cuando esten todas las escaleras de todos los portales puedes pasar a añadir plantas
if (comboBoxPortal.Items.Count == 0)
{
modelPortal.Number = "Portal";
numEscaleras = modelstair.contarEscalerasPortal();
LlenarComboBox(comboBoxPortal2, numPortales, modelPortal.Number);
pestañaescaleras.IsEnabled = false;
pestañaplantas.IsEnabled = true;
pestañaplantas.Focus();
}
else
{
// Manejar el caso en el que la entrada no sea un número entero
MessageBox.Show("Por favor, ingresa un número de escaleras para cada portal.");
}
}

}

private void AñadirUnaPlanta(object sender, RoutedEventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtNumeroPlantas.Text))
    {
        ShowError("Por favor, completa todos los campos.");
    }
    else if(comboBoxEscalera.SelectedItem == null)
    {
        ShowError("Por favor, seleccione una escalera");
    }
    else if (comboBoxPortal2.SelectedItem == null)
    {
        ShowError("Por favor, selecciones un portal");
    }
        
else
{

    if (int.TryParse(txtNumeroPlantas.Text, out int numeroPlantas))
    {                              
        modelstair.IdPortal = modelPortal.SacarIdPortal();
        modelstair.Nombre = ObtenerComboSeleccionado(comboBoxEscalera);
        modelPLant.NumberPlanta = "Planta";
        modelPLant.IdEscalera = modelstair.SacarIdEscalera();
        modelPLant.insertarPlantas(numeroPlantas);
        EliminarItemComboBox(comboBoxEscalera, modelstair.Nombre);
        if (comboBoxEscalera.Items.Count == 0)
        {
            EliminarItemComboBox(comboBoxPortal2, modelPortal.Number);
            comboBoxPortal2.IsEnabled = true;
            mensajeAviso.Text = $" Selecciona el portal de la comunidad";
        }
    }
    else
    {
        ShowError("Ingrese un numero entero para las plantas");
    }
}
}

private void comboBoxPortal2_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
modelPortal.Number = ObtenerComboSeleccionado(comboBoxPortal2);
    
modelstair.IdPortal= modelPortal.SacarIdPortal();
numEscaleras = modelstair.contarEscalerasPortal();
modelstair.Nombre = "Escalera";
LlenarComboBox(comboBoxEscalera, numEscaleras, modelstair.Nombre);
    
if (comboBoxEscalera.Items.Count != 0)
{
    comboBoxPortal2.IsEnabled = false;

    // Cambiar el texto del botón cuando está deshabilitado
    mensajeAviso.Text = $"Complete todas las escaleras del {modelPortal.Number}";
                
}  
}

private void AñadirPisos(object sender, RoutedEventArgs e)
{
if (string.IsNullOrWhiteSpace(txtNumeroPlantas.Text))
{
    ShowError("Por favor, completa todos los campos.");

}
else
{
    if (comboBoxPortal2.Items.Count == 0)
    {

    modelPortal.Number = "Portal";
    LlenarComboBox(comboBoxPortal3, numPortales, modelPortal.Number);
    pestañaplantas.IsEnabled = false;
    pestañapisos.IsEnabled = true;
    pestañapisos.Focus();

    }
    else
    {
        ShowError("Por favor complete todos los datos");
    }
}
}

    private void AñadirUnPiso(object sender, RoutedEventArgs e)
    {
            if (string.IsNullOrWhiteSpace(txtNumeroPisos.Text))
            {
                ShowError("Por favor, completa todos los campos.");
            }
            else if (comboBoxEscalera2.SelectedItem == null)
            {
                ShowError("Por favor, seleccione una escalera");
            } else if (comboBoxPortal3.SelectedItem == null)
            {
                ShowError("Por favor, selecciones un portal");
            }
            else if (comboBoxPlanta.SelectedItem == null)
            {
                ShowError("Por favor, selecciones una planta");
            
            
        }
        else
        {
            if (int.TryParse(txtNumeroPisos.Text, out int numeroPisos))
            {
                modelstair.IdPortal = modelPortal.SacarIdPortal();
                modelstair.Nombre = ObtenerComboSeleccionado(comboBoxEscalera2);
                modelPLant.IdEscalera = modelstair.SacarIdEscalera();
                modelPLant.NumberPlanta= ObtenerComboSeleccionado(comboBoxPlanta);
                modelPiso.IdPlantas=modelPLant.SacarIdPlanta();
                modelPiso.insertarPiso(numeroPisos, modelPLant.NumberPlanta);
                EliminarItemComboBox(comboBoxPlanta, modelPLant.NumberPlanta);
                if (comboBoxPlanta.Items.Count == 0)
                {
                    EliminarItemComboBox(comboBoxEscalera2, modelstair.Nombre);
                    comboBoxEscalera2.IsEnabled = true;
                    mensajeAviso3.Text = $" Selecciona la planta de la escalera";
                }
                if (comboBoxEscalera2.Items.Count == 0)
                {
                    EliminarItemComboBox(comboBoxPortal3,modelPortal.Number );
                    comboBoxPortal3.IsEnabled = true;
                    mensajeAviso2.Text = $" Selecciona la escalera del portal";
                }
            }


        }
    }
    private void comboBoxPortal3_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        modelPortal.Number = ObtenerComboSeleccionado(comboBoxPortal3);
        modelstair.IdPortal = modelPortal.SacarIdPortal();
        numEscaleras = modelstair.contarEscalerasPortal();
        modelstair.Nombre = "Escalera";
        LlenarComboBox(comboBoxEscalera2, numEscaleras, modelstair.Nombre);

        if (comboBoxEscalera2.Items.Count != 0)
        {
            comboBoxPortal3.IsEnabled = false;

            // Cambiar el texto del botón cuando está deshabilitado
            mensajeAviso2.Text = $"Complete todas las escaleras del {modelPortal.Number}";

        }

    }
    private  void comboBoxEscalera2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        modelstair.Nombre = ObtenerComboSeleccionado(comboBoxEscalera2);
        modelPLant.IdEscalera=modelstair.SacarIdEscalera();
        numPlantas = modelPLant.contarPlantasEscalera();
        modelPLant.NumberPlanta = "Planta";
        LlenarComboBox(comboBoxPlanta, numPlantas, modelPLant.NumberPlanta);
        if (comboBoxPlanta.Items.Count != 0)
        {
            comboBoxEscalera2.IsEnabled = false;

            // Cambiar el texto del botón cuando está deshabilitado
            mensajeAviso3.Text = $"Complete todas las plantas del {modelstair.Nombre}";

        }
    }
        private async void CrearComunidad(object sender, RoutedEventArgs e)
    {

        if (string.IsNullOrWhiteSpace(txtNumeroPisos.Text))
        {
            ShowError("Por favor, completa todos los campos.");

        }
        else
        {
            if (comboBoxPortal3.Items.Count == 0)
            {
                MessageBox.Show("Comunidad creada correctamente!");               
                    await Task.Delay(1300);
                    this.Close();
                }
            else
            {
                ShowError("Por favor complete todos los datos");
            }
        }
    }

    //Metodos auxiliares
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

private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
{
// Permitir solo dígitos (números) en la TextBox
e.Handled = !int.TryParse(e.Text, out _);
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
