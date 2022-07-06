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
    public class ServiceBeneficiarioLecturaTodos : IServiceBeneficiarioLecturaTodos
    {
        private readonly MapeadoresLecturaBeneficiario _mapeadoresLectura;
        private readonly ValidadoresLecturaBeneficiarios _validadoresBeneficiarios;
        private readonly BeneficiarioLogicLectura _beneficiarioLogicLectura;
        private readonly ILogger<ServiceBeneficiarioLecturaTodos> _logger;
        public ServiceBeneficiarioLecturaTodos(BeneficiarioLogicLectura beneficiarioLogicLectura
            , MapeadoresLecturaBeneficiario mapeadoresLectura
            , ValidadoresLecturaBeneficiarios validadoresBeneficiarios
            , ILogger<ServiceBeneficiarioLecturaTodos> logger)
        {
            _mapeadoresLectura = mapeadoresLectura;
            _beneficiarioLogicLectura = beneficiarioLogicLectura;
            _validadoresBeneficiarios = validadoresBeneficiarios;
            _logger = logger;
        }
        public ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> ConsultarBeneficiariosTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<BeneficiariosListViewModel>>();
            
            var parametros = $"ServiceBeneficiarioLecturaTodos Service Layer Try: dataPanel {panelFilter}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarBeneficiariosTodosPaginado" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            var panelModel = JsonConvert.DeserializeObject<BeneficiariosPanelFilterModel>(panelFilter);
            

            Tuple<List<SmcBeneficiarioPaginado>, int> resultadoPaginado = null;
            resultadoVista.dataresult = new DataPagineada<BeneficiariosListViewModel>();
            try
            {
                resultadoPaginado = _beneficiarioLogicLectura
                                        .ObtenerBeneficiariosPaginado(panelModel, numeroPagina, numeroFila);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }
                
                resultadoVista.mensaje = "Se produjo un error en la aplicación [1].";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            bool respuestaValidacion = _validadoresBeneficiarios.ResultadoLogicConsultaPaginado(ref resultadoPaginado, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            List<SmcBeneficiarioPaginado> lsBeneficiarioPaginado = resultadoPaginado.Item1;
            _mapeadoresLectura.MapearListaBeneficiarioPaginadaAListaBeneficiarioViewModel(ref lsBeneficiarioPaginado
                , ref resultadoVista, numeroPagina, resultadoPaginado.Item2, resultContainer);

            return resultadoVista;
        }

        public ResultadoDTO<BeneficiarioEditViewModel> ConsultarPorId(short id)
        {
            var parametros = $"ServiceBeneficiarioLecturaTodos Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ConsultarPorId" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            ResultadoDTO<BeneficiarioEditViewModel> resultadoVista = new ResultadoDTO<BeneficiarioEditViewModel>();
            Tuple<SmcBeneficiarioEdit, string, short> respuestaLogic = null;

            try
            {
                respuestaLogic = _beneficiarioLogicLectura.ObtenerBeneficiarioPorId(id);
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

            bool respuestaValidacion = _validadoresBeneficiarios.ResultadoLogicConsultaPorId(ref respuestaLogic, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            var _beneficiarioEdit = respuestaLogic.Item1;
            _mapeadoresLectura.MapearSmcBeneficiarioEditABeneficiarioEditViewModel(ref _beneficiarioEdit, ref resultadoVista);

            return resultadoVista;
        }
    }
}
