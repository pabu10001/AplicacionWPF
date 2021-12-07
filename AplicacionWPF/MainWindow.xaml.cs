using AplicacionWPF.dto;
using AplicacionWPF.gui;
using AplicacionWPF.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogicaNegocio logicaNegocio;
        public MainWindow()
        {
            InitializeComponent();
            logicaNegocio = new LogicaNegocio();
            DataGridLibros.DataContext = logicaNegocio;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowLibro windowLibro = new WindowLibro(logicaNegocio);
            windowLibro.Show();
        }

        private void ButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridLibros.SelectedIndex != -1)
            {
                Libro libro = (Libro)DataGridLibros.SelectedItem;
                WindowLibro windowLibro = new WindowLibro(logicaNegocio, (Libro)libro.Clone(), DataGridLibros.SelectedIndex);
                windowLibro.Show();
            }
        }

        private void ButtonModificar_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonModificar.Background = new SolidColorBrush(Colors.Green);
        }
    }
}
