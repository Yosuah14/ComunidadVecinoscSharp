using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComunidadVecinos.ViewModel
{
    public class PropietarioModelView : INotifyPropertyChanged
    {
        // Evento para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Atributos
        private int idPropietarios;
        private int idPiso;
        private string nombre;
        private string dni;
        private string provincia;
        private string localidad;
        private string apellido;
        private int codigoPostal;

        // Propiedades
        public int IdPropietarios
        {
            get { return idPropietarios; }
            set
            {
                idPropietarios = value;
                OnPropertyChanged("IdPropietarios");
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

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public string Dni
        {
            get { return dni; }
            set
            {
                dni = value;
                OnPropertyChanged("Dni");
            }
        }

        public string Provincia
        {
            get { return provincia; }
            set
            {
                provincia = value;
                OnPropertyChanged("Provincia");
            }
        }

        public string Localidad
        {
            get { return localidad; }
            set
            {
                localidad = value;
                OnPropertyChanged("Localidad");
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                OnPropertyChanged("Apellido");
            }
        }

        public int CodigoPostal
        {
            get { return codigoPostal; }
            set
            {
                codigoPostal = value;
                OnPropertyChanged("CodigoPostal");
            }
        }

        // Constructor
        public PropietarioModelView()
        {
            // Puedes inicializar propiedades predeterminadas aquí si lo deseas.
        }

        // Método ToString() para representar la instancia como cadena
        public override string ToString()
        {
            return $"IdPropietarios: {IdPropietarios}\n" +
                   $"IdPiso: {IdPiso}\n" +
                   $"Nombre: {Nombre}\n" +
                   $"Dni: {Dni}\n" +
                   $"Provincia: {Provincia}\n" +
                   $"Localidad: {Localidad}\n" +
                   $"Apellido: {Apellido}\n" +
                   $"CodigoPostal: {CodigoPostal}";
        }
    }
}
