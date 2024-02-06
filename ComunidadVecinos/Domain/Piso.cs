using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class Piso : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        // Atributos
        private int idPlantas;
        private int idPiso;
        private int parking_idParking;
        private string numeroPiso;
        private int trastero_idTrastero;
        private ObservableCollection<Propietario> pisoList;

        public Piso(string numeroPiso)
        {
            this.numeroPiso = numeroPiso;
        }

        // Propiedades
        public ObservableCollection<Propietario> PisoList
        {
            get { return pisoList; }
            set
            {
                pisoList = value;
                OnPropertyChanged("IdPlantas");
            }
        }
        public int IdPlantas
        {
            get { return idPlantas; }
            set
            {
                idPlantas = value;
                OnPropertyChanged("IdPlantas");
            }
        }

        public int IdPiso
        {
            get { return idPiso; }
            set
            {
                idPiso = value;
                OnPropertyChanged("IdPiso");
            }
        }

        public int Parking_idParking
        {
            get { return parking_idParking; }
            set
            {
                parking_idParking = value;
                OnPropertyChanged("Parking_idParking");
            }
        }

        public string NumeroPiso
        {
            get { return numeroPiso; }
            set
            {
                numeroPiso = value;
                OnPropertyChanged("NumeroPiso");
            }
        }

        public int Trastero_idTrastero
        {
            get { return trastero_idTrastero; }
            set
            {
                trastero_idTrastero = value;
                OnPropertyChanged("Trastero_idTrastero");
            }
        }

        // Constructor
        public Piso()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }

        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdPlantas: {IdPlantas}\n" +
                   $"IdPiso: {IdPiso}\n" +
                   $"Parking_idParking: {Parking_idParking}\n" +
                   $"NumeroPiso: {NumeroPiso}\n" +
                   $"Trastero_idTrastero: {Trastero_idTrastero}";
        }
    }
}
