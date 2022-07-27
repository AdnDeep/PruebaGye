using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteLectura : IServiceTramiteLectura
    {
        public ResultadoDTO<TramiteEditViewModel> ObtenerDataInformeGeneral(short id)
        {


            var parametros = $"ServiceTramiteLectura Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ObtenerDataInformeGeneral" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<TramiteEditViewModel> resultadoConsultaTramite = new ResultadoDTO<TramiteEditViewModel>();
            ResultadoDTO<List<OficioTramiteListViewModel>> resultaConsultaTramiteOficio = new ResultadoDTO<List<OficioTramiteListViewModel>>();
            
            resultadoConsultaTramite =ConsultarPorId(id);

            resultaConsultaTramiteOficio= ConsultarOficiosPorIdTramite(id);

            TramiteEditViewModel tramite = resultadoConsultaTramite.dataresult;
            Mensaje mensajeError = resultaConsultaTramiteOficio
                            .mensajes
                            .FirstOrDefault(fod => fod.codigo == "RESPERRSERV");
            
            if (mensajeError != null)
            {
                resultaConsultaTramiteOficio.tipo = mensajeError.tipo;
                resultaConsultaTramiteOficio.mensaje = mensajeError.descripcion;
            }
            
            if (tramite == null)
            {
                tramite = new TramiteEditViewModel();

                resultadoConsultaTramite.mensajes.Add(new Mensaje
                {
                    codigo = "SINDATOS",
                    descripcion = "No hay datos de tramite para el reporte.",
                    tipo = "ADVERTENCIA"
                });
            }

            tramite.lsOficios = resultaConsultaTramiteOficio.dataresult;
            if (tramite.lsOficios == null)
            {
                tramite.lsOficios = new List<OficioTramiteListViewModel>();
                resultadoConsultaTramite.mensajes.Add(new Mensaje
                {
                    codigo = "SINDATOS",
                    descripcion = "No hay datos de Control de Oficios para el reporte.",
                    tipo = "ADVERTENCIA"
                });
            }

            return resultadoConsultaTramite;
        }
        

    }
}
