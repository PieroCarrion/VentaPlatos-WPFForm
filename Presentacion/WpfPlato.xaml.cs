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
    /// Interaction logic for WpfPlato.xaml
    /// </summary>
    public partial class WpfPlato : Window
    {
        nPlato npPlato = new nPlato();
        Plato platoSeleccionado;
        public WpfPlato()
        {
            InitializeComponent();
            ListarPlatos();
        }
        private void ListarPlatos()
        {
            dgPlatos.ItemsSource = null;
            dgPlatos.ItemsSource = npPlato.ListarTodo();
        }
        private void CleanTextBox()
        {
            txtNombreP.Clear();
            txtPrecioP.Clear();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombreP.Text != "" && txtPrecioP.Text != "")
            {
                
                Plato platos = new Plato();
                platos.NombreP = txtNombreP.Text;
                platos.PrecioP = Convert.ToDecimal(txtPrecioP.Text);
                String respuesta = npPlato.Insertar(platos);
                ListarPlatos();
                CleanTextBox();
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show("No existen datos");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreP.Text != "" && txtPrecioP.Text != "")
            {
                Plato platos = new Plato();
                platos.NombreP = txtNombreP.Text;
                platos.PrecioP = Convert.ToDecimal(txtPrecioP.Text);
                String respuesta = npPlato.Eliminar(platos.idPlato);
                ListarPlatos();
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
            if (platoSeleccionado!=null)
            {
                Plato platos = new Plato();
                platos.NombreP = txtNombreP.Text;
                platos.PrecioP = Convert.ToDecimal(txtPrecioP.Text);
                platos.idPlato = platoSeleccionado.idPlato;
                String respuesta = npPlato.Modificar(platos);
                ListarPlatos();
                CleanTextBox();
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show("No existen datos");
            }
        }

        private void DgPlatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            platoSeleccionado = (Plato)dgPlatos.SelectedItem;
            if (platoSeleccionado != null)
            {
                txtNombreP.Text = platoSeleccionado.NombreP;
                txtPrecioP.Text = platoSeleccionado.PrecioP.ToString();
            }
        }

        private void txtNombreP_KeyDown(object sender, KeyEventArgs e)
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
