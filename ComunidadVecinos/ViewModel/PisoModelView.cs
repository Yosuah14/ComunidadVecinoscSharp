using ComunidadVecinos.Domain.ComunidadVecinos.Domain;
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
    public class PisoModelView : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;
        private const string cnstr = "server=localhost;uid=Jose;pwd=josepablo;database=vecindario";
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
        public void insertarPiso(int numPisos,string piso)
        {
            string SQL;
            const int ascii = 64;

            for (int i = 1; i <= numPisos; i++)
            {
                insertarTrastero();
                insertarParking();
                SQL = $"INSERT INTO pisos (idPlantas, numeroPiso,parking_idParking,trastero_idTrastero) VALUES ('{idPlantas}', '{piso}{" ,Piso "} {(char)(ascii + i)}','{parking_idParking}','{trastero_idTrastero}');";
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
    public void insertarTrastero()
    {
            string SQL = $"INSERT INTO trastero (estado) VALUES ('Si');";
            MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
            string SQL2 = $"SELECT LAST_INSERT_ID();";
            DataTable dt = MySQLDataManagement.LoadData(SQL2, cnstr);               
            if (dt.Rows.Count > 0)
            {
            Trastero_idTrastero = Convert.ToInt32(dt.Rows[0][0]);
            }


    }
    public void insertarParking()
    {
            string SQL = $"INSERT INTO parking (estado) VALUES ('Si');";
            MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
            string SQL2 = $"SELECT LAST_INSERT_ID();";
            DataTable dt = MySQLDataManagement.LoadData(SQL2, cnstr);
        if (dt.Rows.Count > 0)
        {
            parking_idParking = Convert.ToInt32(dt.Rows[0][0]);
        }
    }
    }


}

