using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public class MapeadoresEliminacionBeneficiario
    {
        public MapeadoresEliminacionBeneficiario()
        { 
        }
        public void MapearBeneficiarioDeleteModelABeneficiario(short id, ref SmcBeneficiario salida
            , string usuario, string controlador, string pcclient)
        {
            salida.IdBeneficiario = id;
            salida.PdpEstado = false;
            salida.PdpUsuarioUltimaModificacion = usuario;
            salida.PdpFechaUltimaModificacion = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            salida.PdpUltimaTransaccion = controlador;
            salida.PdpUltimaPcCliente = pcclient;
        }
    }
}
