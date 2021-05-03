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

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            WpfCliente wpfCliente = new WpfCliente();
            wpfCliente.Show();
        }

        private void btnPlatos_Click(object sender, RoutedEventArgs e)
        {
            WpfPlato wpfPlato = new WpfPlato();
            wpfPlato.Show();
        }

        private void btnTrabajadores_Click(object sender, RoutedEventArgs e)
        {
            WpfTrabajador wpfTrabajador = new WpfTrabajador();
            wpfTrabajador.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WpfVenta x = new WpfVenta();
            x.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WpfDetalleVenta y = new WpfDetalleVenta();
            y.Show();
        }
    }
}
