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
    /// Interaction logic for WpfCliente.xaml
    /// </summary>
    public partial class WpfCliente : Window
    {
        nCliente ncCliente = new nCliente();
        Cliente clienteSelec;
        public WpfCliente()
        {
            InitializeComponent();
            ListarClientes();
        }
        private void ListarClientes()
        {
            dgClientes.ItemsSource = ncCliente.ListarTodo();
        }
        private void CleanTextBox()
        {
            txt_DNI.Clear();
            txtNombreC.Clear();
            txtApellidoC.Clear();
            txtDireccionC.Clear();
            txtTelefonoC.Clear();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombreC.Text != "" && txtApellidoC.Text != "" && txtDireccionC.Text != "" && txtTelefonoC.Text != "")
            {
                if (txt_DNI.Text.Count()>=8)
                {
                    Cliente clientes = new Cliente();
                    clientes.idCliente = txt_DNI.Text;
                    clientes.NombreC = txtNombreC.Text;
                    clientes.ApellidoC = txtApellidoC.Text;
                    clientes.DireccionC = txtDireccionC.Text;
                    clientes.Telefono = Convert.ToInt32(txtTelefonoC.Text);
                    String respuesta = ncCliente.NuevoCliente(clientes);
                    ListarClientes();
                    CleanTextBox();
                    MessageBox.Show(respuesta);
                }
                else
                {
                    MessageBox.Show("Ingrese un DNI valido");
                }
            }
            else
            {
                MessageBox.Show("No existen datos");
            }
        }
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (clienteSelec!=null)
            {
                Cliente clientes = new Cliente();
                clientes.idCliente = clienteSelec.idCliente;
                clientes.NombreC = txtNombreC.Text;
                clientes.ApellidoC = txtApellidoC.Text;
                clientes.DireccionC = txtDireccionC.Text;
                clientes.Telefono = Convert.ToInt16(txtTelefonoC.Text);
                String respuesta = ncCliente.EditarCliente(clientes);
                ListarClientes();
                CleanTextBox();
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show("No existen datos");
            }
        }
        private void DgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clienteSelec = (Cliente)dgClientes.SelectedItem;
            if (clienteSelec !=  null)
            {
                txt_DNI.Text = clienteSelec.idCliente;
                txtNombreC.Text = clienteSelec.NombreC;
                txtApellidoC.Text = clienteSelec.ApellidoC;
                txtDireccionC.Text = clienteSelec.DireccionC;
                txtTelefonoC.Text = clienteSelec.Telefono.ToString();
            }
        }

        private void txt_DNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled = false;
            } // it`s number
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        private void txtNombreC_KeyDown(object sender, KeyEventArgs e)
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

        private void txtApellidoC_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDireccionC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z || e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelefonoC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled = false;
            } 
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
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
