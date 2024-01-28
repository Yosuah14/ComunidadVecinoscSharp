using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComunidadVecinos.ViewModel
{
    namespace ComunidadVecinos.Domain
    {
        public class EscaleraModelView : INotifyPropertyChanged
        {
            // Evento para notificar cambios en las propiedades
            public event PropertyChangedEventHandler PropertyChanged;
            private const string cnstr = "server=localhost;uid=Jose;pwd=josepablo;database=vecindario";
            // Atributos
            private int idEscalera;
            private int idPortal; // Asumiendo que cada escalera está asociada a un portal
            private string nombre; // Puedes agregar más propiedades según tus necesidades

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

            public string Nombre
            {
                get { return nombre; }
                set
                {
                    nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }

            // Constructor
            public EscaleraModelView()
            {
                // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
            }
            public void insertarEscaleras(int numeroEscaleras)
            {
                string SQL;
                for (int i = 1; i <= numeroEscaleras; i++)
                {
                    SQL = $"INSERT INTO escalera (idPortal, nombreEscalera) VALUES ('{idPortal}', '{Nombre} {i}');";
                    MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
                }
            }


            // Método OnPropertyChanged
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
