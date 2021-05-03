using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dTrabajador
    {
        DataBase db = new DataBase();

        public string Insertar(Trabajador trabajador)
        {
            try     
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string insert = string.Format("INSERT INTO Trabajadores (NombreT,ApellidoT) VALUES ('{0}','{1}');",
                    trabajador.NombreT,trabajador.ApellidoT);
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
        public string Modificar(Trabajador trabajador)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string update = string.Format("UPDATE Trabajadores SET NombreT='{0}',ApellidoT='{1}' WHERE idTrabajador={2}",
                    trabajador.NombreT,trabajador.ApellidoT, trabajador.idTrabajador);
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
        public string Eliminar(int idTrabajador)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("DELETE FROM Trabajadores WHERE idTrabajador = {0}", idTrabajador);
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
        public Trabajador BuscarPorCod(int idTrabajador)
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                Trabajador trabajador = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT idTrabajador,NombreT,ApellidoT FROM Trabajadores WHERE idTrabajador={0};", idTrabajador);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                if (reader.Read())
                {
                    // 6. Instancia el objeto
                    trabajador = new Trabajador();
                    // 7. Transferir los datos de reader a empleo
                   trabajador.idTrabajador = (int)reader["idTrabajador"];
                   trabajador.NombreT = (String)reader["NombreT"];
                   trabajador.ApellidoT = (String)reader["ApellidoT"];
                 
                }
                reader.Close();
                return trabajador;
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
        public List<Trabajador> ListarTodo()
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                List<Trabajador> trabajadores = new List<Trabajador>();
                Trabajador trabajador = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = "SELECT idTrabajador,NombreT,ApellidoT FROM Trabajadores";
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto trabajador
                while (reader.Read())
                {
                    // 6. Instancia el objeto
                    trabajador = new Trabajador();
                    // 7. Transferir los datos de reader a trabajador
                    trabajador.idTrabajador = (int)reader["idTrabajador"];
                    trabajador.NombreT = (String)reader["NombreT"];
                    trabajador.ApellidoT = (String)reader["ApellidoT"];

                    //AGREGAMOS A LA LISTA DE TRABAJADORES
                    trabajadores.Add(trabajador);
                }
                reader.Close();
                return trabajadores;
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
