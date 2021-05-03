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
    /// Interaction logic for WpfDetalleVenta.xaml
    /// </summary>
    public partial class WpfDetalleVenta : Window
    {
        nVenta nVenta = new nVenta();
        Venta ventT = new Venta();
        nDetalleVenta nDetalle = new nDetalleVenta();
        public WpfDetalleVenta()
        {
            InitializeComponent();
            listarVentas();
        }
        void listarVentas()
        {
            dgVentas.ItemsSource = nVenta.ListarTodo();
        }

        private void dgVentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ventT = (Venta)dgVentas.SelectedValue;
            if (ventT!= null)
            {
                dgDetalles.ItemsSource = null;
                dgDetalles.ItemsSource = nDetalle.buscarDetalle(ventT.idVenta);
            }
        }
    }
}
