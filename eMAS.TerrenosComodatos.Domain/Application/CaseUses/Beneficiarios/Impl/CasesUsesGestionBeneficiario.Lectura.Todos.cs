using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        public ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<BeneficiarioListViewModel>>();

            bool respValInputClient = _validadores.InputClientGetPagedData(dataPanel, resultContainer, numeroPagina, numeroFila, ref resultadoVista);

            if (!respValInputClient)
                return resultadoVista;

            var respRepExterno =_repositorioExterno.GetBeneficiarioTodosPaginado(dataPanel, resultContainer, numeroPagina, numeroFila);

            bool respValServ = _validadores.RespuestaServidorRemotoDataPaginada(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.RespuestaServidorDataPaginada(ref respRepExterno, ref resultadoVista);

            return resultadoVista;
        }
    }
}
