using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGestionTramite
    {
        ResultadoDTO<DataPagineada<TramiteListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<TramiteEditViewModel> LeerPorId(short id);
        ResultadoDTO<int> GrabarTramite(TramiteEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<int> EliminarTramite(short id, string usuario, string controlador, string pcclient);
        object LeerDetalleListaTodos(short idtramite, string entidad);
        object LeerDetallePorId(short identidad, string entidad);
        object GrabarDetalle(string model, string usuario, string controlador, string pcclient, string entidad);
        object EliminarDetalle(string model, string usuario, string controlador, string pcclient, string entidad);
    }
}
