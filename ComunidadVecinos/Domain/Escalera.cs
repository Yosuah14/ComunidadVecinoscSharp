using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    namespace ComunidadVecinos.Domain
    {
        public class Escalera : INotifyPropertyChanged
        {
            // Evento para notificar cambios en las propiedades
            public event PropertyChangedEventHandler PropertyChanged;

            // Atributos
            private int idEscalera;
            private int idPortal; // Asumiendo que cada escalera está asociada a un portal

            // Propiedades
            public int IdEscalera
            {
                get { return idEscalera; }
                set
                {
                    idEscalera = value;
                    OnPropertyChanged(nameof(IdEscalera));
                }
            }

            public int IdPortal
            {
                get { return idPortal; }
                set
                {
                    idPortal = value;
                    OnPropertyChanged(nameof(IdPortal));
                }
            }


            // Constructor
            public Escalera()
            {
                // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
            }

            // Método OnPropertyChanged
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            // Otros métodos si es necesario
        }
    }
}
