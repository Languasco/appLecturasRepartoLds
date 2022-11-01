using DSIGE.Dato;
using DSIGE.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIGE.Negocio
{
    public class NUbicacion_Operarios
    {
        /// <summary>
        /// Autor: rcontreras
        /// Fecha: 30-09-2015
        /// </summary>
        /// <returns></returns>
        public List<UbicacionOperario> NListaOperariosGPS(string fechaGPS, int idSupervisor, int idPerfil, string lista, int id_supervisor, int id_operario_supervisor)
        {
            try
            {
                return new DUbicacion_Operarios().DListaOperariosGPS(fechaGPS, idSupervisor, idPerfil, lista, id_supervisor, id_operario_supervisor);
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
        public List<Operario> NLlenaCombo(int idEmp, int idOpe, int idOpcion)
        {
            try
            {
                return new DUbicacion_Operarios().DLlenaCombo(idEmp, idOpe, idOpcion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_get_ubicacionOperariosReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto )
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_ubicacionOperariosReparto(anio, mes, idCargo, idOperario, fechaReparto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_get_fotosUbicacionOperariosReparto(int idOperario, int anio, int mes, int idCargo, string fechaReparto, string selfie)
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_fotosUbicacionOperariosReparto(idOperario, anio, mes, idCargo, fechaReparto, selfie);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public object Capa_Negocio_get_recorridoOperariosReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_recorridoOperariosReparto(anio, mes, idCargo, idOperario, fechaReparto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public object Capa_Negocio_get_ubicacionSuministroReparto(int anio, int mes, int idCargo, int idOperario, string fechaReparto)
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_ubicacionSuministroReparto(anio, mes, idCargo, idOperario, fechaReparto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_get_fechaAsignacion(int anio, int mes, int idCargo )
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_fechasAsignacion(anio, mes, idCargo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_get_ubicacionSuministro_operario(int anio, int mes, int idCargo, string idSucursal, string zona, int idOperario)
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_ubicacionSuministro_operario(anio, mes, idCargo, idSucursal, zona, idOperario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_get_fotosSuministros(int idReparto, int anio, int mes, int idCargo)
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_fotosSuministros(idReparto, anio, mes, idCargo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_get_fotosSeguimientoOperariosReparto(int idOperario, int anio, int mes, int idCargo, string fechaReparto, string selfie)
        {
            try
            {
                DUbicacion_Operarios Objeto_Dato = new DUbicacion_Operarios();
                return Objeto_Dato.Capa_Dato_get_fotosSeguimientoOperariosReparto(idOperario, anio, mes, idCargo, fechaReparto, selfie);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
