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
using System.Windows.Shapes;
using Negocio;
using Entidades;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for WpfTrabajador.xaml
    /// </summary>
    public partial class WpfTrabajador : Window
    {
        nTrabajador ntTrabajador = new nTrabajador();
        Trabajador trabSeleccionado = new Trabajador();
        public WpfTrabajador()
        {
            InitializeComponent();
            ListarTrabajadores();
        }
        private void ListarTrabajadores()
        {
            dgTrabajadores.ItemsSource = null;
            dgTrabajadores.ItemsSource = ntTrabajador.ListarTodo();
        }
        private void CleanTextBox()
        {
            txtNombreT.Clear();
            txtApellidoT.Clear();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreT.Text != "" && txtApellidoT.Text != "")
            {
                Trabajador trabajador = new Trabajador();
                trabajador.NombreT = txtNombreT.Text;
                trabajador.ApellidoT = txtApellidoT.Text;
                String respuesta = ntTrabajador.Insertar(trabajador);
                ListarTrabajadores();
                CleanTextBox();
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show("No existen datos");
            }

        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (trabSeleccionado!=null)
            {
                Trabajador trabajador = new Trabajador();
                trabajador.NombreT = txtNombreT.Text;
                trabajador.ApellidoT = txtApellidoT.Text;
                trabajador.idTrabajador = trabSeleccionado.idTrabajador;
                String respuesta = ntTrabajador.Modificar(trabajador);
                ListarTrabajadores();
                CleanTextBox();
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show("No existen datos");
            }
        }

        private void DgTrabajadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            trabSeleccionado = (Trabajador)dgTrabajadores.SelectedItem;
            if (trabSeleccionado != null)
            {
                txtNombreT.Text = trabSeleccionado.NombreT;
                txtApellidoT.Text = trabSeleccionado.ApellidoT.ToString();
            }
        }

        private void txtNombreT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtApellidoT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
