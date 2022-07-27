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
        public ResultadoDTO<int> AgregarObservacion(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "AgregarObservacion" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            model.idtramitedesc = 0;

            string strParamValidator = _mapeadores
                                        .MapearObservacionTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteObservacion);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteObservacionServidor(model.idtramitedesc
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteObservacionEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcTramitesDesc _observacionTramiteEntidad = new SmcTramitesDesc();

            _mapeadores
                .MapearObservacionTramiteEditViewModelASmcTramiteDesc(ref model, ref _observacionTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.AgregarObservacion(_observacionTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteObservacionAccionAgregar(ref respuestaLogicDB, ref resultadoVista);

            if (!respuestaGestionGrabar)
                return resultadoVista;

            resultadoVista.dataresult = respuestaLogicDB.Item1;

            return resultadoVista;
        }
        public ResultadoDTO<int> ActualizarObservacion(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ActualizarObservacion" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            string strParamValidator = _mapeadores
                                        .MapearObservacionTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteObservacion);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteObservacionServidor(model.idtramitedesc
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteObservacionEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcTramitesDesc _observacionTramiteEntidad = new SmcTramitesDesc();

            _mapeadores
                .MapearObservacionTramiteEditViewModelASmcTramiteDesc(ref model, ref _observacionTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.ActualizarObservacion(_observacionTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteObservacionAccionActualizar(ref respuestaLogicDB, ref resultadoVista);

            if (!respuestaGestionGrabar)
                return resultadoVista;

            resultadoVista.dataresult = respuestaLogicDB.Item1;

            return resultadoVista;
        }
    }
}
