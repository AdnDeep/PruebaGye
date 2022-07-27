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
        public ResultadoDTO<int> AgregarOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "AgregarOficio" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            model.idoficiootrasdirecciones = 0;

            string strParamValidator = _mapeadores
                                        .MapearOficioTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteOficio);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteOficioServidor(model.idoficiootrasdirecciones
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteOficioEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcOficioOtrasDireccione _oficioTramiteEntidad = new SmcOficioOtrasDireccione();

            _mapeadores
                .MapearOficioTramiteEditViewModelASmcOficioOtrasDireccione(ref model, ref _oficioTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.AgregarSeguimientoOficio(_oficioTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteOficioAccionAgregar(ref respuestaLogicDB, ref resultadoVista);

            if (!respuestaGestionGrabar)
                return resultadoVista;

            resultadoVista.dataresult = respuestaLogicDB.Item1;

            return resultadoVista;
        }
        public ResultadoDTO<int> ActualizarOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ActualizarOficio" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            Tuple<List<SmcValidaDataServidor>, string> respuestaLogicDataValidation = null;

            string strParamValidator = _mapeadores
                                        .MapearOficioTramiteEditViewModelADataValidationEscritura(ref model);

            try
            {
                respuestaLogicDataValidation = _logic.ValidarEntidadAEscribir(strParamValidator, objValidadotEscrituraTramiteOficio);
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
                                    .ValidaRespuestLogicDataValidationEscrituraTramiteOficioServidor(model.idoficiootrasdirecciones
                                    , model.idtramite, ref respuestaLogicDataValidation, ref resultadoVista);

            if (!validaRespuestaLogicDataValidation)
                return resultadoVista;

            bool respuestaValidacion = _validadores
                                        .ValidarDatosClienteTramiteOficioEditViewModel(ref model, ref resultadoVista);

            if (!respuestaValidacion)
                return resultadoVista;

            SmcOficioOtrasDireccione _oficioTramiteEntidad = new SmcOficioOtrasDireccione();

            _mapeadores
                .MapearOficioTramiteEditViewModelASmcOficioOtrasDireccione(ref model, ref _oficioTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.ActualizarSeguimientoOficio(_oficioTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteOficioAccionActualizar(ref respuestaLogicDB, ref resultadoVista);

            if (!respuestaGestionGrabar)
                return resultadoVista;

            resultadoVista.dataresult = respuestaLogicDB.Item1;

            return resultadoVista;
        }
    }
}
