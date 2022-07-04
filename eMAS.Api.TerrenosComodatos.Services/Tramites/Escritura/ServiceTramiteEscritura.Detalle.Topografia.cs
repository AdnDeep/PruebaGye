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
        public ResultadoDTO<int> AgregarTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "AgregarTopografia" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            model.idtopografiaterreno = 0;

            string strParamValidator = _mapeadores
                                        .MapearTopografiaTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteTopografia);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteTopografiaServidor(model.idtopografiaterreno
                                        , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteTopografiaEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcTopografiaTerreno _topografiaTramiteEntidad = new SmcTopografiaTerreno();

            _mapeadores
                .MapearTopografiaTramiteEditViewModelASmcTopografiaTerrenoEdict(ref model, ref _topografiaTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.AgregarTopografiaTerreno(_topografiaTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteTopografiaAccionAgregar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
        public ResultadoDTO<int> ActualizarTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ActualizarTopografia" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            string strParamValidator = _mapeadores
                                        .MapearTopografiaTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteTopografia);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteTopografiaServidor(model.idtopografiaterreno
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteTopografiaEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcTopografiaTerreno _topografiaTramiteEntidad = new SmcTopografiaTerreno();

            _mapeadores
                .MapearTopografiaTramiteEditViewModelASmcTopografiaTerrenoEdict(ref model, ref _topografiaTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.ActualizarTopografiaTerreno(_topografiaTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteTopografiaAccionActualizar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
    }
}
