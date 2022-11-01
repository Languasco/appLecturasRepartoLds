using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DSIGE;
using DSIGE.Modelo;
using DSIGE.Negocio;

using Excel = OfficeOpenXml;
using Style = OfficeOpenXml.Style;
using System.Web.UI;
using Newtonsoft.Json;

namespace DSIGE.Web.Controllers
{
    public class Ubicacion_OperariosController : Controller
    {
        //
        // GET: /Ubicacion_Operarios/

        public ActionResult Inicio()
        {
            ViewBag.IdPerfil = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.idPerfil;
            return View();
        }
 

        public ActionResult Inicio_new()
        {
            ViewBag.IdPerfil = ((Sesion)Session["Session_Usuario_Acceso"]).usuario.idPerfil;
            return View();
        }

        public ActionResult ubicacionOperario_index()
        {
            return View();
        }

 

        [HttpPost]
        public ActionResult JsonUbicacion_OperariosGPS(string __a, string __b,string lista, int id_supervisor, int id_operario_supervisor)
        {
            int idSuper=0;
            if(__a=="" || __a== null ) { idSuper = 0; }else{idSuper = Convert.ToInt32(__a);}
            return new ContentResult
            {
                Content = MvcApplication._Serialize(new NUbicacion_Operarios().NListaOperariosGPS(
                __b,
                idSuper, 
                Convert.ToInt32(((Sesion)Session["Session_Usuario_Acceso"]).usuario.idPerfil), 
                lista, id_supervisor, id_operario_supervisor
                )),
                ContentType = "application/json"
            };
        }



        [HttpPost]
        public JsonResult ListandoServicios()
        {
            
            try
            {
                Cls_Negocio_AsignarOrdenTrabajo obj_negocio = new Cls_Negocio_AsignarOrdenTrabajo();
                var loDatos = obj_negocio.Capa_Negocio_Get_ListaServicioXusuario(((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                // loDatos = obj_negocio.Capa_Negocio_Get_ListaServicioXusuario();
                return Json(loDatos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
               throw ex;
            }

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
        public string get_ubicacionOperariosReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_ubicacionOperariosReparto(anio, mes, idCargo, idOperario, fechaReparto);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string get_fotosUbicacionOperariosReparto(int idOperario, int anio, int mes , int idCargo, string fechaReparto, string selfie )
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_fotosUbicacionOperariosReparto(idOperario, anio, mes, idCargo, fechaReparto, selfie);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string get_recorridoOperarioReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_recorridoOperariosReparto(anio, mes, idCargo, idOperario, fechaReparto);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string get_ubicacionSuministroReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_ubicacionSuministroReparto(anio, mes, idCargo, idOperario, fechaReparto);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string get_fechasAsignacion(int anio, int mes, int idCargo)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_fechaAsignacion(anio, mes, idCargo);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



        [HttpPost]
        public string get_ubicacionSuministro_operario(int anio, int mes, int idCargo, string idSucursal, string zona , int idOperario)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_ubicacionSuministro_operario(anio, mes, idCargo, idSucursal, zona, idOperario);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string get_fotosSuministros(int idReparto, int anio, int mes, int idCargo)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_fotosSuministros(idReparto, anio, mes, idCargo);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string get_fotosSeguimientoOperariosReparto(int idOperario, int anio, int mes, int idCargo, string fechaReparto, string selfie)
        {
            object loDatos;
            try
            {
                NUbicacion_Operarios obj_negocio = new NUbicacion_Operarios();
                loDatos = obj_negocio.Capa_Negocio_get_fotosSeguimientoOperariosReparto(idOperario, anio, mes, idCargo, fechaReparto, selfie);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }



    }
}
