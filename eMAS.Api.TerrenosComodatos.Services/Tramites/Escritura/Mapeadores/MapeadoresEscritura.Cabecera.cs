using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresEscrituraTramite
    {
        public MapeadoresEscrituraTramite()
        { 
        }
        public void MapearTramiteEditViewModelASmcTramite(ref TramiteEditViewModel entrada
            , ref SmcTramite salida, string usuario, string controlador, string pcclient)
        {
            salida.IdTramite = entrada.idtramite;
            salida.Anio = entrada.anio;
            salida.Secuencia = entrada.secuencia;
            salida.IdSector = entrada.idsector;
            salida.Manzana = entrada.manzana;
            salida.Lote = entrada.lote;
            salida.Division = entrada.division;
            salida.Phv = entrada.phv;
            salida.Phh  = entrada.phh;
            salida.Numero = entrada.numero == 0 ? (short)1 : entrada.numero;
            salida.IdBeneficiario = entrada.idbeneficiario;
            salida.IdTipoContrato = entrada.idtipocontrato;
            salida.AreaSolar = entrada.areasolar;
            salida.AniosPlazo  = entrada.aniosplazo;
            salida.IdEstado  = entrada.idestado;
            salida.IdDireccion  = entrada.iddireccion;
            salida.AprobacionConcejoMun  = entrada.aprobacionconcejomun;
            salida.FechaAprobConcejoMun  = entrada.fechaaprobconcejomun;
            salida.FechaEscritura  = entrada.fechaescritura;
            salida.FechaInsRegProp = entrada.fechainsregprop;
            salida.OficioRevocatoriaMod = entrada.oficiorevocatoriamod;
            salida.FechaInsRevocatoria  = entrada.fechainsrevocatoria;
            salida.ObservacionJuridico  = entrada.observacionjuridico;
            salida.BaseOrigen  = entrada.baseorigen;
            salida.OficioAg  = entrada.oficioag;
            salida.OficioDase = entrada.oficiodase;
            
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
