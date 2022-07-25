using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIGE.Modelo
{
    public class ConsultaSuministro_E
    {
		public int id_Reparto { get; set; }
		public string tipoServicio { get; set; }
		public string periodo { get; set; }
		public string suministro { get; set; }
		public string ruta { get; set; }
		public string sucursal { get; set; }
		public string tieneFoto { get; set; }
		public string inicioReparto { get; set; }
		public string finReparto { get; set; }
		public string fechaMaxReparto { get; set; }
		public string fechaRecepcion { get; set; }
		public string estado { get; set; }
		public string latitud { get; set; }
		public string longitud { get; set; }

	}
}
