using ComunidadVecinos.Domain.ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class PisoModelView : INotifyPropertyChanged
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
        private int numeroPiso;
        private int trastero_idTrastero;

        // Propiedades
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

        public int NumeroPiso
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
        public PisoModelView()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }
        public void insertarPiso(int numPisos)
        {
            string SQL;
            const int ascii = 64;
            for (int i = 1; i <= numPisos; i++)
            {
                SQL = $"INSERT INTO piso (idEscalera, numeroPlanta) VALUES ('{idEscalera}', '{numberPlanta} {i}');";
                MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
            }
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
