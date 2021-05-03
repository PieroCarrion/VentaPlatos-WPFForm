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
    /// Interaction logic for WpfVenta.xaml
    /// </summary>
    public partial class WpfVenta : Window
    {
        Plato platoAux;
        Trabajador trabAux;
        Cliente clienteTemp;
        nPlato nPlato = new nPlato();
        decimal PrecioT = 0;
        nTrabajador nTrabajador = new nTrabajador();
        nCliente nCliente = new nCliente();
        List<Plato> listaPlatos = new List<Plato>();
        nVenta nVenta = new nVenta();
        nDetalleVenta nDetalle = new nDetalleVenta();
        public WpfVenta()
        {
            InitializeComponent();
            listarPlatos();
            listarTrabajadores();
            listarClientes();
            txtApellidoT.IsReadOnly = true;
            txtNombreT.IsReadOnly = true;
            textBox.IsReadOnly = true;
            textBox1.IsReadOnly = true;
            textBox2.IsReadOnly = true;
            txtApellidoC.IsReadOnly = true;
            txtDNI.IsReadOnly = true;
            txtNombreC.IsReadOnly = true;
            fecha_actual.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Precio_total.Text = "El Precio total es: " + PrecioT;
        }
        void Limpiar()
        {
            txtApellidoT.Text = "";
            txtNombreT.Text = "";
            textBox.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            txtApellidoC.Text = "";
            txtDNI.Text = "";
            txtNombreC.Text = "";
            fecha_actual.Text = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Precio_total.Text = "El Precio total es: " + PrecioT;
        }
        void listarClientes()
        {
            dgClientes.ItemsSource = nCliente.ListarTodo();
        }
        void listarTrabajadores()
        {
            dgTrabajadores.ItemsSource = nTrabajador.ListarTodo();
        }
        void listarPlatos()
        {
            dgPlatos.ItemsSource = nPlato.ListarTodo();
        }
        void listarCesta()
        {
            dgCesta.ItemsSource = null;
            dgCesta.ItemsSource = listaPlatos;
        }
        private void DgVenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                platoAux = (Plato)dgPlatos.SelectedValue;
                if (platoAux != null)
                {
                    textBox.Text = platoAux.idPlato.ToString();
                    textBox1.Text = platoAux.NombreP;
                    textBox2.Text = platoAux.PrecioP.ToString();
                }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (platoAux!=null)
            {
                listaPlatos.Add(platoAux);
                listarCesta();
                PrecioT += platoAux.PrecioP;
                Precio_total.Text = "El Precio total es: " + PrecioT;
            }
            else
            {
                MessageBox.Show("Selecciona un plato");
            }
        }
        private void dgTrabajadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            trabAux = (Trabajador)dgTrabajadores.SelectedValue;
            if (trabAux != null)
            {
                txtApellidoT.Text = trabAux.ApellidoT;
                txtNombreT.Text = trabAux.NombreT;
            }
        }
        private void btnRealizarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (trabAux!=null && clienteTemp!=null && listaPlatos.Count()>0)
            {
                Venta venta = new Venta
                {
                    idTrabajador = trabAux.idTrabajador,
                    idCliente = clienteTemp.idCliente,
                    Fecha = fecha_actual.Text,
                    Total = PrecioT
                };
                nVenta.Insertar(venta);
                

                //OBTENER EL ID DE LA VENTA
                List<Venta> ventas = nVenta.ListarTodo();
                int idVenta= 0;
                foreach (Venta value in ventas)
                {
                    idVenta = value.idVenta;
                }
                foreach (Plato plato in listaPlatos)
                {
                    DetalleVenta detalle = new DetalleVenta
                    {
                        idPlato = plato.idPlato,
                        idVenta = idVenta,
                        Costo = plato.PrecioP
                    };
                    nDetalle.Insertar(detalle);
                }
                //LIMPIAR
                listaPlatos.Clear();
                listarCesta();
                MessageBox.Show("La venta se ha realizado con Éxito");
                PrecioT = 0;
                Limpiar();
            }
            else
            {
                MessageBox.Show("Complete los campos");
            }
        }
        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clienteTemp = (Cliente)dgClientes.SelectedValue;
            if (clienteTemp !=null)
            {
                txtDNI.Text = clienteTemp.idCliente;
                txtNombreC.Text = clienteTemp.NombreC;
                txtApellidoC.Text = clienteTemp.NombreC;
            }
        }
    }
}
