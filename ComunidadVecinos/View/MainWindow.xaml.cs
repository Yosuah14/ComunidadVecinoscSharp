using ComunidadVecinos.View;
using System.Threading.Tasks;
using System.Windows;


namespace ComunidadVecinos
{
    //Para elegir la opcion que quieres
    //Sino has creado ninguna comunidad creala antes de añadir propietarios
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AñadirUbicacionPropietario(object sender, RoutedEventArgs e)
        {
            Window3 windowloading= new Window3();
            // Mostrar la ventana de carga durante 3 segundos
            windowloading.Visibility = Visibility.Visible;
            await Task.Delay(2000); // Esperar 3 segundos
            windowloading.Visibility = Visibility.Collapsed;

            // Determinar qué botón fue clickeado y abrir la ventana correspondiente
            if (sender == btnCrearComunidad)
            {
                Window1 window1 = new Window1();
                window1.Show();
            }
            else if (sender == btnAñadirPropietarios)
            {
                Window2 window2 = new Window2();
                window2.Show();
            }
        }
    }
}
