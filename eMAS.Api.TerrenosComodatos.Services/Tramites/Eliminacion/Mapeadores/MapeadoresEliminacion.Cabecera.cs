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
    }
}
