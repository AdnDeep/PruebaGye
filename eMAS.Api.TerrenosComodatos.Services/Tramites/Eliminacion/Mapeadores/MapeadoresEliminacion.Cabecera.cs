using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresEliminacionTramite
    {
        public MapeadoresEliminacionTramite()
        { 
        }
        public void MapearTramiteEditViewModelASmcTramite(short idTramite
            , ref SmcTramite salida, string usuario, string controlador, string pcclient)
        {
            salida.IdTramite = idTramite;
            
            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearTramiteAnexoEditViewModelASmcAnexoTramite(short idAnexoTramite
            , ref SmcAnexoTramite salida, string usuario, string controlador, string pcclient)
        {
            salida.IdAnexoTramite = idAnexoTramite;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearTramiteOficioEditViewModelASmcOficioOtrasDireccione(short idOficioOtrasDirecciones
            , ref SmcOficioOtrasDireccione salida, string usuario, string controlador, string pcclient)
        {
            salida.IdOficioOtrasDirecciones = idOficioOtrasDirecciones;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearTramiteObservacionEditViewModelASmcTramitesDesc(short idTramiteDesc
            , ref SmcTramitesDesc salida, string usuario, string controlador, string pcclient)
        {
            salida.IdTramiteDesc = idTramiteDesc;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearTramiteTopografiaEditViewModelASmcTopografiaTerreno(short idTopografiaTerreno
            , ref SmcTopografiaTerreno salida, string usuario, string controlador, string pcclient)
        {
            salida.IdTopografiaTerreno = idTopografiaTerreno;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
    }
}
