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

        private void AñadirUbicacionPropietario(object sender, RoutedEventArgs e)
        {
            // Verificar qué botón fue clickeado
            if (sender == btnCrearComunidad)
            {
                // Abrir Window1
                Window1 window1 = new Window1();
                window1.Show();
            }
            else if (sender == btnAñadirPropietarios)
            {
                // Abrir Window2
                Window2 window2 = new Window2();
                window2.Show();
            }
        }
    }
}
