

using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic.Generic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceDataProviderGeneric : IServiceDataProviderGeneric
    {
        public ResultadoDTO<ExportSingleResult> GetDataExport(string codigo, string paramsFilter)
        {
            ResultadoDTO<ExportSingleResult> resultadoExportacion = new ResultadoDTO<ExportSingleResult>();
            resultadoExportacion.dataresult = resultadoExportacion.dataresult ?? new ExportSingleResult();

            Tuple<List<ExportSingle>, string, string> resultadoLogic = null;
            var parametros = $"GetDataExport Service Layer ";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "GetDataExport" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            try
            {
                resultadoLogic = _logicDataProviderGeneric.ObtenerDataExportByParam(codigo, paramsFilter);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                resultadoExportacion.dataresult.codigoestado = 500;
                resultadoExportacion.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos {1}.";
                resultadoExportacion.tipo = "ADVERTENCIA";
                return resultadoExportacion;
            }

            bool validaRespServ = _validadoresGeneric.ValidaRepuestaExportacionServidor(ref resultadoLogic, ref resultadoExportacion);
            
            if (!validaRespServ)
                return resultadoExportacion;

            try
            {
                _logicDataProviderGeneric.ProcesaRespuestaExportSingleData(ref resultadoLogic, ref resultadoExportacion);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                resultadoExportacion.dataresult.codigoestado = 500;
                resultadoExportacion.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos {2}.";
                resultadoExportacion.tipo = "ADVERTENCIA";
                return resultadoExportacion;
            }

            return resultadoExportacion;
        }
    }
}
