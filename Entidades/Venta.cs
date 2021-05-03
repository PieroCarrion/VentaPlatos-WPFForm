using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int idVenta { get; set; }
        public int idTrabajador { get; set; }
        public string idCliente { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
