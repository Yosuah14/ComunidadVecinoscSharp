using ComunidadVecinos.View;
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

namespace ComunidadVecinos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            await Task.Delay(3000); // Esperar 3 segundos
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
