using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
namespace Datos
{
   public  class dDetalleVenta
    {
        DataBase db = new DataBase();

        public string Insertar(DetalleVenta detalleVenta)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string insert = string.Format("INSERT INTO DetalleVentas(idVenta,idPlato,Costo) VALUES ({0},{1},{2})",
                    detalleVenta.idVenta,detalleVenta.idPlato,detalleVenta.Costo);
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
        
        public string Eliminar(int idVenta)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("DELETE FROM DetalleVentas where idVenta={0};", idVenta); 
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
        //public DetalleVenta BuscarPorCod(int idDetalleVenta)
        //{
        //    try
        //    {
        //        // 0. Declara el objeto que contendra los datos de la tabla
        //        DetalleVenta detalleVenta= null;
        //        // 1. Me conecto con la BD
        //        SqlConnection con = db.ConectaDb();
        //        // 2. Crear la instruccion SQL
        //        string select = string.Format("SELECT idDetalleVenta,idVenta,idPlato,Costo FROM DetalleVentas WHERE idDetalleVenta={0}", idDetalleVenta);
        //        // 3. Creo el Command = SQL + Con
        //        SqlCommand cmd = new SqlCommand(select, con);
        //        // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
        //        if (reader.Read())
        //        {
        //            // 6. Instancia el objeto
        //            detalleVenta = new DetalleVenta();
        //            // 7. Transferir los datos de reader a empleo
        //
        //            detalleVenta.idDetalleVenta = (int)reader["idDetalleVenta"];
        //            detalleVenta.idVenta = (int)reader["idVenta"];
        //            detalleVenta.idPlato = (int)reader["idPlato"];
        //            detalleVenta.Costo = (decimal)reader["Costo"];
        //        }
        //        reader.Close();
        //        return detalleVenta;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        db.DesconectaDb();
        //    }
        //}
        public List<DetalleVenta> buscarDetalle(int idVenta)
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                List<DetalleVenta> detalles = new List<DetalleVenta>();
                DetalleVenta detalleVenta = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT idDetalleVenta,idVenta,idPlato,Costo FROM DetalleVentas where idVenta={0}",idVenta);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                while (reader.Read())
                {
                    // 6. Instancia el objeto
                    // 6. Instancia el objeto
                    detalleVenta = new DetalleVenta();
                    // 7. Transferir los datos de reader a empleo

                    detalleVenta.idDetalleVenta = (int)reader["idDetalleVenta"];
                    detalleVenta.idVenta = (int)reader["idVenta"];
                    detalleVenta.idPlato = (int)reader["idPlato"];
                    detalleVenta.Costo = (decimal)reader["Costo"];
                    //AGREGARMOS A LA LISTA DE PLATOS
                    detalles.Add(detalleVenta);
                }
                reader.Close();
                return detalles;
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
