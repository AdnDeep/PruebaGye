using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceBeneficiarioEliminacion : IServiceBeneficiarioEliminacion
    {
        private readonly BeneficiarioLogicEliminacion _logicEliminacionBeneficiario;
        private readonly MapeadoresEliminacionBeneficiario _mapeadoresEliminacionBeneficiario;
        private readonly ValidadoresEliminar _validadoresEliminacionBeneficiarios;
        private readonly ILogger<ServiceBeneficiarioEliminacion> _logger;
        public ServiceBeneficiarioEliminacion(ILogger<ServiceBeneficiarioEliminacion> logger
            , ValidadoresEliminar validadoresEliminacionBeneficiarios
            , MapeadoresEliminacionBeneficiario mapeadoresEliminacionBeneficiario
            , BeneficiarioLogicEliminacion logicEliminacionBeneficiario)
        {
            _logicEliminacionBeneficiario = logicEliminacionBeneficiario;
            _mapeadoresEliminacionBeneficiario = mapeadoresEliminacionBeneficiario;
            _validadoresEliminacionBeneficiarios = validadoresEliminacionBeneficiarios;
            _logger = logger;
        }

        public ResultadoDTO<string> Eliminar(BeneficiarioDeleteViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<string> resultadoVista = new ResultadoDTO<string>();

            bool respuestaValidacionCliente = _validadoresEliminacionBeneficiarios
                                                .ValidarDatosEliminacionClienteBeneficiario(ref model, ref resultadoVista);
            
            if (!respuestaValidacionCliente)
                return resultadoVista;

            SmcBeneficiario _beneficiarioEntidad = new SmcBeneficiario();
            _mapeadoresEliminacionBeneficiario.MapearBeneficiarioDeleteModelABeneficiario(ref model, ref _beneficiarioEntidad, usuario, controlador, pcclient);

            var parametros = $"ServiceBeneficiarioEliminacion Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "Eliminar" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            string respuestaLogic = "";
            try
            {
                respuestaLogic = _logicEliminacionBeneficiario.Eliminar(_beneficiarioEntidad);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }

                resultadoVista.mensaje = "Se produjo un error en la aplicación [1]. Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            bool validaRespuestaLogic = _validadoresEliminacionBeneficiarios.ValidaRespuestaServidorLogic(respuestaLogic, ref resultadoVista);

            if (!validaRespuestaLogic)
                return resultadoVista;

            return resultadoVista;           
        }
    }
}
