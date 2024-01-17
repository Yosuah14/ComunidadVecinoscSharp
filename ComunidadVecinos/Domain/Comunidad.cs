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
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdComunidad: {IdComunidad}\n" +
               $"Nombre: {Nombre}\n" +
               $"Direccion: {Direccion}\n" +
               $"FechaCreacion: {FechaCreacion}\n" +
               $"Piscina: {Piscina}\n" +
               $"MetrosCuadrados: {MetrosCuadrados}\n" +
               $"PisoPortero: {PisoPortero}\n" +
               $"ZonaDuchasBanio: {ZonaDuchasBanio}\n" +
               $"ParqueInfantil: {ParqueInfantil}\n" +
               $"MaquinasEjercicio: {MaquinasEjercicio}\n" +
               $"SalaReuniones: {SalaReuniones}\n" +
               $"PistaTenis: {PistaTenis}\n" +
               $"PistaPadel: {PistaPadel}";
        }
    }

}
