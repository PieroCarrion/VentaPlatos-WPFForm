using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dPlato
    {
        DataBase db = new DataBase();

        public string Insertar(Plato plato)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string insert = string.Format("INSERT INTO Platos(NombreP,PrecioP) VALUES ('{0}',{1});",
                    plato.NombreP, plato.PrecioP);
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
        public string Modificar(Plato plato)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string update = string.Format("UPDATE Platos SET NombreP='{0}',PrecioP={1} WHERE idPlato={2}",
                plato.NombreP, plato.PrecioP,plato.idPlato);
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
        public string Eliminar(int idPlato)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("DELETE FROM Platos where idPlato={0};", idPlato);
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
        public Plato BuscarPorCod(int idPlato)
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                Plato plato = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT idPlato,NombreP,PrecioP FROM Platos WHERE idPlato={0}", idPlato);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                if (reader.Read())
                {
                    // 6. Instancia el objeto
                    plato = new Plato();
                    // 7. Transferir los datos de reader a empleo
                    plato.idPlato = (int)reader["idPlato"];
                    plato.NombreP = (String)reader["NombreP"];
                    plato.PrecioP = (decimal)reader["PrecioP"];
                }
                reader.Close();
                return plato;
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
        public List<Plato> ListarTodo()
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                List<Plato> platos = new List<Plato>();
               Plato plato = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select ="SELECT idPlato,NombreP,PrecioP FROM Platos";
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                while (reader.Read())
                {
                    // 6. Instancia el objeto
                    plato = new Plato();
                    // 7. Transferir los datos de reader a empleo
                    plato.idPlato = (int)reader["idPlato"];
                    plato.NombreP = (String)reader["NombreP"];
                    plato.PrecioP = (decimal)reader["PrecioP"];
                    //AGREGARMOS A LA LISTA DE PLATOS
                    platos.Add(plato);
                }
                reader.Close();
                return platos;
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