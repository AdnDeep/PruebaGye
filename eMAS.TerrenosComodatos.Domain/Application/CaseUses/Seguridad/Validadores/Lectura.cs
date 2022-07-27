using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresSeguridad
    {
        private readonly ILogger<ValidadoresSeguridad> _logger;
        public ValidadoresSeguridad(ILogger<ValidadoresSeguridad> logger)
        {
            _logger = logger;
        }
        public bool InputUserController(string user, string controlador)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresBeneficiario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaServidorRemotoDataPaginada" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };

            if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El usuario esta vacio");
                }
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(controlador) || string.IsNullOrWhiteSpace(controlador))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El Controlador esta vacio");
                }
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }

        public bool RespuestaServidor(ref ResultadoViewModel entrada)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresBeneficiario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaServidor" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto es nulo.");
                }
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
