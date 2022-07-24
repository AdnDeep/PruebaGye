
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool RespuestaReporteGeneralServidorRemotoById(ref ResultadoDTO<TramiteReportServerViewModel> entrada
            , ref TramiteReportClientViewModel salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaReporteGeneralServidorRemotoById" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta desde el servidor es un objeto nulo [1].");
                }
                salida.mensaje = "[1] La respuesta del servidor no fue la esperada, por favor vuelva a intentar luego.";

                salida.canContinue = false;
                return puedeContinuar;
            }
            
            if (string.IsNullOrEmpty(entrada.tipo) || string.IsNullOrWhiteSpace(entrada.tipo))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El tipo de respuesta desde el servidor es de tipo incorrecto [2].");
                }
                salida.mensaje = "[2] La respuesta del servidor no fue la esperada, por favor vuelva a intentar luego.";

                salida.canContinue = false;
                return puedeContinuar;
            }

            if (entrada.dataresult == null && entrada.tipo != "EXITO")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El resultado del objeto respuesta desde el servidor es un objeto nulo [3].");
                }
                salida.mensaje = "[3] La respuesta del servidor no fue la esperada, por favor vuelva a intentar luego.";
                salida.canContinue = false;
                return puedeContinuar;
            }
            if (string.IsNullOrWhiteSpace(entrada.dataresult.contentReport) || string.IsNullOrEmpty(entrada.dataresult.contentReport))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El resultado del objeto respuesta desde el servidor es un objeto nulo [4]. El reporte está vacío.");
                }
                salida.mensaje = "[4] La respuesta del servidor no fue la esperada, por favor vuelva a intentar luego.";

                salida.canContinue = false;
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
