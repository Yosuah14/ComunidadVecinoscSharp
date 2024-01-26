using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class Portal : INotifyPropertyChanged
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
        private int idPortal;
        private int? idComunidad; // Puede ser nulo si no está asociado a una comunidad

        // Propiedades
        public int IdPortal
        {
            get { return idPortal; }
            set
            {
                idPortal = value;
                OnPropertyChanged("IdPortal");
            }
        }

        public int? IdComunidad
        {
            get { return idComunidad; }
            set
            {
                idComunidad = value;
                OnPropertyChanged("IdComunidad");
            }
        }

        // Constructor
        public Portal()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }

        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdPortal: {IdPortal}\n" +
                   $"IdComunidad: {IdComunidad}";
        }
    }
}
