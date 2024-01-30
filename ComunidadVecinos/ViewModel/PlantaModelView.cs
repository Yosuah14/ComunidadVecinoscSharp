using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComunidadVecinos.Domain
{
    public class PlantaModelView : INotifyPropertyChanged
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
        private int? idEscalera;
        private int? idPlanta;
        private string numberPlanta;// Puede ser nulo si no está asociado a una comunidad

        // Propiedades
        public int? IdEscalera
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
        public PlantaModelView()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }
        public void insertarPlantas(int numeroPlantas)
        {
            string SQL;
            for (int i = 1; i <= numeroPlantas; i++)
            {
                SQL = $"INSERT INTO plantas (idEscalera, numeroPlanta) VALUES ('{idEscalera}', '{numberPlanta} {i}');";
                MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
            }
        }
        public int SacarIdPlanta()
        {
            if (idEscalera.HasValue)
            {
                string SQL = $"SELECT idPlantas FROM plantas WHERE idEscalera = {idEscalera} and numeroPlanta = '{NumberPlanta}' ;";

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
        public int contarPlantasEscalera()
        {
            string SQL = $"SELECT COUNT(*) FROM plantas WHERE idEscalera = {idEscalera};";
            DataTable dt = MySQLDataManagement.LoadData(SQL, cnstr);

            int count = 0;
            if (dt.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt.Rows[0][0]);
            }

            dt.Dispose();
            return count;
        }



        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdPlanta: {IdPlanta}\n" +
                   $"IdEscalera: {IdEscalera}";
        }
    }
}


