using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LecturasRepartoLds.Controllers
{
    public class ReportesRepartoController : Controller
    {
        //
        // GET: /ReportesReparto/

        public ActionResult consultaReparto_index()
        {
            return View();
        }

        public ActionResult consultaSuministro_index()
        {
            return View();
        }

        public ActionResult consultaRepartoDetallado_index()
        {
            return View();
        }

    }
}
