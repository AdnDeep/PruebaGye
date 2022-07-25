using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GestionBeneficiarioController : ControllerBase
    {
        private readonly ValidadoresBeneficiariosRequest _validadoresRequest;
        private readonly IServiceBeneficiarioEscritura _serviceBeneficiarioEscritura;
        private readonly IServiceBeneficiarioLecturaTodos _serviceBeneficiarioLecturaTodos;
        private readonly IServiceBeneficiarioEliminacion _serviceBeneficiarioEliminacion;
        public GestionBeneficiarioController(IServiceBeneficiarioLecturaTodos serviceBeneficiarioLecturaTodos
            , IServiceBeneficiarioEscritura serviceBeneficiarioEscritura
            , IServiceBeneficiarioEliminacion serviceBeneficiarioEliminacion
            , ValidadoresBeneficiariosRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceBeneficiarioLecturaTodos = serviceBeneficiarioLecturaTodos;
            _serviceBeneficiarioEscritura = serviceBeneficiarioEscritura;
            _serviceBeneficiarioEliminacion = serviceBeneficiarioEliminacion;
        }
        [HttpGet]
        [Route("ObtenerListadoPorPagina")]
        public ActionResult<ResultadoDTO<DataPagineada<BeneficiariosListViewModel>>> ObtenerListadoPorPagina(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> respuesta = new ResultadoDTO<DataPagineada<BeneficiariosListViewModel>>();

            if (!(_validadoresRequest.ValidaDataRequestLecturaTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila, ref respuesta))) 
                return BadRequest(respuesta);
            
            respuesta = _serviceBeneficiarioLecturaTodos.ConsultarBeneficiariosTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila);

            return Ok(respuesta);
        }
        [HttpGet]
        [Route("ObtenerPorId")]
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> ObteneroPorId(short id)
        {
            ResultadoDTO<BeneficiarioEditViewModel> respuesta = new ResultadoDTO<BeneficiarioEditViewModel>();

            respuesta = _serviceBeneficiarioLecturaTodos.ConsultarPorId(id);

            return Ok(respuesta);
        }
        [HttpPost]
        [Route("Agregar")]
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> Agregar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> respuesta = new ResultadoDTO<BeneficiarioEditViewModel>();

            if (!(_validadoresRequest.ValidarDatosClienteBeneficiarioEditViewModel(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceBeneficiarioEscritura.Agregar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpPut]
        [Route("Actualizar")]
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> Actualizar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> respuesta = new ResultadoDTO<BeneficiarioEditViewModel>();

            if (!(_validadoresRequest.ValidarDatosClienteBeneficiarioEditViewModel(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceBeneficiarioEscritura.Actualizar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> Eliminar(short id, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<string> respuesta = new ResultadoDTO<string>();

            if (!(_validadoresRequest.ValidarDatosEliminacionClienteBeneficiario(id, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceBeneficiarioEliminacion.Eliminar(id, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
    }
}
