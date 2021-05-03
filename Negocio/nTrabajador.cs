using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidades;
namespace Negocio
{
    public class nTrabajador
    {
        dTrabajador TrabajadorDATA = new dTrabajador();
        public nTrabajador()
        {
            TrabajadorDATA = new dTrabajador();
        }
        // Agregar un nuevo Trabajador(el código del empleo debe ser autogenerado)
        public string Insertar(Trabajador trabajador)
        {
            return TrabajadorDATA.Insertar(trabajador);
        }
        // Modificar el nombrey apellido del trabajador según su código.
        public string Modificar(Trabajador trabajador)
        {
            return TrabajadorDATA.Modificar(trabajador);
        }
        //Eliminar Trabajador por su código
        public string Eliminar(int idTrabajador)
        {
            return TrabajadorDATA.Eliminar(idTrabajador);
        }
        //BUSCAR TRABAJADOR POR ID
        public Trabajador BuscarPorCod(int idTrabajador)
        {
            return TrabajadorDATA.BuscarPorCod(idTrabajador);
        }
        //LISTAR LOS TRABAJADORES
        public List<Trabajador> ListarTodo()
        {
            return TrabajadorDATA.ListarTodo();
        }
    }
}
