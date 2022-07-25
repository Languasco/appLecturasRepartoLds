using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSIGE.Negocio;
using DSIGE.Modelo;

namespace DSIGE.Web.Controllers
{
    public class AsignaOrdenTrabajoController : Controller
    {
        //
        // GET: /AsignaOrdenTrabajo/

        public ActionResult AsignaOrdenTrabajo()
        {
            return View();
        }

        public static string _Serialize(object value, bool ignore = false)
        {
            var SerializerSettings = new JsonSerializerSettings()
            {
                MaxDepth = Int32.MaxValue,
                NullValueHandling = (ignore == true ? NullValueHandling.Ignore : NullValueHandling.Include)
            };
            return JsonConvert.SerializeObject(value, Formatting.Indented, SerializerSettings);
        }

        [HttpPost]
        public string ListandoLocales()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaLocales();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string ListandoServicios()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaServicioXusuario(((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                // loDatos = obj_negocio.Capa_Negocio_Get_ListaServicioXusuario();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoEstados()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaEstados();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoTecnicos(int id_local, int id_tipo_servicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaTecnicos(id_local, id_tipo_servicio, ((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string ListandoOrdenesTrabajoGeneral(int id_local, int id_tipo_servicio, int estado, string suministro, string medidor, int tecnico, string fechaAsignacion)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_Get_ListandoOrdenesTrabajoGeneral(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, id_local, id_tipo_servicio, estado, suministro, medidor, tecnico, fechaAsignacion);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string LecturasRelectura_Historico(string suministro, int tiposervicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_LecturasRelectura_Historico(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, suministro, tiposervicio);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string CortesReconexiones_Historico(string suministro, int tiposervicio)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_CortesReconexiones_Historico(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, suministro, tiposervicio);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }




        [HttpPost]
        public string UpdateFechaAplicativoMovil(string fechamovil, int tipoServicio, List<int> List_codigos)
        {
            object loDatos = null;
            try
            {
                var usuario = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id;
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_UpdateFechaAplicativoMovil(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, fechamovil, usuario, tipoServicio, List_codigos);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string UpdateReasignaOperador(int TipoServicio, int tecnico, string fechaReasigna, List<int> List_codigos, int opcion)
        {

            object loDatos = null;
            try
            {
                var usuario = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id;
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_UpdateReasignaOperador(((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id, usuario, TipoServicio, tecnico, fechaReasigna, List_codigos, opcion);
                return _Serialize(loDatos, true);

            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        ///------------------------------------------
        ///----- ASIGNAR REPARTO LDS 
        ///------------------------------------------

        public ActionResult asignarReparto_index()
        {
            return View();
        }


        [HttpPost]
        public string getCargos()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getCargos();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string getEstados()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getEstados();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string getSucursales()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getSucursales();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string getOperarios()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getOperarios();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string getSupervisores()
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getSupervisores();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        public string getRepartos_asignarReasignar(string anio, string mes, int idCargo, int idEstado)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getRepartos_asignarReasignar(anio, mes, idCargo, idEstado);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string GenerarAsignacionReasignacion(List<Asignar_E> ListaOrdenes, int anio, int mes, int idCargo, int  idEstado, string tipo, int idTecnico)
        {
            object loDatos = null;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_GenerarAsignacionReasignacion(ListaOrdenes, anio, mes, idCargo, idEstado, tipo, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, idTecnico);
 
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        public string getExportar_Asignacion(string anio, string mes, int idCargo, int idEstado)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getExportar_Asignacion(anio, mes, idCargo, idEstado);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        public string InsertaExcel_asignacion(HttpPostedFileBase file, int anio , int mes, int idCargo, int idEstado)
        {

            object loDatos = null;
            string nomExcel = "";
            string extension = "";
            string NombreArchivo = "";
            string fileLocation = "";
            try
            {
                extension = System.IO.Path.GetExtension(file.FileName);

                //-----generando clave unica---
                var guid = Guid.NewGuid();
                var guidB = guid.ToString("B");
                nomExcel = Guid.Parse(guidB) + extension;

                NombreArchivo = file.FileName;
                fileLocation = Server.MapPath("~/Upload") + "\\" + nomExcel;

                if (System.IO.File.Exists(fileLocation))
                {
                    System.IO.File.Delete(fileLocation);
                }

                file.SaveAs(fileLocation);

                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_save_temporalImportarAsignacion(fileLocation, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, NombreArchivo, anio, mes, idCargo, idEstado);

                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string GrabarExcel_importarAsignacion(int anio, int mes, int idCargo, int idEstado)
        {
            object loDatos = null;
            try
            {
                var usuario = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id;
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();

                loDatos = obj_negocio.Capa_Negocio_save_importacionAsignacion(anio, mes, idCargo, idEstado, usuario);

                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getConsultaRepartoCab(string anio, string mes, int idCargo, int idSucursal)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getConsultaReparto(anio, mes, idCargo, idSucursal);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        public string getExportar_consultaReparto(string anio, string mes, int idCargo, int idSucursal)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getExportar_consultaReparto(anio, mes, idCargo, idSucursal);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string setfinalizarReparto(int anio, int mes, int idCargo, int idSucursal )
        {
            object loDatos = null;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_setFinalizarReparto(anio, mes, idCargo , idSucursal,((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);

                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        public string getSuministrosAsignados(string anio, string mes, int idCargo, string idSucursal, string zona)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getSuministrosAsignados(anio, mes, idCargo, idSucursal, zona);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        public string getReporteConsultaSuministroCab(string suministro)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getReporteConsultaSuministro(suministro);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        public string getDescargar_reporteDetalladoReparto(string anio, string mes, int idCargo, int tipoReporte)
        {
            object loDatos;
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                loDatos = obj_negocio.Capa_Negocio_getDescargar_reporteDetalladoReparto(anio, mes, idCargo, tipoReporte);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


    }
}
