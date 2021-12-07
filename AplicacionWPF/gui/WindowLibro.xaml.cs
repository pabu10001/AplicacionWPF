using AplicacionWPF.dto;
using AplicacionWPF.logica;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplicacionWPF.gui
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowLibro : Window
    {
        private LogicaNegocio logicaNegocio;
        private Libro libro;
        private int posicion;
        private Boolean modificando;
        private int errores;

        //Constructor
        public WindowLibro(LogicaNegocio logicaNegocio)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            libro = new Libro();
            this.DataContext = libro;
            modificando = false;
            LabelBinding.DataContext = this;
        }

        //Contructor sobrecargado para la modificacion de un Libro
        public WindowLibro(LogicaNegocio logicaNegocio, Libro libroModificar, int posicion)
        {
            InitializeComponent();
            this.logicaNegocio = logicaNegocio;
            this.libro = libroModificar;
            this.posicion = posicion;
            this.DataContext = libro;
            modificando = true;
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (modificando)
            {
                logicaNegocio.modificarLibro(libro, posicion);
            }
            else
            {
                logicaNegocio.addLibro(libro);
            }

            this.Close();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs errorEventArgs)
        {
            if(errorEventArgs.Action == ValidationErrorEventAction.Added)
            {
                errores++;
            }
            else
            {
                errores--;
            }
            if(errores == 0)
            {
                ButtonAceptar.IsEnabled = true;
            }
            else
            {
                ButtonAceptar.IsEnabled = false;
            }
        }
    }
}