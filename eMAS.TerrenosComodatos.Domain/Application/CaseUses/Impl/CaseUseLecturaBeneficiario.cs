using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers;
using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public class CaseUseLecturaBeneficiario : ICaseUseLecturaBeneficiario
    {
        private readonly CaseUseLecturaBeneficiarioMapeadores _mapeadoresLecturaBeneficiario;
        private readonly CaseUseLecturaBeneficiarioValidadores _validadoresCaseUseLecturaBeneficiario;
        private readonly IGestionRepositorioLecturaBeneficiario _gestionRepositorioLecturaBeneficiario;
        private readonly ILogger<CaseUseLecturaBeneficiario> _logger;
        public CaseUseLecturaBeneficiario(ILogger<CaseUseLecturaBeneficiario> logger
            , IGestionRepositorioLecturaBeneficiario gestionRepositorioLecturaBeneficiario
            , CaseUseLecturaBeneficiarioValidadores validadoresCaseUseLecturaBeneficiario
            , CaseUseLecturaBeneficiarioMapeadores mapeadoresLecturaBeneficiario)
        {
            _gestionRepositorioLecturaBeneficiario = gestionRepositorioLecturaBeneficiario;
            _mapeadoresLecturaBeneficiario = mapeadoresLecturaBeneficiario;
            _validadoresCaseUseLecturaBeneficiario = validadoresCaseUseLecturaBeneficiario;
            _logger = logger;
        }
        public ResultadoDTO<BeneficiarioEditModel> LeerPorId(short id)
        {
            ResultadoDTO<BeneficiarioEditModel> resultadoVista = new ResultadoDTO<BeneficiarioEditModel>();
            BeneficiarioEditModel _beneficiarioEditModel = null;
            // Se Valida que el id ingresado sea 0
            if (id == 0)
            {
                _beneficiarioEditModel = new BeneficiarioEditModel();
                resultadoVista.dataresult = _beneficiarioEditModel;
                resultadoVista.mensaje = "OK";
                resultadoVista.tipo = "EXITO";
            }
            else 
            {
                // Busca el elemento
                var resultado = _gestionRepositorioLecturaBeneficiario.GetBeneficiarioPorId(id);

                if (_validadoresCaseUseLecturaBeneficiario.ValidarRespuestaBeneficiarioPorId(ref resultado, ref resultadoVista))
                {
                    var beneficiarioTmp = resultado.dataresult.Item1;
                    _beneficiarioEditModel = new BeneficiarioEditModel();
                    _mapeadoresLecturaBeneficiario.MapearBeneficiarioABeneficiarioEditModel(ref beneficiarioTmp, ref _beneficiarioEditModel);

                    resultadoVista.dataresult = _beneficiarioEditModel;
                    resultadoVista.mensaje = "OK";
                    resultadoVista.tipo = "EXITO";
                }
            }
            return resultadoVista;
        }

        public ResultadoDTO<DataPagineada<BeneficiariosViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFilas)
        {
            ResultadoDTO<DataPagineada<BeneficiariosViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<BeneficiariosViewModel>>();
            List<Mensaje> mensajes = new List<Mensaje>();
            var panelModel = JsonConvert.DeserializeObject<BeneficiariosPanelFilterModel>(dataPanel);
            // Leer pagina de la base de datos
            var resultado = _gestionRepositorioLecturaBeneficiario.GetBeneficiarioTodosPaginado(panelModel, numeroPagina, numeroFilas);

            if (resultado == null) 
            {
                _logger.LogError($"El objeto devuelto de la base de datos es nulo");
                resultadoVista.dataresult = new DataPagineada<BeneficiariosViewModel>();
                resultadoVista.mensaje = "LeerTodosPaginado: Se produjo un error en la aplicación (1). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
            }

            var mensajeProducidoErrCapaRepositorio = resultado.mensajes.FirstOrDefault(fod => fod.codigo == "GRBIMPLINT001");

            if (mensajeProducidoErrCapaRepositorio != null)
            {
                _logger.LogError($"{mensajeProducidoErrCapaRepositorio.descripcion}");
                resultadoVista.dataresult = new DataPagineada<BeneficiariosViewModel>();
                resultadoVista.mensaje = "LeerTodosPaginado: Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
            }
            // Convertir los datos a modelo de vista
            DataPagineada<BeneficiariosViewModel> dataPaged = new DataPagineada<BeneficiariosViewModel>();
            dataPaged.paginaactual = numeroPagina;
            dataPaged.totalpaginas = resultado.dataresult.Item2;
            dataPaged.resultcontainer = resultContainer;
            if (resultado.dataresult != null && resultado.dataresult.Item1 != null)
            {
                var lsBeneficiarioLocal = resultado.dataresult.Item1;
                var lsBeneficiarioViewModel = new List<BeneficiariosViewModel>();
                _mapeadoresLecturaBeneficiario.MapearListaBeneficiarioAListaBeneficiarioViewModel(ref lsBeneficiarioLocal, ref lsBeneficiarioViewModel);

                dataPaged.data = lsBeneficiarioViewModel;
            }
            resultadoVista.dataresult = dataPaged;

            // Retornar Resultado
            return resultadoVista;

               
        }
    }
}
