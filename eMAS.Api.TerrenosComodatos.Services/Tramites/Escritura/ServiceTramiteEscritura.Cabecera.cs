using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteEscritura : IServiceTramiteEscritura
    {
        private const string objValidadotEscrituraTramite = "SmcComodato_GetDataValidationTramite_Escritura";
        public ResultadoDTO<int> Agregar(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "Agregar" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            bool respuestaValidacion = _validadores
                .ValidarDatosClienteTramiteEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;
            
            string strParamValidator =_mapeadores
                                        .MapearTramiteEditViewModelADataValidationEscritura(ref model);
            
            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramite);
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

            bool validaRespuestaLogicDataValidation = _validadores
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteServidor(ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            SmcTramite _tramiteEntidad = new SmcTramite();

            _mapeadores
                .MapearTramiteEditViewModelASmcTramite(ref model, ref _tramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.Agregar(_tramiteEntidad);
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

            bool respuestaGestionGrabar = _validadores
                                                .ValidarRespuestaServidorEntidadPrincipalAccionAgregar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
        public ResultadoDTO<int> Actualizar(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "Actualizar" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            bool respuestaValidacion = _validadores
                .ValidarDatosClienteTramiteEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            string strParamValidator = _mapeadores
                                        .MapearTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramite);
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

            bool validaRespuestaLogicDataValidation = _validadores
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteServidor(ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            SmcTramite _tramiteEntidad = new SmcTramite();

            _mapeadores
                .MapearTramiteEditViewModelASmcTramite(ref model, ref _tramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.Actualizar(_tramiteEntidad);
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

            bool respuestaGestionGrabar = _validadores
                                                .ValidarRespuestaServidorEntidadPrincipalAccionActualizar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
    }
}
