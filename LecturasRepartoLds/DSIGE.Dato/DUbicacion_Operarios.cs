using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSIGE.Modelo;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DSIGE.Dato
{
    public class DUbicacion_Operarios
    {

        string cadenaCnx = System.Configuration.ConfigurationManager.ConnectionStrings["dataSige"].ConnectionString;

        public DUbicacion_Operarios()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
        }


        /// <summary>
        /// Autor: rcontreras
        /// Fecha: 30-09-2015
        /// </summary>
        /// <param name="oRq"></param>
        /// <returns></returns>
        public List<UbicacionOperario> DListaOperariosGPS(string fechaGPS, int idSupervisor, int idPerfil, string lista, int id_supervisor, int id_operario_supervisor)
        {
            try
            {
                List<UbicacionOperario> lOb = new List<UbicacionOperario>();

                string[] Servicios = lista.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                int total = Servicios.Length;
                //using (IDataReader iDr = DatabaseFactory.CreateDatabase().ExecuteReader("dsige_ubica_operario_maps", fechaGPS, idSupervisor, idPerfil, Servicios[0]))
                //using (IDataReader iDr = DatabaseFactory.CreateDatabase().ExecuteReader("SP_S_UBICACION_OPERARIOS", fechaGPS, idSupervisor, idPerfil, Servicios[0]))
                using (IDataReader iDr = DatabaseFactory.CreateDatabase().ExecuteReader("SP_S_UBICACION_OPERARIOS_II", fechaGPS, idSupervisor, idPerfil, Servicios[0], id_supervisor, id_operario_supervisor))
                {
                    if (iDr != null)
                    {
                        while (iDr.Read())
                        {
                            lOb.Add(
                                    new UbicacionOperario()
                                    {
                                        id_gps = Convert.ToInt32(iDr["idGPS"]),
                                        id_ope = Convert.ToInt32(iDr["id_ope"]),
                                        ope_nombre = Convert.ToString(iDr["nom_ope"]),
                                        ope_tipo = Convert.ToString(iDr["tipo_ope"]),
                                        latitud = Convert.ToString(iDr["latitud"]),
                                        longitud = Convert.ToString(iDr["longitud"]),
                                        totAsig = Convert.ToInt32(iDr["totAsig"]),
                                        totReali = Convert.ToInt32(iDr["totReali"]),
                                        totPend = Convert.ToInt32(iDr["total_lec_pend"]),
                                        pocenAvance = Convert.ToInt32(iDr["porcen_avance"]),
                                        //fechaRegistro = Convert.ToDateTime(iDr["fecha_AgregaRegistro"]),
                                        isOnline = Convert.ToString(iDr["isOnline"]),
                                        gpsActivo = Convert.ToString(iDr["GpsActivo"]),
                                        estaBateria = Convert.ToString(iDr["estadoBateria"]),
                                        //fechaAndroid = Convert.ToString(iDr["fechaAndroid"]),
                                        fechaAndroid = Convert.ToDateTime(iDr["fechaAndroid"]).ToString("dd/MM/yyyy hh:mm:ss"),
                                        HoraAndroid = Convert.ToString(iDr["HoraAndroid"]),
                                        PlanDatos = Convert.ToString(iDr["PlanDatos"]),
                                        ModoAvion = Convert.ToString(iDr["ModoAvion"])
                                    }
                                );
                        }
                    }
                }
            


                return lOb;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Autor: rcontreras
        /// Fecha: 11-10-2015
        /// </summary>
        /// <param name="oRq"></param>
        /// <returns></returns>
        public List<Operario> DLlenaCombo(int idEmp, int idOpe, int idOpcion)
        {
            try
            {
                List<Operario> lOb = new List<Operario>();

                using (IDataReader iDr = DatabaseFactory.CreateDatabase().ExecuteReader("dsige_llena_combo_x_perfil", idEmp, idOpe, idOpcion))
                {
                    if (iDr != null)
                    {
                        while (iDr.Read())
                        {
                            lOb.Add(
                                    new Operario()
                                    {
                                        ope_id = Convert.ToInt32(iDr["ope_id"]),
                                        ope_nombre = Convert.ToString(iDr["ope_nombre"])
                                    }
                                );
                        }
                    }
                }

                return lOb;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public object Capa_Dato_get_ubicacionOperariosReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            Resultado res = new Resultado();

            try
            {
                //List<Ubicacion_Lectura> Obj_Lista = new List<Ubicacion_Lectura>();
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_UBICACION_OPERARIOS_REPARTO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;
                        cmd.Parameters.Add("@idOperario", SqlDbType.Int).Value = idOperario;
                        cmd.Parameters.Add("@fechaReparto", SqlDbType.VarChar).Value = idOperario;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                            //foreach (DataRow Fila in dt_detalle.Rows)
                            //{
                            //    Ubicacion_Lectura obj_entidad = new Ubicacion_Lectura();

                            //    obj_entidad.idLectura = Convert.ToInt32(Fila["id_Lectura"]);
                            //    obj_entidad.id_ope = Convert.ToInt32(Fila["id_Operario_Lectura"]);
                            //    obj_entidad.ope_nombre = Convert.ToString(Fila["ope_nombre"]);
                            //    obj_entidad.suministro = Convert.ToString(Fila["suministro_lectura"]);
                            //    obj_entidad.medidor = Convert.ToString(Fila["medidor_lectura"]);
                            //    obj_entidad.direcLectura = Convert.ToString(Fila["direccion_lectura"]);
                            //    obj_entidad.nom_cliente = Convert.ToString(Fila["nombreCliente_lectura"]);
                            //    obj_entidad.lectura = Convert.ToString(Fila["lectura"]);
                            //    obj_entidad.foto_lectura = Convert.ToString(Fila["tieneFoto_lectura"]);
                            //    obj_entidad.lec_estado = Convert.ToInt32(Fila["estado"]);
                            //    obj_entidad.latitud = Convert.ToString(Fila["latitud_lectura"]);
                            //    obj_entidad.longitud = Convert.ToString(Fila["longitud_lectura"]);
                            //    obj_entidad.fasig = Convert.ToString(Fila["fechaAsignacion_Lectura"]);
                            //    obj_entidad.ope_tipo = Convert.ToString(Fila["tipoUsuario"]);
                            //    obj_entidad.fmovil = Convert.ToString(Fila["fechaLecturaMovil_lectura"]);

                            //    Obj_Lista.Add(obj_entidad);
                            //}
                        }

                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }


        public object Capa_Dato_get_fotosUbicacionOperariosReparto(int idOperario, int anio, int mes, int idCargo)
        {
            Resultado res = new Resultado();
            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_UBICACION_OPERARIOS_REPARTO_FOTO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idOperario", SqlDbType.Int).Value = idOperario;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }

        public object Capa_Dato_get_recorridoOperariosReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            Resultado res = new Resultado();

            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_RECORRIDO_OPERARIOS_REPARTO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;
                        cmd.Parameters.Add("@idOperario", SqlDbType.Int).Value = idOperario;
                        cmd.Parameters.Add("@fechaReparto", SqlDbType.VarChar).Value = fechaReparto;


                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }

                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }


        public object Capa_Dato_get_ubicacionSuministroReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            Resultado res = new Resultado();

            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_UBICACION_SUMINISTRO_REPARTO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;
                        cmd.Parameters.Add("@idOperario", SqlDbType.Int).Value = idOperario;
                        cmd.Parameters.Add("@fechaReparto", SqlDbType.VarChar).Value = fechaReparto;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }

                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }

        public object Capa_Dato_get_fechasAsignacion(int anio, int mes, int idCargo)
        {
            Resultado res = new Resultado();

            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_RECORRIDO_OPERARIOS_REPARTO_COMBO_FECHAS", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }

                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }


        public object Capa_Dato_get_ubicacionSuministro_operario(int anio, int mes, int idCargo, string idSucursal, string zona, int idOperario)
        {
            Resultado res = new Resultado();

            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_REPORTE_CONSULTA_REPARTO_SUMINISTROS_MAPA", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;
                        cmd.Parameters.Add("@idSucursal", SqlDbType.VarChar).Value = idSucursal;
                        cmd.Parameters.Add("@zona", SqlDbType.VarChar).Value = zona;
                        cmd.Parameters.Add("@idOperario", SqlDbType.Int).Value = idOperario;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }

                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }



        public object Capa_Dato_get_fotosSuministros(int idReparto, int anio, int mes, int idCargo)
        {
            Resultado res = new Resultado();
            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_RECORRIDO_OPERARIOS_REPARTO_FOTO_SUMINISTRO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idReparto", SqlDbType.Int).Value = idReparto;
                        cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        cmd.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                        cmd.Parameters.Add("@idCargo", SqlDbType.Int).Value = idCargo;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                        res.ok = true;
                        res.data = dt_detalle;
                    }
                }
            }
            catch (Exception ex)
            {
                res.ok = false;
                res.data = ex.Message;
            }
            return res;
        }


    }
}
