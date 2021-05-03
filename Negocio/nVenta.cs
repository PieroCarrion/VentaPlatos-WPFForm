using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class nVenta
    {
        dVenta dVenta = new dVenta();
        public nVenta()
        {
            dVenta = new dVenta();

        }
        //AGREGAMOS UN NUEVO PLATO
        public string Insertar(Venta venta)
        {
            return dVenta.Insertar(venta);
        }
        
        //ELIMINAMOS UN PLATO
        public string Eliminar(int idVenta)
        {
            return dVenta.Eliminar(idVenta);
        }
        //LISTAMOS LOS PLATOS
        public List<Venta> ListarTodo()
        {
            return dVenta.ListarTodo();
        }
    }
}
