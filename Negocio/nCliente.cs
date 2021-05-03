using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;
namespace Negocio
{
    public class nCliente
    {
        dCliente ClienteDATA = new dCliente();
        public nCliente()
        {
            ClienteDATA = new dCliente();
        }
        //AGREGA NUEVO CLIENTE
        public string NuevoCliente(Cliente cliente)
        {
            return ClienteDATA.Insertar(cliente);
        }
        //SE EDITA EL CLIENTE
        public string EditarCliente(Cliente cliente)
        {
            return ClienteDATA.Modificar(cliente);
        }
        //SE ELIMINA EL CLIENTE
        public string Eliminar(string idCliente)
        {
            return ClienteDATA.Eliminar(idCliente);
        }
        //BUSCAR CLIENTE
        public Cliente BuscarCliente(int idCliente)
        {
            return ClienteDATA.BuscarCliente(idCliente);
        }
        //LISTAR LOS CLIENTES
        public List<Cliente> ListarTodo()
        {
            return ClienteDATA.ListarTodo();
        }
        

    }
}
