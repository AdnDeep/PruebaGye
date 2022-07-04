using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresEscrituraTramite
    {
        public void MapearAnexoTramiteEditViewModelASmcAnexoTramite(ref AnexoTramiteEditViewModel entrada
            , ref SmcAnexoTramite salida, string usuario, string controlador, string pcclient)
        {
            salida.IdAnexoTramite = entrada.idanexotramite;
            salida.IdTramite = entrada.idtramite;
            salida.Link = entrada.link;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearObservacionTramiteEditViewModelASmcTramiteDesc(ref ObservacionTramiteEditViewModel entrada
            , ref SmcTramitesDesc salida, string usuario, string controlador, string pcclient)
        {
            salida.IdTramiteDesc = entrada.idtramitedesc;
            salida.IdTramite = entrada.idtramite;
            salida.Fecha = entrada.fecha;
            salida.Observacion = entrada.observacion;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearOficioTramiteEditViewModelASmcOficioOtrasDireccione(ref OficioTramiteEditViewModel entrada
            , ref SmcOficioOtrasDireccione salida, string usuario, string controlador, string pcclient)
        {
            salida.IdOficioOtrasDirecciones = entrada.idoficiootrasdirecciones;
            salida.IdTramite = entrada.idtramite;
            salida.Secuencia = entrada.secuencia;
            salida.IdDireccion = entrada.iddireccion;
            salida.Oficio = entrada.oficio;
            salida.FechaEnvio = entrada.fechaenvio;
            salida.OficioRespuesta = entrada.oficiorespuesta;
            salida.FechaRespuesta = entrada.fecharespuesta;

            salida.PdpEstado = true;
            salida.PdpUsuarioCreacion = usuario;
            salida.PdpFechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
        public void MapearTopografiaTramiteEditViewModelASmcTopografiaTerrenoEdict(ref TopografiaTerrenoEditViewMoel entrada
            , ref SmcTopografiaTerreno salida, string usuario, string controlador, string pcclient)
        {
            salida.IdTopografiaTerreno = entrada.idtopografiaterreno;
            salida.IdTipoTopografiaTerreno = entrada.idtipotopografiaterreno;
            salida.IdTramite = entrada.idtramite;
            salida.Oficio = entrada.oficio;
            salida.FechaEnvio = entrada.fechaenvio;
            salida.OficioRespuesta = entrada.oficiorespuesta;
            salida.FechaRespuesta = entrada.fecharespuesta;

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
