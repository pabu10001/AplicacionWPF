using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AplicacionWPF.dto
{
    public class Libro : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String titulo;
        public String Titulo
        {
            get
            {
                return titulo;
            }
            set
            {
                titulo = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Titulo"));
            }
        }

        private String autor;
        public String Autor
        {
            get
            {
                return autor;
            }
            set
            {
                autor = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("Autor"));
            }
        }

        private DateTime fechaEntrada;
        public DateTime FechaEntrada
        {
            get
            {
                return fechaEntrada;
            }
            set
            {
                fechaEntrada = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("FechaEntrada"));
            }
        }

        //IDataErrorInfo
        public string Error
        {
            get
            {
                return "";
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = "";
                if(columnName == "Titulo")
                {
                    if (string.IsNullOrEmpty(titulo))
                    {
                        result = "Debe introducir un titulo";
                    }
                }
                else if (columnName == "Autor")
                {
                    if (string.IsNullOrEmpty(autor))
                    {
                        result = "Debe introducir un autor";
                    }
                }
                return result;
            }
        }

        //Constructores
        public Libro(String titulo, String autor, DateTime fechaEntrada)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.fechaEntrada = fechaEntrada;
        }

        public Libro()
        {
            this.fechaEntrada = DateTime.Now;
        }

        //ToString
        public override string ToString()
        {
            return base.ToString();
        }

        //IClonable
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
