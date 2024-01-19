using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.Domain
{
    public class Comunidad : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para notificar cambios en las propiedades

        // Atributos
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
        public Comunidad()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }

        //Método onPropertyChange

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        private string GetSiNoValue(byte? value)
        {
            // Devuelve "Si" si el valor es 1, "No" si es 0, y una cadena vacía si es null.
            return value.HasValue ? (value.Value == 1 ? "Si" : "No") : "";
        }

    }
}
