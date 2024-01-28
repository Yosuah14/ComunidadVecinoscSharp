using ComunidadVecinos.Domain;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
    public class PortalModelView : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;
        private const string cnstr = "server=localhost;uid=Jose;pwd=josepablo;database=vecindario";

        // Método para notificar cambios en las propiedades
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Atributos
        private int idPortal;
        private int? idComunidad;
        private string number;// Puede ser nulo si no está asociado a una comunidad

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
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        // Constructor
        public PortalModelView()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }

        public PortalModelView(string numeroPortal)
        {
           this.number = numeroPortal;
        }

        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdPortal: {IdPortal}\n" +
                   $"IdComunidad: {IdComunidad}";
        }

        public void insertarPortales(int? idComunidad, int numeroPortales)
        {
            string SQL;
            for (int i = 1; i <= numeroPortales; i++)
            {
                SQL = $"INSERT INTO portal (idComunidad, numeroPortal) VALUES ('{idComunidad}', '{number} {i}');";
                MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
            }
        }

        public int contarPortalesComunidad(string ncomunidad)
        {
            int idComunidad = ComunidadModelView.ObtenerIdComunidadPorNombre(ncomunidad);
            string SQL = $"SELECT COUNT(*) FROM portal WHERE idComunidad = {idComunidad};";

            DataTable dt = MySQLDataManagement.LoadData(SQL, cnstr);

            int count = 0;
            if (dt.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt.Rows[0][0]);
            }

            dt.Dispose();
            return count;
        }
        public int SacarIdPortal()
        {
            if (idComunidad.HasValue)
            {
                string SQL = $"SELECT idPortal FROM portal WHERE idComunidad = {idComunidad} and numeroPortal = '{number}' ;";

                DataTable dt = MySQLDataManagement.LoadData(SQL, cnstr);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]);
                }
                else
                {
                    // Devolver un valor predeterminado (puedes cambiar esto según tus necesidades)
                    return -1;
                }
            }
            else
            {
                // Devolver un valor predeterminado (puedes cambiar esto según tus necesidades)
                return -1;
            }
        }

        // Otros métodos si es necesario
    }
}

    
