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
        public ResultadoDTO<int> AgregarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "AgregarAnexo" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            model.idanexotramite = 0;

            string strParamValidator = _mapeadores
                                        .MapearAnexoTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteAnexo);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteAnexoServidor(model.idanexotramite
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteAnexoEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcAnexoTramite _anexoTramiteEntidad = new SmcAnexoTramite();

            _mapeadores
                .MapearAnexoTramiteEditViewModelASmcAnexoTramite(ref model, ref _anexoTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.AgregarAnexo(_anexoTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteAnexoAccionAgregar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
        public ResultadoDTO<int> ActualizarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ActualizarAnexo" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            string strParamValidator = _mapeadores
                                        .MapearAnexoTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteAnexo);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteAnexoServidor(model.idanexotramite
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteAnexoEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcAnexoTramite _anexoTramiteEntidad = new SmcAnexoTramite();

            _mapeadores
                .MapearAnexoTramiteEditViewModelASmcAnexoTramite(ref model, ref _anexoTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.ActualizarAnexo(_anexoTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteAnexoAccionActualizar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
    }
}
