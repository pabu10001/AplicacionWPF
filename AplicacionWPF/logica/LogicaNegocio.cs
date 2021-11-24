using AplicacionWPF.dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicacionWPF.logica
{
    public class LogicaNegocio
    {
        public ObservableCollection<Libro> listaLibros { get; set; }

        public LogicaNegocio()
        {
            listaLibros = new ObservableCollection<Libro>();
            //Aniadimos libro de prueba
            listaLibros.Add(new Libro("Moby Dick", "Herman Melville", DateTime.Now));
        }

        public void addLibro(Libro libro)
        {
            listaLibros.Add(libro);
        }

        public void modificarLibro(Libro libro, int posicion)
        {
            listaLibros[posicion] = libro;
        }
    }
}
