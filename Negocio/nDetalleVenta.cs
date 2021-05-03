using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class nDetalleVenta
    {
        dDetalleVenta dDetalle = new dDetalleVenta();
        public nDetalleVenta()
        {
            dDetalle = new dDetalleVenta();

        }
        //AGREGAMOS UN NUEVO PLATO
        public string Insertar(DetalleVenta detalle)
        {
            return dDetalle.Insertar(detalle);
        }

        //ELIMINAMOS UN PLATO
        //public string Eliminar(int idVenta)
        //{
        //    return dDetalle.Eliminar(idVenta);
        //}
        //LISTAMOS LOS PLATOS
        public List<DetalleVenta> buscarDetalle(int idVenta)
        {
            return dDetalle.buscarDetalle(idVenta);
        }
    }
}
