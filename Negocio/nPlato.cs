using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;
namespace Negocio
{
    public class nPlato
    {
        dPlato PlatoDATA;
        public nPlato()
        {
            PlatoDATA = new dPlato();

        }
        //AGREGAMOS UN NUEVO PLATO
        public string Insertar(Plato plato)
        {
            return PlatoDATA.Insertar(plato);
        }
        //MODIFICAMOS UN PLATO
        public string Modificar(Plato plato)
        {
            return PlatoDATA.Modificar(plato);
        }
        //ELIMINAMOS UN PLATO
        public string Eliminar(int idPlato)
        {
            return PlatoDATA.Eliminar(idPlato);
        }
        //LISTAMOS LOS PLATOS
        public List<Plato> ListarTodo()
        {
            return PlatoDATA.ListarTodo();
        }
    }
}
