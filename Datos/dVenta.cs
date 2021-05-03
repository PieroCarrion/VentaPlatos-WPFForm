using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
namespace Datos
{
    public class dVenta
    {
        DataBase db = new DataBase();

        public string Insertar(Venta venta)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string insert = string.Format("INSERT INTO Ventas(idTrabajador,idCliente,Fecha,Total) VALUES ({0},'{1}','{2}',{3})",
                    venta.idTrabajador, venta.idCliente, venta.Fecha, venta.Total);
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
        //public string Modificar(Plato plato)
        //{
        //    try
        //    {
        //        // 1. Me conecto con la BD
        //        SqlConnection con = db.ConectaDb();
        //        // 2. Crear la instruccion SQL
        //        string update = string.Format("UPDATE Platos SET NombreP='{0}',PrecioP={1} WHERE idPlato={2}",
        //        plato.NombreP, plato.PrecioP, plato.idPlato);
        //        SqlCommand cmd = new SqlCommand(update, con);
        //        cmd.ExecuteNonQuery();
        //        return "Modificó";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    finally
        //    {
        //        db.DesconectaDb();
        //    }
        //}
        public string Eliminar(int idVenta)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("DELETE FROM Ventas where idVenta={0};", idVenta);
                dDetalleVenta d = new dDetalleVenta();
                d.Eliminar(idVenta);
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
        public Venta BuscarPorCod(int idVenta)
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                Venta venta = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT idVenta,idTrabajador,idCliente,Fecha,Total FROM Ventas WHERE idVenta={0}", idVenta);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                if (reader.Read())
                {
                    // 6. Instancia el objeto
                    venta = new Venta();
                    venta.idVenta = (int)reader["idVenta"];
                    venta.idTrabajador = (int)reader["idTrabajador"];
                    venta.idCliente = (string)reader["idCliente"];
                    venta.Fecha = reader["Fecha"].ToString();
                    venta.Total = (decimal)reader["Total"];

                }
                reader.Close();
                return venta;
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
        public List<Venta> ListarTodo()
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                List<Venta> ventas = new List<Venta>();
                Venta venta = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT idVenta,idTrabajador,idCliente,Fecha,Total FROM Ventas");
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                while (reader.Read())
                {
                    venta = new Venta();
                    venta.idVenta = (int)reader["idVenta"];
                    venta.idTrabajador = (int)reader["idTrabajador"];
                    venta.idCliente = (string)reader["idCliente"];
                    venta.Fecha = reader["Fecha"].ToString();
                    venta.Total = (decimal)reader["Total"];
                    ventas.Add(venta);
                }
                reader.Close();
                return ventas;
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
