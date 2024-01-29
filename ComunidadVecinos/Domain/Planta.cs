using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class Planta : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para notificar cambios en las propiedades
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Atributos
        private int idEscalera;
        private int? idPlanta;
        private string numberPlanta;// Puede ser nulo si no está asociado a una comunidad

        // Propiedades
        public int IdEscalera
        {
            get { return idEscalera; }
            set
            {
                idEscalera = value;
                OnPropertyChanged("IdEscalera");
            }
        }
        public string NumberPlanta
        {
            get { return numberPlanta; }
            set
            {
                numberPlanta = value;
                OnPropertyChanged("NumberPlanta");
            }
        }

        public int? IdPlanta
        {
            get { return idPlanta; }
            set
            {
                idPlanta = value;
                OnPropertyChanged("IdPlanta");
            }
        }

        // Constructor
        public Planta()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }

        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdPlanta: {IdPlanta}\n" +
                   $"IdEscalera: {IdEscalera}";
        }
    }
}

