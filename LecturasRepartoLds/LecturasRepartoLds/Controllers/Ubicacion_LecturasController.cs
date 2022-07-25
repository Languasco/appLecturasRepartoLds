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
using Newtonsoft.Json;

namespace DSIGE.Web.Controllers
{
    public class Ubicacion_LecturasController : Controller
    {
        //
        // GET: /Ubicacion_Lecturas/

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Inicio_new()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult JsonUbicacionLecturas_OperariosGPS(string operario, string fechaAsig, string suministro, string medidor, string lista)
        {
            try
            {
                return new ContentResult
                {
                    Content = MvcApplication._Serialize(new NUbicacion_Lecturas().NListaLecturasOperariosGPS(
                            Convert.ToInt32(operario),
                            Convert.ToString(fechaAsig),
                            suministro,
                            medidor,
                            ((Sesion)Session["Session_Usuario_Acceso"]).empresa.emp_id,
                           Convert.ToString(lista)
                    )),
                    ContentType = "application/json"
                };
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
        public string ListandoServicios()
        {
            object loDatos;
            try
            {
                NUbicacion_Lecturas obj_negocio = new NUbicacion_Lecturas();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaServicios();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string ListandoServicios_new()
        {
            object loDatos;
            try
            {
                NUbicacion_Lecturas obj_negocio = new NUbicacion_Lecturas();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaServicios_new();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoOperarios()
        {
            object loDatos;
            try
            {
                NUbicacion_Lecturas obj_negocio = new NUbicacion_Lecturas();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaOperarios();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string ListandoUbicacionLecturas(string fechaAsigna, int servicio, int operario)
        {
            object loDatos;
            try
            {
                NUbicacion_Lecturas obj_negocio = new NUbicacion_Lecturas();
                loDatos = obj_negocio.Capa_Negocio_Get_UbicacionLecturas(fechaAsigna, servicio, operario);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


    }
}
