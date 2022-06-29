using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Auxiliars
{
    public class ValidateDataProvider
    {
        private readonly ILogger<ValidateDataProvider> _logger;
        public ValidateDataProvider(ILogger<ValidateDataProvider> logger)
        {
            _logger = logger;
        }
        public bool ValidateRepository(ref ResultadoDTO<Tuple<List<KeyValueSelect>, string>> entrada, string key)
        {
            bool puedeContinuar = false;

            if (entrada == null)
            {
                _logger.LogError($"Generic Data Provider Key: {key}. La respuesta desde el servidor de Datos es un objeto vacío. (1)");
                return puedeContinuar;
            }
            if (entrada.dataresult == null)
            {
                _logger.LogError($"Generic Data Provider Key: {key}. La respuesta desde el servidor de Datos es un objeto vacío. (2)");
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.dataresult.Item2) 
                || string.IsNullOrWhiteSpace(entrada.dataresult.Item2))
            {
                _logger.LogError($"Generic Data Provider Key: {key}. La respuesta desde el servidor de Datos es incorrecta. (3)");
                return puedeContinuar;
            }
            if (entrada.dataresult.Item2 != "OK")
            {
                _logger.LogError($"Generic Data Provider Key: {key}. La respuesta desde el servidor de Datos es (4): {entrada.dataresult.Item2}");
                return puedeContinuar;
            }
            var mensajeErrRepositorio = entrada.mensajes?.FirstOrDefault(fod => fod.codigo == "GRGIMPLGEN001")?.descripcion;
            if (!(string.IsNullOrWhiteSpace(mensajeErrRepositorio) || string.IsNullOrEmpty(mensajeErrRepositorio)))
            {
                _logger.LogError($"Generic Data Provider Key: {key}. La respuesta desde el servidor de Datos es (5): {mensajeErrRepositorio}");
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
