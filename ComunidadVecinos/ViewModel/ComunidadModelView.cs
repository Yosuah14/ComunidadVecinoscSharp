using ComunidadVecinos.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComunidadVecinos.ViewModel
{
    public class ComunidadModelView : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler? PropertyChanged;

        private const String cnstr = "server=localhost;uid=Jose;pwd=josepablo;database=vecindario";

        // Método para notificar cambios en las propiedades

        // Atributos
        private ObservableCollection<Comunidad> comunidades;
        private int idComunidad;
        private string nombre;
        private string direccion;
        private string fechaCreacion;
        private byte? piscina;
        private decimal? metrosCuadrados;
        private byte? pisoPortero;
        private byte? zonaDuchasBanio;
        private byte? parqueInfantil;
        private byte? maquinasEjercicio;
        private byte? salaReuniones;
        private byte? pistaTenis;
        private byte? pistaPadel;

        public ObservableCollection<Comunidad> Comunidades
        {
            get { return comunidades; }
            set
            {
                comunidades = value;
                OnPropertyChanged("Comunidades");
            }
        }

        // Propiedades
        public int IdComunidad
        {
            get { return idComunidad; }
            set
            {
                idComunidad = value;
                OnPropertyChanged("IdComunidad");
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        public string FechaCreacion
        {
            get { return fechaCreacion; }
            set
            {
                fechaCreacion = value;
                OnPropertyChanged("FechaCreacion");
            }
        }

        public byte? Piscina
        {
            get { return piscina; }
            set
            {
                piscina = value;
                OnPropertyChanged("Piscina");
            }
        }

        public decimal? MetrosCuadrados
        {
            get { return metrosCuadrados; }
            set
            {
                metrosCuadrados = value;
                OnPropertyChanged("MetrosCuadrados");
            }
        }

        public byte? PisoPortero
        {
            get { return pisoPortero; }
            set
            {
                pisoPortero = value;
                OnPropertyChanged("PisoPortero");
            }
        }

        public byte? ZonaDuchasBanio
        {
            get { return zonaDuchasBanio; }
            set
            {
                zonaDuchasBanio = value;
                OnPropertyChanged("ZonaDuchasBanio");
            }
        }

        public byte? ParqueInfantil
        {
            get { return parqueInfantil; }
            set
            {
                parqueInfantil = value;
                OnPropertyChanged("ParqueInfantil");
            }
        }

        public byte? MaquinasEjercicio
        {
            get { return maquinasEjercicio; }
            set
            {
                maquinasEjercicio = value;
                OnPropertyChanged("MaquinasEjercicio");
            }
        }

        public byte? SalaReuniones
        {
            get { return salaReuniones; }
            set
            {
                salaReuniones = value;
                OnPropertyChanged("SalaReuniones");
            }
        }

        public byte? PistaTenis
        {
            get { return pistaTenis; }
            set
            {
                pistaTenis = value;
                OnPropertyChanged("PistaTenis");
            }
        }

        public byte? PistaPadel
        {
            get { return pistaPadel; }
            set
            {
                pistaPadel = value;
                OnPropertyChanged("PistaPadel");
            }
        }

        // Constructor
        public ComunidadModelView()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }


        //Método onPropertyChange

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void NewComunity()
        {
            String SQL = $"INSERT INTO comunidad (Nombre, Direccion, FechaCreacion,Piscina,MetrosCuadrados,PisoPortero,ZonaDuchasBanio,ParqueInfantil,MaquinasEjercicio,SalaReuniones,PistaTenis,PistaPadel) VALUES ('{Nombre}','{Direccion}', '{FechaCreacion}', '{Piscina}', '{MetrosCuadrados}', '{PisoPortero}', '{ZonaDuchasBanio}', '{ParqueInfantil}', '{MaquinasEjercicio}', '{SalaReuniones}', '{PistaTenis}', '{PistaPadel}');";
            //usaremos las clases de la librería de MySQL para ejecutar queries
            //Instalar el paqueta MySQL.Data
            MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
        }
        public void UpdateCommunity()
        {
            string SQL = $"UPDATE comunidad SET Nombre = '{Nombre}', Direccion = '{Direccion}', FechaCreacion = '{FechaCreacion}', Piscina = '{Piscina}', MetrosCuadrados = '{MetrosCuadrados}', PisoPortero = '{PisoPortero}', ZonaDuchasBanio = '{ZonaDuchasBanio}', ParqueInfantil = '{ParqueInfantil}', MaquinasEjercicio = '{MaquinasEjercicio}', SalaReuniones = '{SalaReuniones}', PistaTenis = '{PistaTenis}', PistaPadel = '{PistaPadel}' WHERE Nombre = '{Nombre}';";
            MySQLDataManagement.ExecuteNonQuery(SQL, cnstr);
           
        }
        public void LoadCommunities()
        {
            String SQL = $"SELECT Nombre, Direccion, FechaCreacion,Piscina,MetrosCuadrados,PisoPortero,ZonaDuchasBanio,ParqueInfantil,MaquinasEjercicio,SalaReuniones,PistaTenis,PistaPadel FROM comunidad;";
            DataTable dt = MySQLDataManagement.LoadData(SQL, cnstr);

            if (dt.Rows.Count > 0)
            {
                if (comunidades == null) comunidades = new ObservableCollection<Comunidad>();

                foreach (DataRow row in dt.Rows)
                {
                    comunidades.Add(new Comunidad
                    {
                        Nombre = row["Nombre"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        FechaCreacion = row["FechaCreacion"].ToString(),
                        MetrosCuadrados = Convert.ToInt32(row["MetrosCuadrados"]),
                        Piscina = Convert.ToByte(row["Piscina"]),
                        ParqueInfantil = Convert.ToByte(row["ParqueInfantil"]),
                        MaquinasEjercicio = Convert.ToByte(row["MaquinasEjercicio"]),
                        SalaReuniones = Convert.ToByte(row["SalaReuniones"]),
                        PistaTenis = Convert.ToByte(row["PistaTenis"]),
                        PistaPadel = Convert.ToByte(row["PistaPadel"]),
                        ZonaDuchasBanio = Convert.ToByte(row["ZonaDuchasBanio"]),
                        PisoPortero = Convert.ToByte(row["PisoPortero"])
                    });
                }
            }
            dt.Dispose();
        }
        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdComunidad: {IdComunidad}\n" +
                   $"Nombre: {Nombre}\n" +
                   $"Direccion: {Direccion}\n" +
                   $"FechaCreacion: {FechaCreacion}\n" +
                   $"Piscina: {GetSiNoValue(Piscina)}\n" +
                   $"MetrosCuadrados: {MetrosCuadrados}\n" +
                   $"PisoPortero: {GetSiNoValue(PisoPortero)}\n" +
                   $"ZonaDuchasBanio: {GetSiNoValue(ZonaDuchasBanio)}\n" +
                   $"ParqueInfantil: {GetSiNoValue(ParqueInfantil)}\n" +
                   $"MaquinasEjercicio: {GetSiNoValue(MaquinasEjercicio)}\n" +
                   $"SalaReuniones: {GetSiNoValue(SalaReuniones)}\n" +
                   $"PistaTenis: {GetSiNoValue(PistaTenis)}\n" +
                   $"PistaPadel: {GetSiNoValue(PistaPadel)}";
        }
        public static int ObtenerIdComunidadPorNombre(string nombreComunidad)
        {
            int idComunidad = 0;
            string SQL = $"SELECT idComunidad FROM comunidad WHERE Nombre = '{nombreComunidad}';";
            DataTable dt = MySQLDataManagement.LoadData(SQL, cnstr);

            if (dt.Rows.Count > 0)
            {
                idComunidad = Convert.ToInt32(dt.Rows[0]["idComunidad"]);
            }

            dt.Dispose();
            return idComunidad;
        }

        private string GetSiNoValue(byte? value)
        {
            // Devuelve "Si" si el valor es 1, "No" si es 0, y una cadena vacía si es null.
            return value.HasValue ? (value.Value == 1 ? "Si" : "No") : "";
        }

    }
}
