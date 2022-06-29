﻿using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceBeneficiarioEscritura : IServiceBeneficiarioEscritura
    {
        private readonly BeneficiarioLogicEscritura _logicEscrituraBeneficiario;
        private readonly BeneficiarioLogicValidacion _logicValidacionBeneficiario;
        private readonly MapeadoresEscrituraBeneficiario _mapeadoresEscrituraBeneficiario;
        private readonly ValidadoresEscrituraBeneficiarios _validadoresEscrituraBeneficiarios;
        private readonly ILogger<ServiceBeneficiarioEscritura> _logger;
        public ServiceBeneficiarioEscritura(ILogger<ServiceBeneficiarioEscritura> logger
            , ValidadoresEscrituraBeneficiarios validadoresEscrituraBeneficiarios
            , MapeadoresEscrituraBeneficiario mapeadoresEscrituraBeneficiario
            , BeneficiarioLogicEscritura logicEscrituraBeneficiario
            , BeneficiarioLogicValidacion logicValidacionBeneficiario)
        {
            _logicEscrituraBeneficiario = logicEscrituraBeneficiario;
            _logicValidacionBeneficiario = logicValidacionBeneficiario;
            _mapeadoresEscrituraBeneficiario = mapeadoresEscrituraBeneficiario;
            _validadoresEscrituraBeneficiarios = validadoresEscrituraBeneficiarios;
            _logger = logger;
        }
        public ResultadoDTO<BeneficiarioEditViewModel> Agregar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultadoVista = new ResultadoDTO<BeneficiarioEditViewModel>();
            // Validar datos de request
            bool respuestaValidacion = _validadoresEscrituraBeneficiarios
                .ValidarDatosClienteBeneficiarioEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            // Consumir lógica validación
            BeneficiariosValidacion1Filter modelValidacion = new BeneficiariosValidacion1Filter();
            model.id = 0;
            _mapeadoresEscrituraBeneficiario
                .MapearModelBeneficiarioEditViewAModelValidacion1("AGREGAR", ref model, ref modelValidacion);

            Tuple<List<SmcValidacionEscritura>, string> respuestaLogic = null;

            var parametros = $"ServiceBeneficiarioEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "Actualizar" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            try
            {
                respuestaLogic = _logicValidacionBeneficiario.ValidarEntidadAEscribir(modelValidacion);
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
            // Validar Lógica respuesta Logic
            bool respuestaValServ = _validadoresEscrituraBeneficiarios
                                        .ValidarDatosServidorBeneficiarioEditModel(ref respuestaLogic, ref resultadoVista);
            if (!respuestaValServ)
                return resultadoVista;

            SmcBeneficiario _beneficiarioEntidad = new SmcBeneficiario();
            _mapeadoresEscrituraBeneficiario
                .MapearModelBeneficiarioEditViewAModelBeneficiario(ref model, ref _beneficiarioEntidad, usuario, controlador, pcclient);

            // Consumir logica 1
            Tuple<SmcBeneficiarioEdit, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logicEscrituraBeneficiario.Agregar(_beneficiarioEntidad);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }

                resultadoVista.mensaje = "Se produjo un error en la aplicación [2]. Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            // validar respuesta logica 1
            bool respuestaGestionGrabar = _validadoresEscrituraBeneficiarios
                                            .ValidarRespuestaServidorGestionGrabar(ref respuestaLogicDB, ref resultadoVista);

            if (!respuestaGestionGrabar)
                return resultadoVista;

            //retornar Respuesta
            return resultadoVista;
        }
    }
}
