using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dCliente
    {
        DataBase db = new DataBase();

        public string Insertar(Cliente cliente)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string insert = string.Format("INSERT INTO Clientes(idCliente,NombreC,ApellidoC,DireccionC,Telefono) VALUES ('{0}','{1}','{2}','{3}',{4});",
                    cliente.idCliente,cliente.NombreC, cliente.ApellidoC, cliente.DireccionC, cliente.Telefono);
                   
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(insert, con);
                // 4. Ejecuto
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                // SIEMPRE SE VA A EJECUTAR=EXITO O FRACASO
                db.DesconectaDb();
            }
        }
        public string Modificar(Cliente cliente)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string update = string.Format("UPDATE Clientes SET NombreC= '{0}',ApellidoC='{1}',DireccionC='{2}',Telefono={3} WHERE idCliente='{4}'",
                     cliente.NombreC, cliente.ApellidoC, cliente.DireccionC, cliente.Telefono,cliente.idCliente);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modificó";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Eliminar(string idCliente)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("DELETE FROM Clientes WHERE idCliente='{0}'", idCliente);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public Cliente BuscarCliente(int idCliente)
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                Cliente cliente = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT idCliente,NombreC,ApellidoC,DireccionC,Telefono FROM Clientes WHERE idCliente={0};", idCliente);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                if (reader.Read())
                {
                    // 6. Instancia el objeto
                    cliente = new Cliente();
                    // 7. Transferir los datos de reader a empleo
                    cliente.idCliente = (string)reader["idCliente"];
                    cliente.NombreC = (String)reader["NombreC"];
                    cliente.ApellidoC = (String)reader["ApellidoC"];
                    cliente.Telefono = (int)reader["Telefono"];
                }
                reader.Close();
                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public List<Cliente> ListarTodo()
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                Cliente cliente = null;
                List<Cliente> clientes = new List<Cliente>();
               // 1. Me conecto con la BD
               SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = "SELECT idCliente,NombreC,ApellidoC,DireccionC,Telefono FROM Clientes";
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                while (reader.Read())
                {
                    // 6. Instancia el objeto
                    cliente = new Cliente();
                    // 7. Transferir los datos de reader a empleo
                    cliente.idCliente = (string)reader["idCliente"];
                    cliente.NombreC = (String)reader["NombreC"];
                    cliente.ApellidoC = (String)reader["ApellidoC"];
                    cliente.DireccionC = (string)reader["DireccionC"];
                    cliente.Telefono = (int)reader["Telefono"];
                    //AGREGAMOS A LA LISTA DE CLIENTES
                    clientes.Add(cliente);
                }
                reader.Close();
                return clientes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
    }
}
