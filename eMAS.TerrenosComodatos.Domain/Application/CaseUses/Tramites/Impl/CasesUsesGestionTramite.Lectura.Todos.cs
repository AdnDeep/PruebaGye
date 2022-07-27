using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<DataPagineada<TramiteListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<TramiteListViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<TramiteListViewModel>>();

            bool respValInputClient = _validadores.InputClientGetPagedData(dataPanel, resultContainer, numeroPagina, numeroFila, ref resultadoVista);

            if (!respValInputClient)
                return resultadoVista;

            var respRepExterno = _repositorioExterno.GetVistaTodosPaginado(dataPanel, resultContainer, numeroPagina, numeroFila);

            bool respValServ = _validadores.RespuestaServidorRemotoDataPaginada(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.RespuestaServidorDataPaginada(ref respRepExterno, ref resultadoVista);

            return resultadoVista;
        }
    }
}
